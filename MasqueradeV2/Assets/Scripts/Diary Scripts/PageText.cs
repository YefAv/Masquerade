using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageText : MonoBehaviour
{
    public Text previousText;
    void Start()
    {
        previousText = GetComponent<Text>();
        previousText.text = "";
    }

    public void AddText(string addedText)
    {
        previousText.text = $"{previousText.text} \n {addedText}";
    }
}
