using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitTutorial : MonoBehaviour
{
    private GameObject tutorial;
    void Start()
    {
        tutorial = gameObject.transform.GetChild(0).gameObject;
        tutorial.SetActive(false);
    }
    

    public void InitTuto()
    {
        tutorial.SetActive(true);
    }
}
