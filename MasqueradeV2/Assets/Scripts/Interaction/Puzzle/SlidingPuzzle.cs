using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class SlidingPuzzle : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform part;
    [SerializeField] public Transform empty = null;
    [SerializeField] private pieza[] piezas;
    private int emptyspace;
    public void Select()
    {
        if (Vector3.Distance(a: empty.position, b: part.position) <= 2)
        {
            Vector3 lastEmptyPosition = empty.position;
            pieza tile = part.transform.GetComponent<pieza>();
            empty.position = tile.finalPosition;
            tile.finalPosition = lastEmptyPosition;
            int piezaPosition= Find(tile);
            piezas[emptyspace] = piezas[piezaPosition];
            piezas[piezaPosition] = null;
            emptyspace = piezaPosition;      
        }   
    }
    public void Aleatorio()
    {
            for (int i = 0; i <= 7; i++)
            {
                var ultima = piezas[i].finalPosition;
                int RandomPosition = Random.Range(0, 7);
                piezas[i].finalPosition = piezas[RandomPosition].finalPosition;
                piezas[RandomPosition].finalPosition = ultima;
                var tile = piezas[i];
                piezas[i] = piezas[RandomPosition];
                piezas[RandomPosition] = tile;
            }
    }
    public int Find(pieza ts)
    {
        for (int i = 0; i < piezas.Length; i++)
        {
            if(piezas[i] != null)
            {
                if(piezas[i] == ts)
                {
                    return i;
                }
            }
        }
        return -1;
    }
}


