using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionPenny : MissionsTemplate //al heredar de MissionsTemplate ya tiene MonoBehaviour
{
      
    [SerializeField] InteNpc interation;
    void Start()
    {
        SetValues();
    }
    private void Update()
    {
        LogicX();
    }

    void LogicX()
    {
        if (interation.Known && !doneMission)
        {
            MissionDone();
        }
        //inserte logica de victoria y en caso de cumplida llame el metodo
    }
}
