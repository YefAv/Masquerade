using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Fungus;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class TimeSystem : MonoBehaviour
{
    [SerializeField] public float timeNum;
    public bool runningTime;
    private bool canNotStop;
    [SerializeField] public int timeBell;
    [SerializeField] public float loopDuration; // 80
    private AudioSource bellAud;
    public int day_ = 1;
    public MonoBehaviour saveData;
    [NonSerialized] public SavedData saveCode;
    public static TimeSystem timeSyst;
    private bool firstBell = false;
    [SerializeField] private VideoPlayer vidPlayerEnd;
    [SerializeField] private GameObject vidCanvas, bellCamera;
    [SerializeField] private BellRingAnim _bellRingAnim;
    

    [SerializeField] bool reset_;
    [SerializeField] bool elQueDejeEstoEnBuildEsTombo;

    //Save try
    string saveSlot;

    #region Singleton y mas:v
    private void Awake()
    {
        if (timeSyst != null)
            Destroy(gameObject);
        else
            timeSyst = this;

        saveCode = saveData.gameObject.GetComponent<SavedData>();
    }
    #endregion

    private void Start()
    {
        saveSlot = SaveManager.LoadSlot_();

        if (!reset_)
            Load_();
        else
        {
            saveCode.day = 1; // temporal en realidad es 1
            Save_();
        }
            
        
        bellAud = gameObject.GetComponent<AudioSource>();
        
    }
    
    private void Update()
    {
        MovingTime();
        CountingBells();
    }

    private void MovingTime()
    {
        if (runningTime)
        {
            timeNum += Time.deltaTime;
        }
    }

    private void CountingBells()
    {
        if (!(timeNum > loopDuration)) return;
        timeNum = 0;
        timeBell++;
        _bellRingAnim.bellRing(); //                                      ==Dispara animación de la Campana==
        StartCoroutine(ActivateNDeactivateCamera()); //             ==Activa camara de Campana==
        FungusReactions.fungusCode.FirstBellText(saveCode.firstBell); //  ==Pregunta por primer monologo primera campana==
        bellAud.Play(); //                                                ==Suena la campana==
        saveCode.firstBell = true;
        Save_();
        //ciclo._cicloCode.checkTimeAtDay();

        if (timeBell <= 2) return;
        Debug.Log("Reset del ciclo");
        Debug.Log("Recargar escena");
        day_++;
        timeBell = 0;
        timeNum = 0;
        Save_();
        Invoke("PlayLastAnimatic",4);
        Invoke("reloadTheScene",9);
        //SceneManager.LoadScene("SernaPuzzles");
    }

    void PlayLastAnimatic()
    {
        vidPlayerEnd.gameObject.SetActive(true);
        vidCanvas.SetActive(true);
        vidPlayerEnd.Play();
    }

    /*private void SkipNextBell()
    {
        if(timeBell>2) return;
        timeBell++;
        //bellAud.Play();
        timeNum = 0;
    }*/

    void reloadTheScene()
    {
        SceneManager.LoadScene("SernaPuzzles");
    }
    
    void FungusFirstBell()
    {
        FungusReactions.fungusCode.FirstBellText(firstBell);
    }

    //no se en donde poner esta verga tengo mucha zz
    void Save_()
    {
        SaveManager.Save(saveData, saveSlot);
    }

    void Load_()
    {
        SaveManager.Load(saveData, saveSlot);
    }

    public int CheckDay()
    {
        return saveCode.day;
    }

    IEnumerator ActivateNDeactivateCamera()
    {
        bellCamera.SetActive(true);
        yield return new WaitForSeconds(4);
        bellCamera.SetActive(false);
    }
    
    
}
