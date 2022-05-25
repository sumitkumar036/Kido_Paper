using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckAnswer : MonoBehaviour
{
    public Button[] allButtons; //Total available button or option
    public string correctAnswer;//Correct answer

    public delegate void AnswerChecked();
    public static AnswerChecked answerChecked;

    void OnEnable()
    {
        AnswerSelected.onButtonClick += Check; //Subscribing delegate in order to check answer
        GenerateNumber.uniqueNumber += ResetColor; //Subscribing delegate in order to reset color of button
    }

    void OnDisable()
    {
        AnswerSelected.onButtonClick -= Check; //Unsubscribing delegate in order to check answer
        GenerateNumber.uniqueNumber -= ResetColor; //Unsubscribing delegate in order to reset color of button
    }


    /// <summary>
    /// This is to check answer is correct or not
    /// </summary>
    /// <param name="optionSelected">Selected answer</param>
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

    /// <summary>
    /// This is to show the correct answer if wrong is selected
    /// </summary>
    /// <param name="optionSelected">answer selected</param>    
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
    

    /// <summary>
    /// This is called when option is selected
    /// </summary>
    public void WhenButtonClicked()
    {
        for(int i = 0; i< allButtons.Length; i++)
        {
            allButtons[i].interactable = false;
            allButtons[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        }
    }

    /// <summary>
    /// This is to reset the color of the option if next question is selected
    /// </summary>
    /// <param name="useless"></param>
    public void ResetColor(int useless)
    {
        for(int i = 0; i< allButtons.Length; i++)
        {
            allButtons[i].interactable = true;
            allButtons[i].GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        }
    }

    /// <summary>
    /// This is used to split the string based on our requirement
    /// </summary>
    /// <param name="option"></param>
    /// <returns></returns>
    public string SplitString(string option)
    {
        string[] splitArray =  option.Split(char.Parse(" "));
        return splitArray[1];
    }
}

