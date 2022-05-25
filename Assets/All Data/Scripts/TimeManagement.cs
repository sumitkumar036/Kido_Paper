using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TimeManagement : MonoBehaviour
{
    public TextMeshProUGUI remainingTime;

    public int hour, minute, second;
    public int conversionFactor =60;
    public bool startTimer = false;

    void Awake()
    {

    }

    void FixedUpdate()
    {
        if(startTimer)
        {
           CalculateTime();
        }
    }

    public void CalculateTime()
    {
        second -=1;
        if(hour >= 0 && minute >= 0 && second >= 0)
        {
           // second -= Time.deltaTime;
           // remainingTime.text = hour.ToString() +" : "+minute.ToString() +" : "+second.ToString();
        }
        else if(hour >= 0 && minute >= 0 && second <= conversionFactor)
        {
           // minute -= Time.deltaTime;
           // second = conversionFactor;
           // remainingTime.text = hour.ToString() +" : "+minute.ToString() +" : "+second.ToString();
        }
    }


    // void DisplayTime(float timeToDisplay)
    // {
    //     float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
    //     float seconds = Mathf.FloorToInt(timeToDisplay % 60);
    // }
}
