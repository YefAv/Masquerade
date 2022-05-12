using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] float maxRange = 3.5f;
    [SerializeField] LayerMask mask;
    [NonSerialized] public bool canInteract = true;
    
    void Update()
    {
        Selecting();
    }
    void Selecting()
    {
        if (Input.GetButtonDown("Fire1") && canInteract)
        {

            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxRange, mask))
            {
                var selectable = hit.transform;
                IInteractable selectableCode = selectable.gameObject.GetComponent<IInteractable>();
                if (selectableCode != null)
                {
                    selectableCode.Select();
                }
            }
        }
    }
}
