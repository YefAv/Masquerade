using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaw : MonoBehaviour
{
    public GameObject spawLocations;
    public GameObject player;
    private Vector3 respawLocation;

    private void OnTriggerEnter(Collider otherCollider)
    {
        spawLocations = GameObject.FindGameObjectWithTag("Spaw");
        respawLocation = player.transform.position;
        Spawner();
    }

    private void Spawner()
    {
        GameObject.Instantiate(player, spawLocations.transform.position, Quaternion.identity);
        
    }

}
