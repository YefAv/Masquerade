using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockControl : MonoBehaviour
{
    private int[] result;
    [SerializeField] int[] answer, startCom;
    //the current password is 234 'cause I don't even know the
    //current password, nor if the simbols will be numbers.

    private void Start()
    {
        result = startCom;
        IntePassword.Rotated += CheckResult;
    }

    private void CheckResult(string wheelName, int number)
    {
        switch (wheelName) // strores the current combination of the lock
        {
            case "Pass1":
                result[0] = number;
                break;

            case "Pass2":
                result[1] = number;
                break;

            case "Pass3":
                result[2] = number;
                break;
        }

        if (result[0] == answer[0] && result[1] == answer[1] && result[2] == answer[2])
        {
            Debug.Log("Congrats! you oppened the non-existing door");
            //Insert here the code for whatever has to happen once the puzzle is done.
        }
    }

    private void OnDestroy() //Unsub to avoid reference errors.
    {
        IntePassword.Rotated -= CheckResult;
    }
}
