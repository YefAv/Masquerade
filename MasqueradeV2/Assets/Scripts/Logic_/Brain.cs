using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Brain : MonoBehaviour
{
    public bool tiempoNormal;
    public static Brain _brain;
    [SerializeField] private bool restart;
    [SerializeField] private PlayableDirector directorPlayer;
    [SerializeField] private GameObject playerCam, cinematicCam;


    public enum EstadosDeJuego
    {
        tutorial,
        normal,
        cinematica,
        diario,
        npc,
        iglesia,
        intro
    }

    private EstadosDeJuego estado;
    
    public EstadosDeJuego Estado
    {
        get => estado;
    }

    private void Awake()
    {
        _brain = this;
    }

    private void Start()
    {
        //estado = EstadosDeJuego.intro;

        if (restart)
        {
            SaveTrigger.saveTrigger.Guardar();
            //aca va el reinico
        }
        else
        {
            SaveTrigger.saveTrigger.Cargar();
            
        }
        
        if (SaveTrigger.saveTrigger.saveData.day >= 1)
        {
            estado = EstadosDeJuego.normal;
            FungusReactions.fungusCode.tpToStart();
        }
        else
        {
            estado = EstadosDeJuego.intro;
            directorPlayer.Play();
            //FungusReactions.fungusCode.PlayAnimaticOneTime();
            //Correr cinemática y al terminar dialogo fungus
        }
    }

    void Update()
    {
        Debug.Log("Estoy en estado "+estado);
        switch (estado)
        {
            case EstadosDeJuego.tutorial:
                tiempoNormal = true;
                TimeSysN.timeSys.tiempoCorriendo = false;
                PlayerStateMachine.playerStateMachine.playerState = PlayerStateMachine.PlayerMovState.NormalMov;
                PlayerStateMachine.playerStateMachine.cameraState = PlayerStateMachine.CameraState.normalCam;
                OpenDiary.openDiaryCode.usability = true;
                cinematicCam.SetActive(false);
                playerCam.SetActive(true);
                //hud codigos tuto

                break;
            case EstadosDeJuego.normal:
                tiempoNormal = true;
                TimeSysN.timeSys.tiempoCorriendo = true;
                PlayerStateMachine.playerStateMachine.playerState = PlayerStateMachine.PlayerMovState.NormalMov;
                PlayerStateMachine.playerStateMachine.cameraState = PlayerStateMachine.CameraState.normalCam;
                OpenDiary.openDiaryCode.usability = true;
                cinematicCam.SetActive(false);
                playerCam.SetActive(true);
                //hud completo
                
                break;
            case EstadosDeJuego.cinematica:
                tiempoNormal = true;
                TimeSysN.timeSys.tiempoCorriendo = false;
                PlayerStateMachine.playerStateMachine.playerState = PlayerStateMachine.PlayerMovState.FreezeMov;
                PlayerStateMachine.playerStateMachine.cameraState = PlayerStateMachine.CameraState.FreezeCam;
                OpenDiary.openDiaryCode.usability = false;
                cinematicCam.SetActive(false);
                playerCam.SetActive(true);
                //sin hud
                
                break;
            case EstadosDeJuego.diario:
                tiempoNormal = true;
                TimeSysN.timeSys.tiempoCorriendo = false;
                PlayerStateMachine.playerStateMachine.playerState = PlayerStateMachine.PlayerMovState.FreezeMov;
                PlayerStateMachine.playerStateMachine.cameraState = PlayerStateMachine.CameraState.Diary;
                OpenDiary.openDiaryCode.usability = true;
                cinematicCam.SetActive(false);
                playerCam.SetActive(true);
                Debug.Log("diario HIJUEPUTAAAA");
                //hud hora 
                
                break;
            case EstadosDeJuego.npc:
                tiempoNormal = true;
                TimeSysN.timeSys.tiempoCorriendo = false;
                PlayerStateMachine.playerStateMachine.playerState = PlayerStateMachine.PlayerMovState.FreezeMov;
                PlayerStateMachine.playerStateMachine.cameraState = PlayerStateMachine.CameraState.FreezeCam;
                OpenDiary.openDiaryCode.usability = false;
                cinematicCam.SetActive(false);
                playerCam.SetActive(true);
                //sin hud

                break;
            case EstadosDeJuego.iglesia:
                tiempoNormal = false;
                TimeSysN.timeSys.tiempoCorriendo = true;
                PlayerStateMachine.playerStateMachine.playerState = PlayerStateMachine.PlayerMovState.NormalMov;
                PlayerStateMachine.playerStateMachine.cameraState = PlayerStateMachine.CameraState.normalCam;
                OpenDiary.openDiaryCode.usability = true;
                cinematicCam.SetActive(false);
                playerCam.SetActive(true);
                //hud completo

                break;
            case EstadosDeJuego.intro:
                tiempoNormal = true;
                TimeSysN.timeSys.tiempoCorriendo = false;
                PlayerStateMachine.playerStateMachine.playerState = PlayerStateMachine.PlayerMovState.FreezeMov;
                PlayerStateMachine.playerStateMachine.cameraState = PlayerStateMachine.CameraState.FreezeCam;
                OpenDiary.openDiaryCode.usability = false;
                cinematicCam.SetActive(true);
                playerCam.SetActive(false);
                break;
        }
    }

    public void CambiarEstado(EstadosDeJuego estado_)
    {
        estado = estado_;
    }

    public void FinDeCinematica()
    {
        Debug.Log("ora si krnaaaal");
        CambiarEstado(EstadosDeJuego.normal);
        FungusReactions.fungusCode.tpToStart();
    }
}
