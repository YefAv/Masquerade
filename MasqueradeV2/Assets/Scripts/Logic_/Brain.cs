using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Brain : MonoBehaviour
{
    public bool tiempoNormal;
    public static Brain _brain;
    [SerializeField] private bool restart;
    

    public enum EstadosDeJuego
    {
        tutorial,
        normal,
        cinematica,
        diario,
        npc,
        iglesia
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
        //_brain = this;
        //SaveTrigger.saveTrigger.saveData.day = 4;

        if (restart)
        {
            SaveTrigger.saveTrigger.Guardar();
        }
        else
        {
            SaveTrigger.saveTrigger.Cargar();
        }
        
        if (SaveTrigger.saveTrigger.saveData.day >= 1)
        {
            estado = EstadosDeJuego.normal;
            FungusReactions.fungusCode.tpToStart();
            Debug.Log("mi perro si estoy X2");
        }
        else
        {
            Debug.Log("mi perro si estoy");
            estado = EstadosDeJuego.tutorial; // o cinemática
            FungusReactions.fungusCode.PlayAnimaticOneTime();
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
                //hud codigos tuto

                break;
            case EstadosDeJuego.normal:
                tiempoNormal = true;
                TimeSysN.timeSys.tiempoCorriendo = true;
                PlayerStateMachine.playerStateMachine.playerState = PlayerStateMachine.PlayerMovState.NormalMov;
                PlayerStateMachine.playerStateMachine.cameraState = PlayerStateMachine.CameraState.normalCam;
                OpenDiary.openDiaryCode.usability = true;
                //hud completo
                
                break;
            case EstadosDeJuego.cinematica:
                tiempoNormal = true;
                TimeSysN.timeSys.tiempoCorriendo = false;
                PlayerStateMachine.playerStateMachine.playerState = PlayerStateMachine.PlayerMovState.FreezeMov;
                PlayerStateMachine.playerStateMachine.cameraState = PlayerStateMachine.CameraState.FreezeCam;
                OpenDiary.openDiaryCode.usability = false;
                //sin hud
                
                break;
            case EstadosDeJuego.diario:
                tiempoNormal = true;
                TimeSysN.timeSys.tiempoCorriendo = false;
                PlayerStateMachine.playerStateMachine.playerState = PlayerStateMachine.PlayerMovState.FreezeMov;
                PlayerStateMachine.playerStateMachine.cameraState = PlayerStateMachine.CameraState.Diary;
                OpenDiary.openDiaryCode.usability = true;
                Debug.Log("diario HIJUEPUTAAAA");
                //hud hora 
                
                break;
            case EstadosDeJuego.npc:
                tiempoNormal = true;
                TimeSysN.timeSys.tiempoCorriendo = false;
                PlayerStateMachine.playerStateMachine.playerState = PlayerStateMachine.PlayerMovState.FreezeMov;
                PlayerStateMachine.playerStateMachine.cameraState = PlayerStateMachine.CameraState.FreezeCam;
                OpenDiary.openDiaryCode.usability = false;
                //sin hud

                break;
            case EstadosDeJuego.iglesia:
                tiempoNormal = false;
                TimeSysN.timeSys.tiempoCorriendo = true;
                PlayerStateMachine.playerStateMachine.playerState = PlayerStateMachine.PlayerMovState.NormalMov;
                PlayerStateMachine.playerStateMachine.cameraState = PlayerStateMachine.CameraState.normalCam;
                OpenDiary.openDiaryCode.usability = true;
                //hud completo

                break;
        }
    }

    public void CambiarEstado(EstadosDeJuego estado_)
    {
        estado = estado_;
    }
}
