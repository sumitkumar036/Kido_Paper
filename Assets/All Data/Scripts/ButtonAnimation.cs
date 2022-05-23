using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonAnimation : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    public GameObject animationObject;
    private float newSize;

    void Awake()
    {
        newSize = 1.15f;
    }
  
     public void OnPointerEnter(PointerEventData eventData)
    {  
        animationObject.transform.localScale = new Vector3(newSize, newSize, newSize);
    }
 
    public void OnPointerExit(PointerEventData eventData)
    {   
        animationObject.transform.localScale = new Vector3(1, 1, 1);
    }
}
