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
    
    public enum PlayerMovState
    {
        NormalMov,
        FreezeMov
    }
    [NonSerialized] public PlayerMovState playerState = PlayerMovState.NormalMov;
    void MovStateMachine()
    {
        switch (playerState)
        {
            case PlayerMovState.NormalMov:
                playerController.lockMove = false;
                InteractionManCode.canInteract = true;
                return;
            case PlayerMovState.FreezeMov:
                playerController.lockMove = true;
                InteractionManCode.canInteract = false;
                return;
        }
    }
    
    [NonSerialized] public CameraState cameraState = CameraState.normalCam;
    public enum CameraState
    {
        normalCam,
        FreezeCam,
        Diary
    }
    
    void CamStateMachine()
    {
        switch (cameraState)
        {
            case CameraState.normalCam:
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                playerController.lockCamMove = false;
                return;
            case CameraState.FreezeCam:
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                playerController.lockCamMove = true;
                return;
            case CameraState.Diary :
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                playerController.lockCamMove = true;
                return;
        }
    }

    private void FixedUpdate()
    {
        CamStateMachine();
        MovStateMachine();
    }
}
