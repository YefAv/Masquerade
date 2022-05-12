using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatFunction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Inventory.invScript.HaveHoe)
        {
            //activar canvas
            Inventory.invScript.canUseHoe = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //desactivar canvas
        Inventory.invScript.canUseHoe = false;
        Debug.Log("Saliste de la zona");
    }
}
