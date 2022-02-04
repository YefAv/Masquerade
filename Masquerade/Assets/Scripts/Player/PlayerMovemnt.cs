using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemnt : MonoBehaviour
{ 
    CharacterController chController;
    public float movementSpeed; // m/s
    float ActualSpeed;

    bool IsGrounded;
    float jumpForce = 0.038f;
    float movementY;

    private void Start()
    {
        chController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerMovement();

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            movementSpeed = movementSpeed * 2;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementSpeed = movementSpeed / 2;

        }
    }

    void PlayerMovement()
    {
        float horiInput = Input.GetAxisRaw("Horizontal");
        float vertInput = Input.GetAxisRaw("Vertical"); 

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horiInput;

        //Vector3.up* jumpForce;

        Vector3 totalMovement = (forwardMovement + rightMovement).normalized * movementSpeed * Time.deltaTime;

        if(Input.GetButtonDown("Jump") && chController.isGrounded)
        {
            movementY = jumpForce;
        }
        movementY -= 0.118f * Time.deltaTime;
        totalMovement.y = movementY;

        chController.Move(totalMovement);
        //Debug.Log(totalMovement);
    }
}
