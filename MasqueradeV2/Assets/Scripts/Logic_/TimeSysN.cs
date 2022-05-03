using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSysN : MonoBehaviour
{
    [NonSerialized] public bool tiempoCorriendo;
    public uint duracionLoop;
    private uint contadorCampanas;
    [SerializeField] private float tiempo;
    [SerializeField] private AudioSource campanaSonido;
    [SerializeField] private GameObject camaraCampanada;
    [SerializeField] private BellRingAnim _bellRingAnim;
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
            SaveTrigger.saveTrigger.Guardar(); // guarda
            _bellRingAnim.bellRing(); // animación
            StartCoroutine(ActivarYDesactivarCamara());
            //texto primera campanada del juego  ////// fungus reaction texto campana
            campanaSonido.Play();
            // ????? bool primera campana?????
            
            if (contadorCampanas > 2)
            {
                ReinicioEscena();
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
        //Dispara cinematica de reinicio
        yield return new WaitForSeconds(5);
        //recargar escena
    }
    
}
