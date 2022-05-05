using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisssionBuck : MissionsTemplate //al heredar de MissionsTemplate ya tiene MonoBehaviour
{
   [SerializeField] PatternControl Gano;
    void Start()
    {
        SetValues();
    }

    public void LogicX()
    {
        //inserte logica de victoria y en caso de cumplida llame el metodo
        if ( Gano.Ganar == true)
        {
            MissionDone();
            //Se abre iglesia, debería haber closeUp y animación
        }
        //MissionDone();
    }
}
