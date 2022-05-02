using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcReaction : MonoBehaviour
{
    public void React(int image)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        transform.GetChild(image).gameObject.SetActive(true);
    } 
}
