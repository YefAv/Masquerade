using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    Camera cam;
    public float zoomDuration = 1f;
    public float defaultFov, defaultSensitivity;
    CameraControl camMovement;
    public Transform camTransform;
    public Transform npcHead;

    private void Awake()
    {
        cam = Camera.main.GetComponent<Camera>();
        defaultFov = cam.fieldOfView;
        camTransform = cam.transform;
        camMovement = cam.GetComponent<CameraControl>();
        defaultSensitivity = camMovement.mouseSensivity;
    }

    public void CameraZooming(float targetFov, float targetSensitivity)
    {
        cam.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, targetFov, zoomDuration);
        camMovement.mouseSensivity = targetSensitivity;
        camTransform.LookAt(npcHead);
    }
}
