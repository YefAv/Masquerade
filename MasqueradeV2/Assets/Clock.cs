using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    Text timeText;
    
    void Start()
    {
        timeText = GetComponent<Text>();
    }
    void Update()
    {
        Format();
    }
    void Format()
    {
        float preTime = LightingManager.lighting.GameHour;

        float hourTime = (int)preTime % 24;

        float minTime = ((preTime - hourTime) * 60) % 60;

        string time = hourTime.ToString("00") + ":" + minTime.ToString("00");
        timeText.text = time;
    }
}
