using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSerna : MonoBehaviour
{
    private bool started = false;
    public static TutorialSerna tutoSernaCode;
    [SerializeField] private PlayerMovemnt playerMoveCode;
    [SerializeField] private GameObject wasd, mouse, jumpBut, tabbut;
    private int count;

    #region Singleton

    private void Awake()
    {
        tutoSernaCode = this;
    }

    #endregion

    public void startTutorial()
    {
        started = true;
    }

    private void Update()
    {
        if (started)
        {
            //Display mouse
            mouse.SetActive(true);
            if (Input.GetAxisRaw("Mouse X") != 0)
            {
                //invoke apagar 
                Invoke("ApagarMouse",3);
                count++;
            }
            // Display WASD
            if (playerMoveCode.vertInput != 0 || playerMoveCode.horiInput != 0)
            {
                // invoke apagar WASD delayed
                Invoke("ApagarWASD",3);
                count++;
            }

            if (Input.GetKey(KeyCode.Tab))
            {
                //invoke apagar Tab
                Invoke("ApagarTab",3);
                count++;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                Invoke("ApagarSpace",3);
                count++;
            }

            if (count >= 3)
            {
                started = false;
                //ApagarTodo();
            }
        }
    }
    void ApagarMouse()
    {
        mouse.SetActive(false);
    }

    void ApagarWASD()
    {
        wasd.SetActive(false);
    }

    void ApagarTab()
    {
        tabbut.SetActive(false);
    }

    void ApagarSpace()
    {
        jumpBut.SetActive(false);
    }

    public void ApagarTodo()
    {
        ApagarMouse();
        ApagarSpace();
        ApagarTab();
        ApagarWASD();
        Destroy(gameObject);
    }
}
