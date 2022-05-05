using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using Unity.Profiling.LowLevel.Unsafe;

public class InteNpc : MonoBehaviour, IInteractable
{
    PlayerMovemnt playerMov;
    private NewMove playerMovement;
    
    bool talking = false;

    public int NPCreference;
    public SavedData data;
    private bool known = false;

    GameObject diaryAnim;

    public I_FungusLogic fungusLogic;

    public CameraZoom zoom;
    public bool Known { get => known;}

    private void Awake()
    {
        playerMov = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovemnt>();
        fungusLogic = GetComponent<I_FungusLogic>();
        Invoke("CheckNPC", 1f);
    }

    private void Start()
    {
        diaryAnim = DiaryAnimation.diaryAnim;
    }

    private void Update() // yono queria 
    {
        stopTalking();
    }

    void CheckNPC()
    {
        for (int i = 0; i < data.discoveredNPC.Count; i++)
        {
            if (data.discoveredNPC[i] == NPCreference)
                known = true;
        }
    }
    public void Select()
    {
        /*if (talking)
        {
            PlayerStateMachine.playerStateMachine.playerState = PlayerStateMachine.PlayerState.NormalMov; //estas chibadas se van a mover 
            talking = false;
            TimeSystem.timeSyst.runningTime = true;
            zoom.CameraZooming(zoom.defaultFov, zoom.defaultSensitivity);
            //liberar camara
        }
        else
        {
            PlayerStateMachine.playerStateMachine.playerState = PlayerStateMachine.PlayerState.Npc; //bug de no me suelta la camara 
            talking = true;
            Talking_();
            zoom.CameraZooming(45,5);
            TimeSystem.timeSyst.runningTime = false;
            //restringir camara
        }*/
        if (!talking)
            startTalking();
    }

    void startTalking()
    {
        Brain._brain.CambiarEstado(Brain.EstadosDeJuego.npc); //bug de no me suelta la camara 
        talking = true;
        Talking_();
        //zoom.CameraZooming(45, 5);
        TimeSysN.timeSys.tiempoCorriendo = false;
    }
    void stopTalking()
    {
        if (Brain._brain.Estado == Brain.EstadosDeJuego.normal && talking)
        {
            talking = false;
            TimeSysN.timeSys.tiempoCorriendo = true;
            //zoom.CameraZooming(zoom.defaultFov, zoom.defaultSensitivity);
        }
    }

    void Talking_()
    {
        Flowchart.BroadcastFungusMessage(fungusLogic.SendMessage());

            for (int i = 0; i < data.discoveredNPC.Count; i++)
            {
                if (data.discoveredNPC[i] == NPCreference)
                    known = true;
            }

        if (!known && NPCreference < 7) 
        { 
            data.discoveredNPC.Add(NPCreference);
            data.mapNotes.Add(NPCreference);
            known = true;
            diaryAnim.SetActive(true);
        }
    }

}


