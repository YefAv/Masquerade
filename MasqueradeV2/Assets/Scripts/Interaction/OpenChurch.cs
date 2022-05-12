using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChurch : MonoBehaviour,IInteractable
{
    public void Select()
    {
        if (Inventory.invScript.HaveCurchKey)
        {
            Destroy(gameObject);// Animación de puerta abriendose
        }
    }
}
