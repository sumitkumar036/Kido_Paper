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


    [Header("All Questions")]
    public AllQuestion allQuestion;

    void Start()
    {
        allQuestion.GetAllQuestion();
    }

    void OnEnable()
    {
        GenerateNumber.uniqueNumber += DisplayTestData;
    }

    void OnDisable()
    {
        GenerateNumber.uniqueNumber -= DisplayTestData;
    }

    public void DisplayTestData(int number)
    {
        allQuestion.currectQuestionNumber = number;
        testInformation.question.text = "Q."+(GenerateNumber.allNumber.Count+1) +" "+allQuestion.dataContainer[number].question;
        testInformation.optionA.text = "A. "+allQuestion.dataContainer[number].optionA;
        testInformation.optionB.text = "B. "+allQuestion.dataContainer[number].optionB;
        testInformation.optionC.text = "C. "+allQuestion.dataContainer[number].optionC;
        testInformation.optionD.text = "D. "+allQuestion.dataContainer[number].optionD;
    }
}