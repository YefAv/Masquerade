using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.Video;

public class FungusReactions : MonoBehaviour
{
    public static FungusReactions fungusCode;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawn;
    [SerializeField] private SavedData savedDataCode;
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private GameObject videoCanvas;
    [SerializeField] private AudioSource musicAudSource;
    [SerializeField] private GameObject diarioCanv;
    [SerializeField] GameObject pista;

    #region Singleton
    private void Awake()
    {
        if (fungusCode != null)
        {
            Destroy(gameObject);
        }
        else
        {
            fungusCode = this;
        }
    }
    #endregion

    private void Start()
    {
        PlayAnimaticOneTime();
    }

    public void tpToStart() //this method will be deleted
    {
        TimeSystem.timeSyst.runningTime = true;
        player.transform.position = spawn.position;
        player.transform.rotation = spawn.rotation;
        musicAudSource.Play();
        diarioCanv.SetActive(true);
        savedDataCode.day += 1;
        checkDayTrain();
        PlayerStateMachine.playerStateMachine.playerState = PlayerStateMachine.PlayerState.NormalMov;
    }

    /*private void Update()   //ELIMINAR LUEGO
    {
        if(Input.GetKey(KeyCode.J))
            tpToStart();
    }*/

    public void FirstBellText(bool firstTime)
    {
        if (!firstTime)
        {
            Flowchart.BroadcastFungusMessage("Primera Campanada");
        }
        //if (savedDataCode.day<1) return;
        //Flowchart.BroadcastFungusMessage("Primera Campanada");
    }

    public void PlayAnimaticOneTime()
    {
        if (savedDataCode.day < 1) // !savedDataCode.firstTime
        {
            //El jugador tampoco debería moverse
            Flowchart.BroadcastFungusMessage("TutorialYCinematica");
            _videoPlayer.Play();
            //savedDataCode.firstTime = true;
            PlayerStateMachine.playerStateMachine.playerState = PlayerStateMachine.PlayerState.NormalMov;
        }
        else
        {
            PlayerStateMachine.playerStateMachine.playerState = PlayerStateMachine.PlayerState.Npc;

            OnFinishAnimatic();
            tpToStart(); // o grupo de cosas necesarias para empezar
        }
    }

    public void FirstConversation()
    {
        PlayerStateMachine.playerStateMachine.playerState = PlayerStateMachine.PlayerState.Cinematic;
        Flowchart.BroadcastFungusMessage("Intro");
    }

    public void OnFinishAnimatic()
    {
        Destroy(videoCanvas);
        Destroy(_videoPlayer);
    }

    public void BuckMissionReward()
    {
        //Animatic que muestre la puerta de la iglesia
        Inventory.invScript.HaveCurchKey_();
    }

    public void ActivateCamera()//poner este en todos los flowchars       --soltame hijueputa
    {
        PlayerStateMachine.playerStateMachine.playerState = PlayerStateMachine.PlayerState.NormalMov;
    }

    public void checkDayPickMap()
    {
        switch (savedDataCode.day)
        {
            case 1:
                Flowchart.BroadcastFungusMessage("Tomar Folleto Ciclo1");
                break;
                case 2:
                    Flowchart.BroadcastFungusMessage("Tomar Folleto Ciclo2");
                    break;
                default:
                    Flowchart.BroadcastFungusMessage("Tomar Folleto Ciclo3");
                    break;
        }
    }
    
    public void checkDayTrain()
    {
        switch (savedDataCode.day)
        {
            case 1:
                Flowchart.BroadcastFungusMessage("Bajar Tren Ciclo1");
                break;
            case 2:
                Flowchart.BroadcastFungusMessage("Bajar Tren Ciclo2");
                break;
            default:
                Flowchart.BroadcastFungusMessage("Bajar Tren Ciclo3");
                break;
        }
    }

    public void SwapRunningTime()
    {
        TimeSystem.timeSyst.runningTime = !TimeSystem.timeSyst.runningTime;
    }

    public void VamoAPrender()
    {
        pista.SetActive(true);
    }
}
