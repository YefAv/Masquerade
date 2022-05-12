using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemnt : MonoBehaviour
{
    //
    [NonSerialized]
    public bool lock_;
    //
    CharacterController chController;
    public float movementSpeed;

    float walkMovementSpeed;
    float runMovementSpeed;
    private float stepsTimeWalking;
    private float stepsTimeRunning;

    float jumpForce = 0.1f; //0.045f
    float movementY;

    bool isGrounded_;
    bool airNow;
    [SerializeField] private GameObject sayDialogBox;

    private float stepsTime =0.69f;
    [SerializeReference] private float timeToStep, timeToBobing;
    [SerializeField] private AudioSource stepsAudSource;
    private bool headDown;
    [SerializeField] private Transform cameraObj;
    [SerializeField] private Transform[] headBobPositions;
    [NonSerialized] public float horiInput;
    [NonSerialized] public float vertInput;

    private void Start()
    {
        chController = GetComponent<CharacterController>();
        runMovementSpeed = movementSpeed * 2.2f;
        walkMovementSpeed = movementSpeed;
        stepsTimeRunning = stepsTime / 2.2f;
        stepsTimeWalking = stepsTime;
    }

    private void Update()
    {
        MovementStateMachine();
    }

    void OtherPlayerMovement()
    {
        horiInput = Input.GetAxisRaw("Horizontal");
        vertInput = Input.GetAxisRaw("Vertical");
    }

    void PlayerMovement()
    {
        horiInput = Input.GetAxisRaw("Horizontal");
        vertInput = Input.GetAxisRaw("Vertical");

        if (horiInput != 0 || vertInput != 0)
        {
            stepsSFX();
        }

        Vector3 forwardMovement;
        Vector3 rightMovement;

        if (isGrounded_)
        {
            forwardMovement = transform.forward * vertInput;
            rightMovement = transform.right * horiInput;

            if (Input.GetButtonDown("Jump")&& !sayDialogBox.activeSelf)
            {
                movementY = jumpForce;
                airNow = true;
            }
            else
                airNow = false;
        }
        else
        {
            forwardMovement = transform.forward * vertInput / 5;
            rightMovement = transform.right * horiInput / 5;
            if (airNow)
            {
                movementY = 0;
                airNow = false;
            }
            else
                movementY -= 0.3f * Time.deltaTime;
        }

        Vector3 totalMovement = (forwardMovement + rightMovement).normalized * movementSpeed * Time.deltaTime;
        totalMovement.y = movementY;

        chController.Move(totalMovement);
    }

    void stepsSFX()
    {
        
        stepsTime += Time.deltaTime;
        if (stepsTime > timeToStep && isGrounded_)
        {
            stepsTime = 0;
            stepsAudSource.Play(); // Se puede crear una librería de audios de pisadas
            headBob();
        }
        
        
    }
    
    void headBob()
    {
        headDown = !headDown;
        if (headDown)
        {
            cameraObj.position = Vector3.Lerp(cameraObj.position, headBobPositions[0].position, timeToBobing);
        }
        else
        {
            cameraObj.position = Vector3.Lerp(cameraObj.position, headBobPositions[1].position, timeToBobing);
        }
    }
    
    //
    private void OnTriggerEnter(Collider other)
    {
        groudCheck(other, true);
    }
    private void OnTriggerStay(Collider other)
    {
        groudCheck(other, true);
    }
    private void OnTriggerExit(Collider other)
    {
        groudCheck(other, false);
    }
    //
    void groudCheck(Collider collider, bool a)
    {
        if (!collider.isTrigger && collider.gameObject.layer == 11)
        {
            isGrounded_ = a;
        }
    }

    private void MovementStateMachine()
    {
        switch (lock_)
        {
            case true:
                return;
            
            case false:
                PlayerMovement();
                if(Input.GetKeyDown(KeyCode.LeftShift))
                {
                    movementSpeed = runMovementSpeed;
                    timeToStep = stepsTimeRunning;
                }

                if(Input.GetKeyUp(KeyCode.LeftShift))
                {
                    movementSpeed = walkMovementSpeed;
                    timeToStep =stepsTimeWalking;
                }
                return;
        }
    }
}
