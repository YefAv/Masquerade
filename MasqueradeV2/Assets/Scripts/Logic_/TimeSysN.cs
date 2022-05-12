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
            FungusReactions.fungusCode.FirstBellText(SaveTrigger.saveTrigger.saveData.firstBell);
            SaveTrigger.saveTrigger.saveData.firstBell = true;
            SaveTrigger.saveTrigger.Guardar(); // guarda
            
            // esto debe de cambiar drasticamente
            switch (contadorCampanas)
            {
                case 0:
                    _bellRingAnim.bellRing(); // animación
                    StartCoroutine(ActivarYDesactivarCamara());
                    campanaSonido.Play();
                    break;
                case 1:
                    _bellRingAnim.bellRing(); // animación
                    campanaSonido.Play();
                    StartCoroutine(ActivarYDesactivarCamara());
                    break;
                    case 2: // SE ROMPE LA CAMPANA, REPITO SE ROMPE LA MALDITA CAMPANA
                        _bellRingAnim.bellRing(); // animación
                        StartCoroutine(ActivarYDesactivarCamara());
                        //campanaSonido.clip = otroClip;
                        campanaSonido.Play(); // ESTE SONIDO DEBE DE CAMBIAR
                        break;
                    case 3: // SE ROMPE EL RELOJ, REPITO, SE ROMPE EL HPTA RELOJ
                        _bellRingAnim.bellRing(); // animación 
                        StartCoroutine(ActivarYDesactivarCamara()); // ESTOS SI DEBEN DE CAMBIAR POR OTROS METODOS
                        campanaSonido.Play();
                        break;
            }
            
            //contadorCampanas++;
            //_bellRingAnim.bellRing(); // animación
            //StartCoroutine(ActivarYDesactivarCamara());
            //FungusReactions.fungusCode.FirstBellText(SaveTrigger.saveTrigger.saveData.firstBell);
            //campanaSonido.Play();
            //SaveTrigger.saveTrigger.saveData.firstBell = true;
            //SaveTrigger.saveTrigger.Guardar(); // guarda
            
            if (contadorCampanas > 2)
            {
                StartCoroutine(ReinicioEscena()); // EL TIMING DE ESTO DEBE DE CAMBIAR
            }
            
            tiempo = 0;
        }
    }

    IEnumerator ActivarYDesactivarCamara()
    {
        Brain._brain.CambiarEstado(Brain.EstadosDeJuego.cinematica);
        camaraCampanada.SetActive(true);
        yield return new WaitForSeconds(4);
        camaraCampanada.SetActive(false);
        Brain._brain.CambiarEstado(Brain.EstadosDeJuego.normal);
        Debug.Log("paso 1");
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
