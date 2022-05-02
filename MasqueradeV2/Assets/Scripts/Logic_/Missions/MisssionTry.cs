using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisssionTry : MissionsTemplate //al heredar de MissionsTemplate ya tiene MonoBehaviour
{
    void Start()
    {
        SetValues();
    }

    void LogicX()
    {
        //inserte logica de victoria y en caso de cumplida llame el metodo
        MissionDone();
    }
}
