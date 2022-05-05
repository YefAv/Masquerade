using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternControl : MonoBehaviour
{
    static int[] solution = { 2, 1, 4, 3 };
    int selectionCount;

    [SerializeField] Material defaulfM;
    [SerializeField] float waitTime = 0.5f;
    public bool Ganar = false;
    [SerializeField] MisssionBuck buck;
    
    //Arreglos con los datos de cada cosito
    [SerializeField] int[] input = new int[4];
    IntePattern[] selectedObj = new IntePattern[4];
    private Animator leverAnim;

    [SerializeField] AudioClip[] clips = new AudioClip[2];
    AudioSource audioSource;
    [SerializeField] ParticleSystem winParticles;

    void Start()
    {
        selectionCount = 0;
        IntePattern.Selected += StoreResult;
        audioSource = GetComponent<AudioSource>();
    }

    private void StoreResult(IntePattern obj)
    {
        selectedObj[0] = selectedObj[1];
        selectedObj[1] = selectedObj[2];
        selectedObj[2] = selectedObj[3];
        selectedObj[3] = obj;

        selectionCount++;        
        CheckResult();       
    }

    private void CheckResult()
    {
        if (selectionCount == 4)
        {
            if (solution[0] == selectedObj[0].cubeOrder && solution[1] == selectedObj[1].cubeOrder && 
                solution[2] == selectedObj[2].cubeOrder && solution[3] == selectedObj[3].cubeOrder)
            {
                audioSource.clip = clips[0];
                audioSource.Play();
                winParticles.Play();
                //WinConditionTemp.winConditionCode.SolvePuzzle();
                Debug.Log("Correct Answer");
                Ganar = true;
                buck.LogicX();
            }
            else
            {
                audioSource.clip = clips[1];
                audioSource.Play();
                StartCoroutine("ResetPuzzle");
            }
        }
    }

    private IEnumerator ResetPuzzle()
    {
        Debug.Log("you're wrong, try again");

        //hagame como un mini parpadeo antes de resetear
        //Esto podria ser una animacion en vez de una corrutina
        yield return new WaitForSeconds(waitTime);
        foreach (IntePattern item in selectedObj) item.render.material = defaulfM;
        yield return new WaitForSeconds(waitTime);
        foreach (IntePattern item in selectedObj) item.render.material = item.selectedM;
        yield return new WaitForSeconds(waitTime);
        foreach (IntePattern item in selectedObj) item.render.material = defaulfM;

        //Reinicie todo lo que tiene que ver el arreglo actual de seleccionados
        selectionCount = 0;
        for (int i = 0; i < input.Length; i++)
        {
            selectedObj[i].selected = false;
            selectedObj[i].render.material = defaulfM;
            selectedObj[i].SoundUpLevers();
            leverAnim = selectedObj[i].gameObject.GetComponentInChildren<Animator>();
            leverAnim.SetTrigger("up");
            selectedObj[i] = null;
        }

        yield return new WaitForSeconds(1);
    }

    private void OnDestroy() //Unsub to avoid reference errors.
    {
        IntePattern.Selected -= StoreResult;
    }
}
