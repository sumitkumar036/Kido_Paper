using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AllDataReferences : MonoBehaviour
{
    [Header("Test Information")]
    public TextMeshProUGUI questionType;
    public TextMeshProUGUI remainingTime;
    public TextMeshProUGUI totalQuestion;

    [Header("User Information")]
    public TextMeshProUGUI name;
    public Image userImage;

    [Header("Question Information")]
    public TextMeshProUGUI question;
    public TextMeshProUGUI optionA;
    public TextMeshProUGUI optionB;
    public TextMeshProUGUI optionC;
    public TextMeshProUGUI optionD;
    public Button nextQuestionButton;
    public GameObject questionPanel;
    public Button[] allQuestionButtons;

    [Header("User Input")]
    public TextMeshProUGUI nameField; //user name field
    public TextMeshProUGUI levelType; //user level type field

    [Header("When Finish")]
    public GameObject whenFinish;
    public TextMeshProUGUI finishMessage;
}
