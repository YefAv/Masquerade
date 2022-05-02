using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Fungus;
using UnityEngine;

public class Hint : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject hintNote;
    private bool opened;
    private GameObject pistas, diario;
    [SerializeField] private int pistaIndex = 0;
    GameObject diaryAnim;

    bool known;
    SavedData data;

    private void Start()
    {
        pistas = GameObject.FindGameObjectWithTag("Pistas").gameObject;
        diario = GameObject.FindGameObjectWithTag("DiaryLogic").gameObject.transform.GetChild(0).gameObject;
        diaryAnim = DiaryAnimation.diaryAnim;
        data = TimeSystem.timeSyst.saveCode;
    }
    public void Select()
    {
        //gameObject.SetActive(false);
        SaveMe();
        hintNote.SetActive(true);
        opened = true;

        //Diario Feedback
        OpenDiary.openDiaryCode.Open();
        //GameObject.FindGameObjectWithTag("DiaryLogic").gameObject.transform.GetChild(1).gameObject.GetComponent<Animator>().SetTrigger("Pista");

        diaryAnim.SetActive(true);
        pistas.transform.GetChild(pistaIndex).gameObject.SetActive(true);

        //Pantalla Pista
        diario.transform.GetChild(0).gameObject.SetActive(true);
        diario.transform.GetChild(1).gameObject.SetActive(false);
        diario.transform.GetChild(2).gameObject.SetActive(false);
        diario.transform.GetChild(3).gameObject.SetActive(false);


        StartCoroutine(DestroyIt());
        //Destroy(gameObject);    
        
        //tieso
        
    }

    void closeIt()
    {
        //gameObject.SetActive(true);
        OpenDiary.openDiaryCode.Close();
        opened = false;
        //tieso a la menos 1
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && opened)
        {
            closeIt();
        }
    }

    IEnumerator DestroyIt() 
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject); 
    }

    void SaveMe()
    {

        for (int i = 0; i < data.clueNotes.Count; i++)
        {
            if (data.clueNotes[i] == pistaIndex)
                known = true;
        }
        
        if (!known)
        {
            data.clueNotes.Add(pistaIndex);
            known = true;
            diaryAnim.SetActive(true);
        }
    }

}

