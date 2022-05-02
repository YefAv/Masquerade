using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaw1 : MonoBehaviour
{
    [SerializeField] private Transform respawnLocation;
    public void OnTriggerEnter(Collider otherCollider)
    {
        PlayerPosition(otherCollider.gameObject);
        Debug.Log(otherCollider.gameObject.ToString());
    }
    private void PlayerPosition(GameObject player)
    {
        player.transform.position = respawnLocation.position;
        Debug.Log(player.transform.position.ToString());
    }

}
