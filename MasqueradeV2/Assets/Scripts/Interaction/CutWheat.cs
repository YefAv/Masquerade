using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutWheat : MonoBehaviour,IInteractable
{
    private Rigidbody rg;
    [SerializeField] private MissionBern pan;
    private bool cut;
    private void Start()
    {
        rg = GetComponent<Rigidbody>();
        cut = false;
    }

    public void Select()
    {
        if (!cut)
        {
            if (Inventory.invScript.canUseHoe)
            {
                rg.useGravity = true;
                Destroy(this,0.5f);
                cut = true;
                Inventory.invScript.HaveWheats_();
                pan.LogicX();
            }
            
        }

    }
}
