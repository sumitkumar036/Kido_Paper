using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class SingleAudioSource : MonoBehaviour
{
    public AudioSource audioSource; //AudioSource to be played

    public AudioClip selection, correct, wrong, clap, ops, keyboard;
    public static SingleAudioSource _instance = null; //Instance of this class

    void Awake()
    {
        if (_instance == null)
            _instance = this;
        else if (_instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
