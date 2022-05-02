using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMove : MonoBehaviour
{
    private Rigidbody rg;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float normalSpeed, stepTimeWalking, jumpForce;
    [SerializeField] private Transform feetTrans, cameraTrans;
    private float runningSpeed, stepTimeRunning, speed, timeToStep, stepTime, xRot;
    private Vector3 playerMovementInput;
    private Vector2 playerMouseInput;
    private bool grounded;
    public float sensibilidadCam;
    private float yAxisClamp;
    [NonSerialized] public bool lockMove;
    [SerializeField] private GameObject sayDialogBox;

    Vector3 MoveVector = new Vector3();
    Vector3 airMoveVector = new Vector3();

    Vector3 temp;

    private void Start()
    {
        rg = GetComponent<Rigidbody>();
        runningSpeed = normalSpeed * 2.2f;
        stepTimeRunning = stepTimeWalking * 2.2f;
        speed = normalSpeed;
        timeToStep = stepTimeWalking;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        cameraState = CameraState.normalCam;
    }

    void FixedUpdate()
    {
        playerMovementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        playerMouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        cursorCamStateMachine();
        MovementStateMachine();
        
        if (Physics.CheckSphere(new Vector3(feetTrans.position.x, feetTrans.position.y + 0.15f, feetTrans.position.z), 0.4f, groundMask))
            grounded = true;
        else
            grounded = false;
    }

    private void Update()
    {
        //cursorCamStateMachine();
        //MovementStateMachine();

        if (playerMovementInput.x != 0 || playerMovementInput.z !=0)
        {
            StepEffect();
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runningSpeed;
            timeToStep = stepTimeRunning;
        }
        
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = normalSpeed;
            timeToStep = stepTimeWalking;
        }
        
    }

    private void MovePlayer()
    {


        if (grounded)
        {
            MoveVector = transform.TransformDirection(playerMovementInput) * speed;

            if (Input.GetKey(KeyCode.Space) && !sayDialogBox.activeSelf)
            {
                rg.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            rg.velocity = new Vector3(MoveVector.x, rg.velocity.y, MoveVector.z);

        }
        else //soy el mas capito
        {
            //inercia horizontal
            airMoveVector = transform.TransformDirection(playerMovementInput) * speed / 2;

            if (airMoveVector.magnitude > 0)
            {
                if (airMoveVector.magnitude < MoveVector.magnitude)
                {
                    MoveVector = MoveVector - (MoveVector * 2 * Time.deltaTime); //0.5 es que tan rapido desacelera en el aire 
                }
                else
                {
                    MoveVector = airMoveVector;
                }
                rg.velocity = new Vector3(MoveVector.x, rg.velocity.y, MoveVector.z);
            }
            else
            {
                temp = new Vector3(rg.velocity.x, 0, rg.velocity.z);
                if (temp.magnitude > 0)
                {
                    temp -= temp * 2 * Time.deltaTime;
                }
                rg.velocity = new Vector3(temp.x, rg.velocity.y, temp.x);
            }
        }

    }

    void CamControl()
    {
        yAxisClamp += playerMouseInput.y * sensibilidadCam;

        if (yAxisClamp > 90)
        {
            yAxisClamp = 90;
            playerMouseInput.y = 0;
        }
        else if (yAxisClamp < -90)
        {
            yAxisClamp = -90;
            playerMouseInput.y = 0;
        }

        // al toque mi rey

        xRot -= playerMouseInput.y * sensibilidadCam;

        transform.Rotate(0f, playerMouseInput.x * sensibilidadCam, 0f);
        cameraTrans.transform.localRotation=Quaternion.Euler(xRot,0f,0f);
        
    }

    void StepEffect()
    {
        stepTime += Time.deltaTime;
        if (stepTime > timeToStep && grounded)
        {
            stepTime = 0;
            //play audio
            headBob();
        }
    }

    void headBob()
    {
        
    }

    [NonSerialized] public CameraState cameraState = CameraState.cinematic;
    public enum CameraState
    {
        normalCam,
        cinematic,
        diary
    }
    
    void cursorCamStateMachine()
    {
        switch (cameraState)
        {
            case CameraState.normalCam:
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                //CameraRotation();
                CamControl();
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

    void MovementStateMachine()
    {
        if(lockMove) return;
        MovePlayer();
    }
}
