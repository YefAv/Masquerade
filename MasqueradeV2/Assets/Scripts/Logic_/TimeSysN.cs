using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class TimeSysN : MonoBehaviour
{
    [NonSerialized] public bool tiempoCorriendo;
    public uint duracionLoop;
    private uint contadorCampanas;
    [SerializeField] private float tiempo;
    [SerializeField] private AudioSource campanaSonido;
    [SerializeField] private GameObject camaraCampanada;
    [SerializeField] private BellRingAnim _bellRingAnim;
    [SerializeField] private VideoPlayer vidPlayerEnd;
    [SerializeField] private GameObject vidCanvas;
    public static TimeSysN timeSys;

    #region Singleton

    private void Start()
    {
        timeSys = this;
    }

    #endregion
    
    private void Update()
    {
        if (Brain._brain.tiempoNormal)
        {
            ContandoTiempo();
            Campanadas();
        }
        else
        {
            //algun sistema re loco de tiempo más lento y sin campanadas
        }
    }

    void ContandoTiempo()
    {
        if (tiempoCorriendo)
            tiempo += Time.deltaTime;
    }

    private void Campanadas()
    {
        if (tiempo > duracionLoop)
        {
            contadorCampanas++;
            tiempo = 0;
            _bellRingAnim.bellRing(); // animación
            StartCoroutine(ActivarYDesactivarCamara());
            FungusReactions.fungusCode.FirstBellText(SaveTrigger.saveTrigger.saveData.firstBell);
            campanaSonido.Play();
            SaveTrigger.saveTrigger.saveData.firstBell = true;
            SaveTrigger.saveTrigger.Guardar(); // guarda
            
            if (contadorCampanas > 2)
            {
                StartCoroutine(ReinicioEscena());
            }
        }
    }

    IEnumerator ActivarYDesactivarCamara()
    {
        Brain._brain.CambiarEstado(Brain.EstadosDeJuego.cinematica);
        camaraCampanada.SetActive(true);
        yield return new WaitForSeconds(4);
        camaraCampanada.SetActive(false);
        Brain._brain.CambiarEstado(Brain.EstadosDeJuego.normal);
    }



    IEnumerator ReinicioEscena()
    {
        Brain._brain.CambiarEstado(Brain.EstadosDeJuego.cinematica);
        SaveTrigger.saveTrigger.conteoDias(); // esto suma un día y guarda
        yield return new WaitForSeconds(4);
        vidPlayerEnd.gameObject.SetActive(true);
        vidCanvas.SetActive(true);
        vidPlayerEnd.Play();
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("SernaPuzzles");
    }
    
}
