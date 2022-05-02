using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;

public class WinConditionTemp : MonoBehaviour
{
    public static WinConditionTemp winConditionCode;
    int FinalPuzzlesSolved = 0;

    [SerializeField] GameObject caronte;
    [SerializeField] GameObject caronteFungus;
    public I_FungusLogic fungusLogic;

    #region Singleton
    private void Awake()
    {
        if (winConditionCode != null)
            Destroy(gameObject);
        else
            winConditionCode = this;
    }
    #endregion

    private void Start()
    {
        fungusLogic = caronteFungus.GetComponent<I_FungusLogic>();
    }
    public void SolvePuzzle()
    {
        if (FinalPuzzlesSolved < 3)
            FinalPuzzlesSolved++;
        else
        {
            //caronte.SetActive(true);
            //Flowchart.BroadcastFungusMessage(fungusLogic.SendMessage());
        }
    }

    public void Cinematic_()
    {
        //SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
