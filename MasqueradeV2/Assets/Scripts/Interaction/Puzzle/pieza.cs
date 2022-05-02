using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pieza : MonoBehaviour
{
    public Vector3 finalPosition;
    public Vector3 correctPosition;
   
    public bool wine;
    void Start()
    {
        finalPosition = transform.position;
        correctPosition = transform.position;
    }
    void Update()
    {
        transform.position = Vector3.Lerp(a: transform.position, b: finalPosition, t: 0.08f);
        if(finalPosition == correctPosition)
        {
            wine = true;
        }
        else
        {
            wine = false;
        }
    }
}
