using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonAnimation : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    public GameObject animationObject;
    private float newSize;
    public bool stopAnimation;

    void Awake()
    {
        newSize = 1.025f;
    }
  

    void OnEnable()
    {
        PlayPauseAnimation.stopAnimation += StopAnimatingThis;
        NextQuestion.nextQuestionIsClicked += StopAnimatingThis;
    }

    void OnDisable()
    {
        PlayPauseAnimation.stopAnimation -= StopAnimatingThis;
        NextQuestion.nextQuestionIsClicked -= StopAnimatingThis;
    }

    public void StopAnimatingThis(bool status)
    {
        stopAnimation = status;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {  
        if(stopAnimation) return;
        animationObject.transform.localScale = new Vector3(newSize, newSize, newSize);
    }
 
    public void OnPointerExit(PointerEventData eventData)
    {   if(stopAnimation) return;
        animationObject.transform.localScale = new Vector3(1, 1, 1);
    }
}
