using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IlusionActivation : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject iluGameObject;
    
    public void Select()
    {
        iluGameObject.SetActive(true);
        // y más cosas que se deban de activar con la ilusión
        //gameObject.SetActive(false);
    }
}
