using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;
public enum QuestionFrom
{
    StreamingAsset,
    GoogleDrive
}

[CreateAssetMenu(fileName = "GameData", menuName = "GameData/CreateData", order = 1)]
public class GameData : ScriptableObject
{
    public int currectQuestionNumber;
    public UserDetails userDetails;
    public DataContainer[] dataContainer;
    [HideInInspector] public string dataPath;
    [HideInInspector] public string _questionURL;
    public static GameData _instance = null;
    public QuestionFrom questionFrom;
    public void CreateInstance()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    /// <summary>
    /// This is to GetAllQuestion from the Json file created.
    /// </summary>
    public void GetAllQuestion()
    {
        if (questionFrom == QuestionFrom.StreamingAsset)
        {
            dataPath = Application.streamingAssetsPath + "/Questions.json";
            dataContainer = JsonHelper.FromJson<DataContainer>(File.ReadAllText(dataPath));
        }
        else if (questionFrom == QuestionFrom.GoogleDrive)
        {
            dataContainer = JsonHelper.FromJson<DataContainer>(dataPath);
        }


    }
    /// <summary>
    /// This is to Set User Information
    /// </summary>
    /// <param name="dropDown">Level type</param>
    /// <param name="nameField">user name</param>
    public void SetUserData(TMP_Dropdown dropDown, TMP_InputField nameField, string _userIconURL, TMP_Dropdown questionField)
    {
        userDetails = new UserDetails();
        userDetails.levelType = (TestType)dropDown.value;
        userDetails.userName = nameField.text;
        userDetails.userIconURL = _userIconURL;
        questionFrom = (QuestionFrom)questionField.value;
    }


    public void ResetData()
    {
        userDetails.userIconURL = null;
        userDetails.userName = null;

        dataContainer = new DataContainer[0];
    }
}
