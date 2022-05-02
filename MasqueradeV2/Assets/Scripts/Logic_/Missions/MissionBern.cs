using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionBern : MissionsTemplate //al heredar de MissionsTemplate ya tiene MonoBehaviour
{
    void Start()
    {
        SetValues();
    }

    public void LogicX()
    {
        //inserte logica de victoria y en caso de cumplida llame el metodo

        if (Inventory.invScript.wheats == 3)
        {
            MissionDone();
        }
    }
}
