using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FungusLogic_Cicle : MonoBehaviour, I_FungusLogic
{
    InteNpc NPC;
    int dialogecount=1;
    [SerializeField] string[] fungusMessages;

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
        else if (TimeSystem.timeSyst.CheckDay() == 2)
        {
            return fungusMessages[1];
        }
        else
        {
            dialogecount++;
            if (dialogecount == fungusMessages.Length) dialogecount = 2;
            return fungusMessages[dialogecount];
        }
    }
}
