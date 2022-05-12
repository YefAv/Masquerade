using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IlusionLogic : MonoBehaviour
{
    [SerializeField] private GameObject activationObject;

    private void Start()
    {
        gameObject.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            //activationObject.SetActive(true);
        }
    }
    
}
