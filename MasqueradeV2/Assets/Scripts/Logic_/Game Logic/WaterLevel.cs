using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLevel : MonoBehaviour
{
    [SerializeField] private Transform[] levelOfWater;
    [SerializeField] private float inteRatio;
    
    
    private void Update()
    {
        if (TimeSysN.timeSys.tiempoCorriendo)
        {
            gameObject.transform.position=Vector3.Lerp(gameObject.transform.position,levelOfWater[0].position, inteRatio);
        }
    }
    
}
