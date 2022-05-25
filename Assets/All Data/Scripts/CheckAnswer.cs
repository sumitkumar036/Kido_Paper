using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckAnswer : MonoBehaviour
{
    public Button[] allButtons;
    public string correctAnswer;

    public delegate void AnswerChecked();
    public static AnswerChecked answerChecked;

    void OnEnable()
    {
        AnswerSelected.onButtonClick += Check;
        GenerateNumber.uniqueNumber += ResetColor;
    }

    void OnDisable()
    {
        AnswerSelected.onButtonClick -= Check;
        GenerateNumber.uniqueNumber -= ResetColor;
    }

    public void Check(TextMeshProUGUI optionSelected)
    {
        WhenButtonClicked();
        correctAnswer = AllQuestion._instance.dataContainer[AllQuestion._instance.currectQuestionNumber].correctAnswer;
        if(SplitString(optionSelected.text).Equals(correctAnswer))
        {
            optionSelected.color = Color.green;
        }
        else
        {
            IfWrongThenShowRight(optionSelected);
        }

        if(answerChecked != null) answerChecked();
    }

    
    public void IfWrongThenShowRight(TextMeshProUGUI optionSelected)
    {
        for(int i = 0; i< allButtons.Length; i++)
        {
            if(SplitString(allButtons[i].GetComponentInChildren<TextMeshProUGUI>().text).Equals(correctAnswer))
            {
              allButtons[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.green;
            }
        }
        optionSelected.color = Color.red;
    }
    
    public void WhenButtonClicked()
    {
        for(int i = 0; i< allButtons.Length; i++)
        {
            allButtons[i].interactable = false;
            allButtons[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        }
    }

    public void ResetColor(int useless)
    {
        for(int i = 0; i< allButtons.Length; i++)
        {
            allButtons[i].interactable = true;
            allButtons[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        }
    }


    public string SplitString(string option)
    {
        string[] splitArray =  option.Split(char.Parse(" "));
        return splitArray[1];
    }
}

