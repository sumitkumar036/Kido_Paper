using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource; //AudioSource to be played
    public AudioClip selection, correct, wrong, clap, ops, keyboard; //AudioClip to be played
    [Range(0f, 1f)]
    public float volume = 1f; //Volume of the AudioClip

    void Start()
    {
        audioSource = SingleAudioSource._instance.audioSource; //Getting AudioSource component
        selection = SingleAudioSource._instance.selection; //Setting clip to be played
        correct = SingleAudioSource._instance.correct; //Setting clip to be played
        wrong = SingleAudioSource._instance.wrong; //Setting clip to be played
        clap = SingleAudioSource._instance.clap; //Setting clip to be played
        ops = SingleAudioSource._instance.ops; //Setting clip to be played
        keyboard = SingleAudioSource._instance.keyboard; //Setting clip to be played

    }

    void OnEnable()
    {
        CheckAnswer.whenCorrect += WhenCorrect;
        CheckAnswer.whenWrong += WhenWrong;
    }

    /// <summary>
    /// This is called when user select correct answer
    /// </summary>
    void WhenCorrect()
    {
        PlayAudioClip(clap);
        StartCoroutine(PlayClipAfterSomeTime(correct));
    }

    /// <summary>
    /// This is called when user select wrong answer
    /// </summary>
    void WhenWrong()
    {
        PlayAudioClip(ops);
        StartCoroutine(PlayClipAfterSomeTime(wrong));
    }

    /// <summary>
    /// This is called afterSometinme when user select correct answer
    /// </summary>
    /// <param name="_clip">audio clip</param>
    void PlayAudioClip(AudioClip _clip)
    {
        audioSource.clip = _clip;
        audioSource.Play(); 
    }

    /// <summary>
    /// This is called afterSomeTime when user select wrong answer
    /// </summary>
    /// <param name="_clip">audio clip</param>
    /// <returns></returns>
    IEnumerator PlayClipAfterSomeTime(AudioClip _clip)
    {
        yield return new WaitForSeconds(2.0f);
        PlayAudioClip(_clip);
    }
}
