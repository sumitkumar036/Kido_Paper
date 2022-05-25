using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NextQuestion : MonoBehaviour
{
    public Button nextButton;

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
        AnswerSelected.onButtonClick += WhenAnswerIsSelected;
    }

    void OnDisable()
    {
        AnswerSelected.onButtonClick += WhenAnswerIsSelected;
    }

    public void WhenNextClicked()
    {
        nextButton.interactable = false;
        if(nextQuestionIsClicked != null)
        {
            nextQuestionIsClicked(false);
        }
    }

    public void WhenAnswerIsSelected(TextMeshProUGUI useless)
    {
        nextButton.interactable= true;
    }
}
