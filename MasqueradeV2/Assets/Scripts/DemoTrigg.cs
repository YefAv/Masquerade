using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoTrigg : MonoBehaviour
{
    public static DemoTrigg demotrigg;
    [SerializeField] private GameObject imagenDemo;

    private void Start()
    {
        demotrigg = this;
    }

    public IEnumerator DemoScreenTrigger()
    {
        imagenDemo.SetActive(true);
        Brain._brain.CambiarEstado(Brain.EstadosDeJuego.diario);
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Menu Inicial");
    }
}
