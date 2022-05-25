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
        AnswerSelected.onButtonClick += AnimationControl;
    }

    void OnDisable()
    {
        AnswerSelected.onButtonClick -= AnimationControl;
    }

   public void AnimationControl(TextMeshProUGUI useless)
   {
       if(stopAnimation != null)
       {
            stopAnimation(true);
       }
   }
}
