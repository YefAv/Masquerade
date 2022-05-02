using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChurchDoor : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.transform.parent.gameObject.SetActive(false);
        }
    }
}
