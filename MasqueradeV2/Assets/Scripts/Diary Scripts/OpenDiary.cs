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
        data = TimeSystem.timeSyst.saveCode;
        audio = this.gameObject.transform.GetChild(2).GetComponent<AudioSource>();
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
            else if (PlayerStateMachine.playerStateMachine.playerState == PlayerStateMachine.PlayerState.NormalMov)
            {
                Open();
            }
        }
    }

    public void Open()
    {
        diary.SetActive(true); //dirio obj
        diaryHudCanv.SetActive(false); //diario chiquito abajo izq 
        TimeSystem.timeSyst.runningTime = false; // Parar el tiempo
        pageManager.OpenDiary(); // guarda personajes y los visualiza
        audio.Play();


        PlayerStateMachine.playerStateMachine.playerState = PlayerStateMachine.PlayerState.Diary; // modo tieso

        for (int i = 0; i < data.clueNotes.Count; i++)
        {
            pistas.transform.GetChild(data.clueNotes[i]).gameObject.SetActive(true);
        }
        paused.TransitionTo(0.1f); // ni idea

    }

    public void Close()
    {
        diary.SetActive(false);
        TimeSystem.timeSyst.runningTime = true;
        diaryHudCanv.SetActive(true);

        PlayerStateMachine.playerStateMachine.playerState = PlayerStateMachine.PlayerState.NormalMov;

        inGame.TransitionTo(0.1f);
        TimeSystem.timeSyst.runningTime = true;
    }

    public void MisionCumplida()
    {
        gameObject.transform.GetChild(3).gameObject.SetActive(true);
        Wait();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4);
        gameObject.transform.GetChild(3).gameObject.SetActive(false);
    }
}
