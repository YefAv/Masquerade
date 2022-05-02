using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour, IInteractable
{
    [SerializeField] MissionMeek meek;
    public void Select()
    {
        Inventory.invScript.HaveFlower_() ;
        meek.LogicX();
        Destroy(gameObject);
    }
}
