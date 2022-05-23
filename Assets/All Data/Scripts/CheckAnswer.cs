using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckAnswer : MonoBehaviour
{

    public AllQuestion allQuestion;
    public Button[] allButtons; 

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
        if(optionSelected.text.Contains(allQuestion.dataContainer[allQuestion.currectQuestionNumber].correctAnswer))
        {
            optionSelected.color = Color.green;
        }
        else
        {
            optionSelected.color = Color.red;
        }

        if(answerChecked != null) answerChecked();

        Debug.Log(optionSelected.text);
        Debug.Log(allQuestion.dataContainer[allQuestion.currectQuestionNumber].correctAnswer);
    }

    
    public void WhenButtonClicked()
    {
        for(int i = 0; i< allButtons.Length; i++)
        {
            allButtons[i].interactable = false;
            allButtons[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
        }
    }

    public void ResetColor(int useless)
    {
        for(int i = 0; i< allButtons.Length; i++)
        {
            allButtons[i].interactable = true;
            allButtons[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
        }
    }
}
