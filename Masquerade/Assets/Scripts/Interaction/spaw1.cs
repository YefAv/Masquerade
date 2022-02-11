using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaw1 : MonoBehaviour
{
    public GameObject player;
    public Transform respawLocation;
    //Vector3 pos = transform.position;
    public void OnTriggerEnter(Collider otherCollider)
    { 
        if (otherCollider.gameObject.CompareTag("Player"))
        {
            player.gameObject.transform.position = respawLocation.transform.position;
            Debug.Log("entre");
            // PlayerPosition();
            return;
        }
    }
  private void PlayerPosition()
    {
        //player.gameObject.transform.position = respawLocation.transform.position;
        //Debug.Log("aqui");
    }

}
