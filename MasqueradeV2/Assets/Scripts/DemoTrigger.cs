using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoTrigger : MonoBehaviour
{
    public static DemoTrigger demoTrigger;
    [SerializeField] private GameObject EndDemo;

    private void Awake()
    {
        demoTrigger = this;
    }

    public IEnumerator EndDemoCoroutine()
    {
        EndDemo.SetActive(true);
        Brain._brain.CambiarEstado(Brain.EstadosDeJuego.cinematica);
        yield return new WaitForSeconds(10);
        Brain._brain.CambiarEstado(Brain.EstadosDeJuego.diario);
        SceneManager.LoadScene("Menu Inicial");
    }
}
