using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTrigger : MonoBehaviour
{
    public SavedData saveData;

    #region Singleton

    public static SaveTrigger saveTrigger;

    private void Start()
    {
        if (saveTrigger != null)
            Destroy(gameObject);
        else
            saveTrigger = this;
    }

    #endregion

    // metodos de savemanager

    public void conteoDias()
    {
        saveData.day++;
        SaveManager.Save(saveData, SaveManager.LoadSlot_());
    }

    public void Guardar()
    {
        SaveManager.Save(saveData, SaveManager.LoadSlot_());
    }

    public void Cargar()
    {
        SaveManager.Load(saveData,SaveManager.LoadSlot_());
    }
    

    //Metodo cargar pendiente
}
