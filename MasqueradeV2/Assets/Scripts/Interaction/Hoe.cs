using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Hoe : MonoBehaviour, IInteractable
{
    public void Select()
    {
        Inventory.invScript.HaveHoe_();
        Destroy(gameObject);
    }
}
