using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonAnimation : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    public GameObject animationObject; //GameObject ro be animnated
    private float newSize; //Increased size of the object
    public bool stopAnimation; //Stop animation CONDITION

    void Awake()
    {
        newSize = 1.025f;
    }
  

    void OnEnable()
    {
        PlayPauseAnimation.stopAnimation += StopAnimatingThis; //Subscribing delegate in order to playPause animation
        NextQuestion.nextQuestionIsClicked += StopAnimatingThis; //Sudscribing delegate when nextQuestion is called
    }

    void OnDisable()
    {
        PlayPauseAnimation.stopAnimation -= StopAnimatingThis; //Unsubscribing delegate in order to playPause animation
        NextQuestion.nextQuestionIsClicked -= StopAnimatingThis; //Unsubscribing delegate when nextQuestion is called
    }

    /// <summary>
    /// This is toi play and pause animation (Hovering animation)
    /// </summary>
    /// <param name="status">bool condition</param>
    public void StopAnimatingThis(bool status)
    {
        stopAnimation = status;
    }

    /// <summary>
    /// This is called when user point over current gameObject
    /// </summary>
    /// <param name="eventData">EventData</param>
    public void OnPointerEnter(PointerEventData eventData)
    {  
        if(stopAnimation) return;
        animationObject.transform.localScale = new Vector3(newSize, newSize, newSize);
    }
 
    /// <summary>
    ///  This is called when user point out of current gameObject
    /// </summary>
    /// <param name="eventData"> EventData </param>
    public void OnPointerExit(PointerEventData eventData)
    {   if(stopAnimation) return;
        animationObject.transform.localScale = new Vector3(1, 1, 1);
    }
}
