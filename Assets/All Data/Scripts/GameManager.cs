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
        AllQuestion._instance.GetAllQuestion();
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
        AllQuestion._instance.currectQuestionNumber = number;
        testInformation.question.text = "<color=yellow>Q."+(GenerateNumber.allNumber.Count+1)+"</color> "+AllQuestion._instance.dataContainer[number].question;
        testInformation.optionA.text = "A. "+AllQuestion._instance.dataContainer[number].optionA;
        testInformation.optionB.text = "B. "+AllQuestion._instance.dataContainer[number].optionB;
        testInformation.optionC.text = "C. "+AllQuestion._instance.dataContainer[number].optionC;
        testInformation.optionD.text = "D. "+AllQuestion._instance.dataContainer[number].optionD;
    }
}