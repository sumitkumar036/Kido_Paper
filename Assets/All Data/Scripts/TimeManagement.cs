using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TimeManagement : MonoBehaviour
{
    public TextMeshProUGUI remainingTime;

    public float hour, minute, second;
    public float speed;
    public bool startTimer = false;
    public const float ZERO = 0;
    public const float ONE = 1;
    public const float MAX = 59;


    void Update()
    {
        if(startTimer)
        {
           CalculateHour();
        }
    }


    public void CalculateHour()
    {
        second -= Time.deltaTime * speed;

        if(second <= ZERO)
        {
            minute -= ONE;
            second = MAX;
        }

        if(minute <= ZERO)
        {
            hour -= ONE;
            minute = MAX;
        }

        remainingTime.text = "<color=yellow>Time : </color>"+hour.ToString("00") + ":" + minute.ToString("00") + ":" + second.ToString("00");
    }
}
