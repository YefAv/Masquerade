using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class Win_Manager : MonoBehaviour
{
    [SerializeField] MeshRenderer churchDoor;
    [SerializeField] SlidingPuzzleLogic slidingPuzzle;
    [SerializeField] PatternControl leverPuzzle;
    [SerializeField] IntePattern[] patterns = new IntePattern[4];
    [SerializeField] GameObject[] churchImages = new GameObject[4];
    [SerializeField] Flowchart caronte;
    private int eventNum = 0;
    void Awake()
    {
        foreach (GameObject spriteRenderer in churchImages) spriteRenderer.SetActive(false);        
    }

    void Update()
    {
        if (slidingPuzzle.Complete && eventNum == 0) PrimerEvento();
        if(leverPuzzle.Ganar) SegundoEvento();
    }

    void PrimerEvento()
    {
        churchDoor.enabled = false;


        if (patterns[0].selected) churchImages[0].SetActive(true);
        else if(!patterns[0].selected && patterns[0].gameObject.activeSelf == true) churchImages[0].SetActive(false); 

        if (patterns[1].selected) churchImages[1].SetActive(true);
        else if(!patterns[1].selected && patterns[1].gameObject.activeSelf == true) churchImages[1].SetActive(false); 

        if (patterns[2].selected) churchImages[2].SetActive(true);
        else if(!patterns[2].selected && patterns[2].gameObject.activeSelf == true) churchImages[2].SetActive(false); 

        if (patterns[3].selected) churchImages[3].SetActive(true);
        else if(!patterns[3].selected && patterns[3].gameObject.activeSelf == true) churchImages[3].SetActive(false); 

    }

    void SegundoEvento()
    {
        eventNum = 1;
        caronte.ExecuteBlock("Caronte End");
        eventNum = 2;
    }


}
