using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    [SerializeField] private NewMove playerController;
    [SerializeField] private OpenDiary openDiaryCode;
    [SerializeField] private InteractionManager InteractionManCode;

    public static PlayerStateMachine playerStateMachine;

    #region Singleton

    private void Awake()
    {
        playerStateMachine = this;
    }

    #endregion
    
    public enum PlayerState
    {
        Npc,
        Cinematic,
        Diary,
        NormalMov
    }

    [NonSerialized] public PlayerState playerState = PlayerState.NormalMov;
    
    private void Update()
    {
        Debug.Log("Estoy en estado " + playerState);
        switch (playerState)
        {
            case PlayerState.NormalMov:
                //cameraControl.cameraState = CameraControl.CameraState.normalCam;
                //playerMovemnt.lock_ = false;
                playerController.lockMove = false;
                playerController.cameraState = NewMove.CameraState.normalCam;
                openDiaryCode.usability = true;
                InteractionManCode.canInteract = true;
                return;
            case PlayerState.Npc:
                //cameraControl.cameraState = CameraControl.CameraState.cinematic; // CAMARA QUIETA ====TEMPORAAAAL=====
                //playerMovemnt.lock_ = true;
                //
                playerController.lockMove = true;
                playerController.cameraState = NewMove.CameraState.cinematic;
                openDiaryCode.usability = false;
                openDiaryCode.Close();
                openDiaryCode.diaryHudCanv.SetActive(false);
                InteractionManCode.canInteract = false;
                return;
            case PlayerState.Cinematic:
                //cameraControl.cameraState = CameraControl.CameraState.cinematic;
                //playerMovemnt.lock_ = true;
                //
                playerController.lockMove = true;
                playerController.cameraState = NewMove.CameraState.cinematic;
                openDiaryCode.usability = false;
                openDiaryCode.Close();
                openDiaryCode.diaryHudCanv.SetActive(false);
                InteractionManCode.canInteract = false;
                return;
            case PlayerState.Diary:
                //cameraControl.cameraState = CameraControl.CameraState.diary;
                //playerMovemnt.lock_ = true;
                //
                playerController.cameraState = NewMove.CameraState.diary;
                playerController.lockMove = true;
                InteractionManCode.canInteract = false;
                return;
        }
    }
}
