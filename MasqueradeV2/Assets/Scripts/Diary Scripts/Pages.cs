using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Pages 
{
    private Image drawing;
    private Text caption;
    private int indexPage;
    // private Camera camera;         //Aqui va el mapa xd

    public Pages() { }
    public Pages(Image image, Text description, int numberPage)
    {
        Drawing = image;
        Caption = description;
        IndexPage = numberPage; 
    } public Pages(Image image, Text description)
    {
        Drawing = image;
        Caption = description;
    }
   
    public Image Drawing { get => drawing; set => drawing = value; }
    public Text Caption { get => caption; set => caption = value; }
    public int IndexPage { get => indexPage; set => indexPage = value; }
}
