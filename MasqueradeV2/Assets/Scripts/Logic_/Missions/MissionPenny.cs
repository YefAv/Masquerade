using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionPenny : MissionsTemplate //al heredar de MissionsTemplate ya tiene MonoBehaviour
{

    private void Update()
    {
        LogicX();
    }
    [SerializeField] InteNpc interation;
    void Start()
    {
        SetValues();
    }

    void LogicX()
    {
        if (interation.Known)
        {
            MissionDone();
        }
        //inserte logica de victoria y en caso de cumplida llame el metodo
    }
}
