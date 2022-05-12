using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FungusLogic_Mission : MonoBehaviour, I_FungusLogic
{
    InteNpc NPC;

    [SerializeField] string[] fungusMessages;
    public bool missionComplete = false;
    int beforeMission = 0;
    int afterMission = 0;

     void Start()
    {
        NPC = GetComponent<InteNpc>();
    }
    public string SendMessage()
    {
        if (!NPC.Known) 
        {
            return fungusMessages[0];            
        }
        else if (!missionComplete && beforeMission ==0)
        {
            beforeMission = 1;
            return fungusMessages[1];            
        }
        else if(!missionComplete && beforeMission > 0)
        {
            beforeMission++;
            if (beforeMission == 5) beforeMission = 2;
            return fungusMessages[beforeMission];            
        }
        else if (missionComplete && afterMission == 0)
        {
            afterMission = 6;
            return fungusMessages[5];
        }
        else
        {
            afterMission++;
            if (afterMission == 9) afterMission = 6;
            return fungusMessages[afterMission];
        }
    }
}
