using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayPauseAnimation : MonoBehaviour
{
    public delegate void StopAnimation(bool status);
    public static StopAnimation stopAnimation;


    void OnEnable()
    {
        AnswerSelected.onButtonClick += AnimationControl; //Subscribing delegate in order to know weather option selected or not
    }

    void OnDisable()
    {
        AnswerSelected.onButtonClick -= AnimationControl; //Unsubscribing delegate in order to know weather option selected or not
    }

    /// <summary>
    /// This is for controlling animation weather option hover will workj or not once option is selected
    /// </summary>
    /// <param name="useless"></param>
   public void AnimationControl(TextMeshProUGUI useless)
   {
       if(stopAnimation != null)
       {
            stopAnimation(true);
       }
   }
}
