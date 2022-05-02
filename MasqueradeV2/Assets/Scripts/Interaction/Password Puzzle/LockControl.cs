using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class LockControl : MonoBehaviour
{
    private int[] result;
    [SerializeField] int[] answer, startCom;
    [SerializeField] private GameObject wall;
    public bool solved;

    [SerializeField] AudioClip winClip;
    AudioSource audioSource;
    [SerializeField] ParticleSystem winParticles;

    //the current password is 234 'cause I don't even know the
    //current password, nor if the simbols will be numbers.

    //No, there wont be numbers

    private void Start()
    {
        result = startCom;
        IntePassword.Rotated += CheckResult;
        Flowchart.BroadcastFungusMessage("");
        audioSource = GetComponent<AudioSource>();
    }

    private void CheckResult(string wheelName, int number)
    {
        switch (wheelName) // strores the current combination of the lock
        {
            case "Pass1":
                result[0] = number;
                break;

            case "Pass2":
                result[1] = number;
                break;

            case "Pass3":
                result[2] = number;
                break;
        }

        if (result[0] == answer[0] && result[1] == answer[1] && result[2] == answer[2])
        {
            WinConditionTemp.winConditionCode.SolvePuzzle();
            Debug.Log("Congrats! you oppened the non-existing door");
            audioSource.clip = winClip;
            audioSource.Play();
            winParticles.Play();
            wall.SetActive(false); // Proximamente animación
            //Manda información del sistema de guardado
            solved = true;
        }
    }

    private void OnDestroy() //Unsub to avoid reference errors.
    {
        IntePassword.Rotated -= CheckResult;
    }
}
