using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryAnimation : MonoBehaviour
{
    static public GameObject diaryAnim;

    private void Awake()
    {
        diaryAnim = this.gameObject;
        //Disable();
    }

    private void Start()
    {
        Disable();
    }

    private void Update()
    {
        Invoke("Disable", 3);
    }
    void Disable()
    {
        gameObject.SetActive(false);
    }
}
