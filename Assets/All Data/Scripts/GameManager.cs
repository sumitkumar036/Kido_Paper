using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Test Information")]
    public AllDataReferences allDataReference;

    public static GameManager _instance = null;
    public delegate void WhenCompleted();
    public static WhenCompleted onFinish;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }


    void Start()
    {
        GameData._instance.GetAllQuestion();

        if (GameData._instance != null)
        {
            allDataReference.nameField.text = "<color=yellow>Name  : </color>" + GameData._instance.userDetails.userName;
            allDataReference.levelType.text = "<color=yellow>Level : </color>" + GameData._instance.userDetails.levelType.ToString();
        }
    }

    void OnEnable()
    {
        GenerateNumber.uniqueNumber += DisplayTestData; //Subscribing to the event of GenerateNumber class
    }

    void OnDisable()
    {
        GenerateNumber.uniqueNumber -= DisplayTestData; //Unsubscribing to the event of GenerateNumber class
    }

    /// ========================================================================================================================
    ///                             DISPLAY ALL DATA
    /// ========================================================================================================================
    /// <summary>
    /// This is to Display Test Data form json to text field
    /// </summary>
    /// <param name="number">Generated Number</param>
    public void DisplayTestData(int number)
    {
        allDataReference.totalQuestion.text = "<color=yellow>Question : " + (GenerateNumber.allNumber.Count) + "</color> / " + GameData._instance.dataContainer.Length;
        GameData._instance.currectQuestionNumber = number;
        allDataReference.question.text = "<color=yellow>Q." + (GenerateNumber.allNumber.Count + 1) + "</color> " + GameData._instance.dataContainer[number].question;
        allDataReference.optionA.text = "A." + GameData._instance.dataContainer[number].optionA;
        allDataReference.optionB.text = "B." + GameData._instance.dataContainer[number].optionB;
        allDataReference.optionC.text = "C." + GameData._instance.dataContainer[number].optionC;
        allDataReference.optionD.text = "D." + GameData._instance.dataContainer[number].optionD;

    }

    public void Finished()
    {
        if (onFinish != null)
        {
            if (GenerateNumber.allNumber.Count == GameData._instance.dataContainer.Length) onFinish();
        }
    }

}