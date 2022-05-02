using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Folleto : MonoBehaviour, IInteractable
{
    [SerializeField] public bool seleccionado;
    public void Select()
    {
        //FungusReactions.fungusCode.checkDayPickMap();
        gameObject.SetActive(false);
        seleccionado = true;
    }
}
