using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AudioPlay : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler
{
    public AudioClip clip; //AudioClip to be played
    [Range(0f, 1f)]
    public float volume = 1f; //Volume of the AudioClip

    AudioSource audioSource; //AudioSource to be played
    public bool onceDone = false;

 
    void Start()
    {
        audioSource = SingleAudioSource._instance.audioSource; //Getting AudioSource component
    }

    /// <summary>
    /// This is to play click sound as per the requirement
    /// </summary>
    /// <param name="_clip">clip to play</param>
    public void PlayAudioButtonClick(AudioClip _clip)
    {
        audioSource.volume = volume; //Setting volume of AudioSource
        audioSource.clip = _clip; //Setting clip to be played
        audioSource.Play(); //Playing clip
    }

    /// <summary>
    /// This is called when user point over current gameObject
    /// </summary>
    /// <param name="eventData">EventData</param>
    public void OnPointerEnter(PointerEventData eventData)
    {  
        if(onceDone) return;
        audioSource.volume = volume; //Setting volume of AudioSource
        audioSource.clip = clip; //Setting clip to be played
        audioSource.Play(); //Playing clip
        onceDone = true;
        
    }
 
    /// <summary>
    ///  This is called when user point out of current gameObject
    /// </summary>
    /// <param name="eventData"> EventData </param>
    public void OnPointerExit(PointerEventData eventData)
    { 
        if(onceDone) return;
        audioSource.volume = volume; //Setting volume of AudioSource
        audioSource.clip = clip; //Setting clip to be played
        audioSource.Pause(); //Pause clip
    }

    /// <summary>
    /// This is to play click sound when user click on current gameObject
    /// </summary>
    /// <param name="pointerEventData"></param>
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        audioSource.volume = volume; //Setting volume of AudioSource
        audioSource.clip = SingleAudioSource._instance.selection; //Setting clip to be played
        audioSource.Play(); //Pause clip
    }
}
