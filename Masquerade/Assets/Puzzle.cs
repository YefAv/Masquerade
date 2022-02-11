using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public List<Sprite> ficha = new List<Sprite>();
    public GameObject ficha2;
    public GameObject borde;

    public Sprite fichaVaciaImg;

    //int indexfichaVacia;
    GameObject fichaVacia;
    int numCostado;
    //Vector2 posFichaVacia;
    GameObject padreFichas;
    GameObject padreBorde;
    List<Vector3> posicionesIniciales = new List<Vector3>();
    GameObject[] _fichas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
