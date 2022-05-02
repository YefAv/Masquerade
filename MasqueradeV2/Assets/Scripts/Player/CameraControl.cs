using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraControl : MonoBehaviour
{
    public enum CameraState
    {
        normalCam,
        cinematic,
        diary
    }

    [NonSerialized] public CameraState cameraState = CameraState.cinematic;
    
    public float mouseSensivity;
    float xAxisClamp = 0;
    public Transform playerBody;
    float mouseX;
    float mouseY;

    void Update()
    {
        cursorCamStateMachine();
    }

    void CameraRotation()
    {
        mouseX = Input.GetAxisRaw("Mouse X") * mouseSensivity * Time.deltaTime;
        mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensivity * Time.deltaTime;

        xAxisClamp += mouseY;

        if(xAxisClamp>90)
        {
            xAxisClamp = 90;
            mouseY = 0;
            ClampxAxisRotationToValue(270);
        }
        else if (xAxisClamp < -90)
        {
            xAxisClamp = -90;
            mouseY = 0;
            ClampxAxisRotationToValue(90);
        }

        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    void ClampxAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }

    void cursorCamStateMachine()
    {
        switch (cameraState)
        {
            case CameraState.normalCam:
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                CameraRotation();
                return;
            case CameraState.cinematic:
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                return;
            case CameraState.diary :
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                return;
        }
    }
}
