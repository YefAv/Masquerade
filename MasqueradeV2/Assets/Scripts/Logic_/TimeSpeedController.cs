using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TimeSpeedController : MonoBehaviour
{
    [NonSerialized] public List<GameObject> movingObjects = new List<GameObject>();
    [NonSerialized] public static TimeSpeedController TSpeedCode;

    #region Singleton

    private void Awake()
    {
        TSpeedCode = this;
    }

    #endregion

    // Cada objeto que se mueve debería de inscribirse a esta lista en su awake o start para hacer este tipo de control
    
    private void OnTriggerEnter(Collider other)
    {
        //Falta añadir el el trigger de qué tipo de collider debería activarlo
        foreach (GameObject go in movingObjects)
        {
            // Encontrar su componente de velocidad o playback time y REDUCIRLO

            switch (go.tag)
            {
                case "NPC":
                    break;
                case "Prop":
                    break;
                case "cualquier hpta caso":
                    break;
            }
            
            // Ésta podría ser la manera de encontrar y diferenciar esas velocidades
            // Aunque el switch podría cambiarse a un metodo que pida como argumento la velocidad o un multiplicador
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Falta añadir el el trigger de qué tipo de collider debería activarlo
        foreach (GameObject go in movingObjects)
        {
            // Encontrar su componente de velocidad o playback time y AUMENTARLO
            
            // Acá es lo mismo de arriba pero claramente con el respectivo orden que necesite
        }
    }
}
