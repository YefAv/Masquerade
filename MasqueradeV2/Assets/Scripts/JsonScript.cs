using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonScript : MonoBehaviour
{
    [System.Serializable]
    public class JSONScript 
    {
        public string tiempoVacio;
        public List<int> ordenPistas;
        public List<float> pistasTiempo;
        public List<GameObject> ordenNPCs;
        public List<float> tiempoNPCs;
        public float tiempoResolviendoPuzzles;
        public float tiempoHastaPrimerNPC;
        public float tiempoTodosNPCs;
        public float tiempoCompletandoMisiones;
        public float diarioAbierto;
    }
    //public JSONScript
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
