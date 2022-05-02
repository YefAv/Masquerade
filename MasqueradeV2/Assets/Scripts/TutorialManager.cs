using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    private List<GameObject> eventos = new List<GameObject>();
    [SerializeField] private GameObject folleto;
    private int c=0;
    private string letra;
    private bool w, a, s, d, m, completas;
    private GameObject  teclas, mouse;
    private bool inicio = true;
    void Start()
    {
        //folleto = GameObject.FindGameObjectWithTag("Folleto").gameObject;
        teclas = GameObject.FindGameObjectWithTag("keys").gameObject;
        mouse = GameObject.FindGameObjectWithTag("mouse").gameObject;
        

        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            eventos.Add(this.gameObject.transform.GetChild(i).gameObject);
        }
    }

    void Update()
    {
        if (inicio) PrimerEvento();
        if (completas == true && c==0)
        {
            inicio = false;
            Invoke("SegundoEvento", 1f);
        }
        if (folleto.GetComponent<Folleto>().seleccionado == true && inicio == false && c == 0)
        {
            folleto.SetActive(false);
            c = 1;
            //GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.FindGameObjectWithTag("spawpoi").transform.position;
            Invoke("TercerEvento",0.5f);
        }
        if (Input.GetKeyDown(KeyCode.Tab) && c == 1)
        {
            eventos[2].SetActive(false);
            eventos[3].SetActive(true);
            Invoke("Desaparecer", 3);
        }
    }
    
//    void Brain(int a)
//    {
//#pragma warning disable CS0162 
//        for (int i = a; i < gameObject.transform.childCount - 1; i++)
//#pragma warning restore CS0162 
//        {
//           eventos[i].SetActive(false);
//           eventos[i+1].SetActive(true);
//           break;
//        }
//    }

    void PrimerEvento()
    {
        letra = Input.inputString.ToUpper();
        switch (letra)
        {
            case "W":
                w = true;
                teclas.transform.GetChild(0).GetComponent<Animator>().SetTrigger("W");
                //Debug.Log("Presionaste: " + letra);
                break; 
            case "A":
               // Debug.Log("Presionaste: " + letra);
                a = true;
                teclas.transform.GetChild(1).GetComponent<Animator>().SetTrigger("a");
                break; 
            case "S":
               // Debug.Log("Presionaste: " + letra);
                s = true;
                teclas.transform.GetChild(2).GetComponent<Animator>().SetTrigger("s");
                break;
            case "D":
               // Debug.Log("Presionaste: " + letra);
                d = true;
                teclas.transform.GetChild(3).GetComponent<Animator>().SetTrigger("d");
                break;
        }
        if (Input.GetAxisRaw("Mouse X") != 0){ mouse.GetComponent<Animator>().SetTrigger("Moving"); m = true; }

        if (w && a && s && d && m) completas = true;
    }

    void SegundoEvento()
    {
        eventos[0].SetActive(false);
        eventos[1].SetActive(true);
        //folleto.SetActive(true);
    }

    void TercerEvento()
    {
        eventos[1].SetActive(false);
        eventos[2].SetActive(true);
        
    }

    void Desaparecer()
    {
        this.gameObject.SetActive(false);
        FungusReactions.fungusCode.FirstConversation();
    }

    public void startTutorial()
    {
        inicio = true;
    }

}
