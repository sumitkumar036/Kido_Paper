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
    public TestInformation testInformation;

    void Start()
    {
        GameData._instance.GetAllQuestion();
    }

    void OnEnable()
    {
        GenerateNumber.uniqueNumber += DisplayTestData; //Subscribing to the event of GenerateNumber class
    }

    void OnDisable()
    {
        GenerateNumber.uniqueNumber -= DisplayTestData; //Unsubscribing to the event of GenerateNumber class
    }

    /// <summary>
    /// This is to Display Test Data form json to text field
    /// </summary>
    /// <param name="number">Generated Number</param>
    public void DisplayTestData(int number)
    {
        testInformation.totalQuestion.text = "<color=yellow>Question : " + (GenerateNumber.allNumber.Count + 1) + "</color> / " + GameData._instance.dataContainer.Length;
        GameData._instance.currectQuestionNumber = number;
        testInformation.question.text = "<color=yellow>Q." + (GenerateNumber.allNumber.Count + 1) + "</color> " + GameData._instance.dataContainer[number].question;
        testInformation.optionA.text = "A." + GameData._instance.dataContainer[number].optionA;
        testInformation.optionB.text = "B." + GameData._instance.dataContainer[number].optionB;
        testInformation.optionC.text = "C." + GameData._instance.dataContainer[number].optionC;
        testInformation.optionD.text = "D." + GameData._instance.dataContainer[number].optionD;
    }
}