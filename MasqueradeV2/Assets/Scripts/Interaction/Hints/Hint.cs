using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Fungus;
using UnityEngine;

public class Hint : MonoBehaviour, IInteractable
{
    SavedData data;
    GameObject diaryAnim;
    [SerializeField] private int pistaIndex = 0;
    //bool noQueri;

    private void Start()
    {
        diaryAnim = DiaryAnimation.diaryAnim;
        data = SaveTrigger.saveTrigger.saveData;
        for (int i = 0; i < data.clueNotes.Count; i++)
        {
            if (data.clueNotes[i] == pistaIndex)
            {
                gameObject.SetActive(false);
            }
        }
    }
    /*void Update()
    {
        if (noQueri == false)
        {
            data = SaveTrigger.saveTrigger.saveData;
            for (int i = 0; i < data.clueNotes.Count; i++)
            {
                if (data.clueNotes[i] == pistaIndex)
                {
                    gameObject.SetActive(false);
                }
            }
            noQueri = true;
        }
    }*/
    public void Select()
    {
        SaveMe();
    }
    void SaveMe()
    {
        data.clueNotes.Add(pistaIndex);
        diaryAnim.SetActive(true);
        gameObject.SetActive(false);
    }

}

