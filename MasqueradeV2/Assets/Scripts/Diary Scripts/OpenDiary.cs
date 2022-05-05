using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class OpenDiary : MonoBehaviour
{
    // TEMPORAL
    [SerializeField] GameObject diary;
    public GameObject diaryHudCanv;
    [SerializeField] PageManager pageManager;

    [SerializeField] AudioMixerSnapshot paused, inGame;
    [SerializeField] GameObject pistas;
    SavedData data;
    public static OpenDiary openDiaryCode;
    private AudioSource audio;
    private HintsZoom[] zoomCodes = new HintsZoom[6];

    [NonSerialized] public bool usability = true;

    #region MyRegion

    private void Awake()
    {
        openDiaryCode = this;
    }

    #endregion
    
    private void Start()
    {
        data = SaveTrigger.saveTrigger.saveData;
        //audio = this.gameObject.transform.GetChild(2).GetComponent<AudioSource>();
    }
    void Update()
    {
        //if (!Input.GetKeyDown(KeyCode.Tab))//!Input.GetButtonDown("Cancel"))
        //    return;
        //else
        //{
        //    if (diary.activeSelf)
        //    {
        //        Close();
        //    }
        //    else if(PlayerStateMachine.playerStateMachine.playerState == PlayerStateMachine.PlayerState.NormalMov)
        //    {
        //        Open();
        //    }

        //}
        if(Input.GetKeyDown(KeyCode.Tab) && usability == true)
        {
            if (diary.activeSelf)
            {
                Close();
            }
            else
            {
                Open();
            }
        }
    }

    public void Open()
    {
        diary.SetActive(true); //dirio obj
        diaryHudCanv.SetActive(false); //diario chiquito abajo izq 
        TimeSysN.timeSys.tiempoCorriendo = false; // Parar el tiempo   ==== SE MUEVE DEL NUEVO BRAIN
        pageManager.OpenDiary(); // guarda personajes y los visualiza
        //audio.Play(); a solucionar 
        

        //PlayerStateMachine.playerStateMachine.playerState = PlayerStateMachine.PlayerState.Diary; // modo tieso    ==== SE MUEVE DEL NUEVO BRAIN
        Brain._brain.CambiarEstado(Brain.EstadosDeJuego.diario);
        
        for (int i = 0; i < data.clueNotes.Count; i++)
        {
            pistas.transform.GetChild(data.clueNotes[i]).gameObject.SetActive(true);
        }
        paused.TransitionTo(0.1f); // ni idea

    }
    

    public void Close()
    {
        diary.SetActive(false);
        TimeSysN.timeSys.tiempoCorriendo = true; //  SE MUEVE DEL NUEVO BRAIN
        diaryHudCanv.SetActive(true);

        Brain._brain.CambiarEstado(Brain.EstadosDeJuego.normal); //  SE MUEVE DEL NUEVO BRAIN

        inGame.TransitionTo(0.1f);
    }
}
