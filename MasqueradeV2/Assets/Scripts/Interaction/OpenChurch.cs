using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChurch : MonoBehaviour,IInteractable
{
    public void Select()
    {
        if (Inventory.invScript.HaveCurchKey)
        {
            DemoTrigger.demoTrigger.StartCoroutine("EndDemoCoroutine");
            Destroy(gameObject);// Animación de puerta abriendose
        }
    }
}
