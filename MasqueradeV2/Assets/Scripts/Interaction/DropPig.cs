using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPig : MonoBehaviour
{
    [SerializeField] GrabInt pig;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fall") && pig.grabed)
        {
            pig.DropMe();
        }
    }
}
