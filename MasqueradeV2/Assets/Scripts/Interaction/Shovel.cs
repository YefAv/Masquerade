using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour, IInteractable
{
    [SerializeField] granjeroPorky porky; 
    public void Select()
    {
        Inventory.invScript.HaveShovel_();
        porky.LogicX(); 
        Destroy(gameObject);
        
    }
}
