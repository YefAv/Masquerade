using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionsDone : MonoBehaviour
{
    [SerializeField] GameObject faces;
    //TimeSystem timeSystem;
    //private TimeSysN timeSysN_;
    SavedData savedData;

    private void Start()
    {
        //timeSystem = TimeSystem.timeSyst;
        //savedData = timeSystem.saveCode;
        //timeSysN_=TimeSysN.timeSys;
        savedData = SaveTrigger.saveTrigger.saveData;
    }

    void Update()
    {
        if (faces.activeSelf)
        {
            TurnOn();
        }
    }

    void TurnOn()
    {
        for (int i = 0; i < savedData.completedNPC.Count; i++)
        {
            if (!faces.transform.GetChild(i).gameObject.activeSelf)
            {
                faces.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}
