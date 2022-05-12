using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject ui;
    GameObject[] inventoryImages = new GameObject[5];

    [NonSerialized] public bool canUseHoe;
    public static Inventory invScript;
    [NonSerialized] public int wheats;

    [NonSerialized] private bool haveShovel;
    [NonSerialized] private bool haveHoe;
    [NonSerialized] private bool haveFlower;
    [NonSerialized] private bool haveCurchKey;

    public bool HaveShovel { get => haveShovel; }
    public bool HaveHoe { get => haveHoe; }
    public bool HaveFlower { get => haveFlower; }
    public bool HaveCurchKey { get => haveCurchKey; }

    #region Singleton
    private void Awake()
    {
        invScript = this;
    }
    #endregion

    private void Start()
    {
        for (int i = 0; i < ui.transform.childCount; i++)
        {
            inventoryImages[i] = ui.transform.GetChild(i).gameObject;
            inventoryImages[i].gameObject.SetActive(false);
        }
    }
    public void HaveShovel_()
    {
        haveShovel = true;
        inventoryImages[0].SetActive(true);
    }
    public void HaveHoe_()
    {
        haveHoe = true;
        inventoryImages[1].SetActive(true);
    }
    public void HaveFlower_()
    {
        haveFlower = true;
        inventoryImages[2].SetActive(true);
    }
    public void HaveCurchKey_()
    {
        haveCurchKey = true;
        inventoryImages[3].SetActive(true);
    }
    public void HaveWheats_()
    {
        wheats += 1;
        inventoryImages[4].SetActive(true);
    }
}
