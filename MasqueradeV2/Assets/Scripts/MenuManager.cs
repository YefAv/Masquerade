using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    [SerializeField] string mainSceneName;
    [SerializeField] GameObject menu, inicial;
    //GameObject menu;
    public enum IStates
    {
        On,
        Off,
    }
    public IStates states = IStates.Off;
    //void State()
    //{
    //    try { 
    //    menu = GameObject.FindGameObjectWithTag("Menu");
    //    }
    //    catch(System.Exception e) { Debug.Log(e); }
    //}

    void Update()
    {
       if(menu != null) { 
       if(Input.GetKeyDown(KeyCode.E) && states == IStates.Off)
        {
            if(inicial != null) inicial.SetActive(false);
            menu.SetActive(true);
            states = IStates.On;
        }
       else if (Input.GetKeyDown(KeyCode.E) && states == IStates.On)
        {
                if (inicial != null) inicial.SetActive(true);
                menu.SetActive(false);
            states = IStates.Off;
        }
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
       SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

}
