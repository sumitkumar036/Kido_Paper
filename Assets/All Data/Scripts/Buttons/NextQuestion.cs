using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NextQuestion : MonoBehaviour
{
    public Button nextButton; //Next Question button

    public delegate void NextQuestionIsClicked(bool status);
    public static NextQuestionIsClicked nextQuestionIsClicked;

    void Awake()
    {
        nextButton.interactable = false;
    }

    void Start()
    {
        nextButton.onClick.AddListener(()=> {WhenNextClicked();});
    }

    void OnEnable()
    {
        AnswerSelected.onButtonClick += WhenAnswerIsSelected; //Subscribing delegate in order to know weather option selected or not
    }

    void OnDisable()
    {
        AnswerSelected.onButtonClick += WhenAnswerIsSelected; //Unsubscribing delegate in order to know weather option selected or not
    }

    /// <summary>
    /// This is for called when Next Queation button is clicked
    /// </summary>
    public void WhenNextClicked()
    {
        nextButton.interactable = false;
        if(nextQuestionIsClicked != null)
        {
            nextQuestionIsClicked(false);
        }
    }

    /// <summary>
    /// Thisis for called when answer is selected
    /// </summary>
    /// <param name="useless">not useful</param>
    public void WhenAnswerIsSelected(TextMeshProUGUI useless)
    {
        nextButton.interactable= true;
    }
}
