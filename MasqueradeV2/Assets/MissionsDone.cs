using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionsDone : MonoBehaviour
{
    [SerializeField] GameObject faces;
    TimeSystem timeSystem;
    SavedData savedData;

    private void Start()
    {
        timeSystem = TimeSystem.timeSyst;
        savedData = timeSystem.saveCode;
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
