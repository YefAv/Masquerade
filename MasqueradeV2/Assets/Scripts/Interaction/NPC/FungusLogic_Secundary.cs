using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FungusLogic_Secundary : MonoBehaviour, I_FungusLogic
{
    int dialogecount = 0;

    [SerializeField] string[] fungusMessages;

    public string SendMessage()
    {
        dialogecount++;
        if (dialogecount == fungusMessages.Length) dialogecount = 0;
        return fungusMessages[dialogecount];
    }
}
