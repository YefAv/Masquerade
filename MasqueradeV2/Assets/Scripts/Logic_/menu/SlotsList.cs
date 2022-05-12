using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsList : MonoBehaviour
{
    [SerializeField] GameObject listNewG;
    [SerializeField] GameObject listContinue;
    [SerializeField] GameObject data;

    private void Start()
    {
        for (int i = 0; i < listNewG.transform.childCount; i++)
        {
            if (!SaveManager.CheckSave(listNewG.transform.GetChild(i).name))
                listNewG.transform.GetChild(i).GetChild(1).gameObject.SetActive(false);
        }
        int emptySaveCont = 0;
        for (int i = 0; i < listContinue.transform.childCount; i++)
        {
            if (!SaveManager.CheckSave(listContinue.transform.GetChild(i).name))
            {
                listContinue.transform.GetChild(i).gameObject.SetActive(false);
                emptySaveCont++;
            }
        }
        if (emptySaveCont >= listContinue.transform.childCount)
        {
            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(2).SetParent(listContinue.transform);
        }
       
    }
    public void ClicNew()
    {
        listContinue.SetActive(false);
        listNewG.SetActive(true);
    }
    public void ClicContinue()
    {
        listNewG.SetActive(false);
        listContinue.SetActive(true);
    }

    public void SelectSlort(string slot)
    {
        SaveManager.SelectSlot_(slot);
    }

    public void SetNewData()
    {
        SaveManager.Save(data.GetComponent<SavedData>(), SaveManager.LoadSlot_());
    }
}
