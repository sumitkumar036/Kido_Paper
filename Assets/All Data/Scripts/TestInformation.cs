using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TestInformation : MonoBehaviour
{
    [Header("Test Information")]
    public TextMeshProUGUI questionType;
    public TextMeshProUGUI remainingTime;
    
    [Header("User Information")]
    public TextMeshProUGUI name;
    public Image           userImage;

    [Header("Question Information")]
    public TextMeshProUGUI question;
    public TextMeshProUGUI optionA;
    public TextMeshProUGUI optionB;
    public TextMeshProUGUI optionC;
    public TextMeshProUGUI optionD;
}
