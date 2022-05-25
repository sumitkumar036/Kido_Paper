using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using UnityEngine;
public class ConvertToJson : MonoBehaviour
{
    public DataContainer[] data;
    public UserInfo[] datas;
    public string json, dataPath;

    public void Start()
    {
        dataPath = Application.dataPath + "/StreamingAssets/Questions.json"; //Json file path
        ConvertJson();
    }

    /// <summary>
    /// This is to Convert Json to DataContainer array
    /// </summary>
    public void ConvertJson()
    {
        datas = new UserInfo[data.Length];
        for(int i = 0; i< data.Length; i++)
        {
            datas[i] = new UserInfo();
            datas[i].question = data[i].question;
            datas[i].optionA = data[i].optionA;
            datas[i].optionB = data[i].optionB;
            datas[i].optionC = data[i].optionC;
            datas[i].optionD = data[i].optionD;
            datas[i].correctAnswer = data[i].correctAnswer;
        }
        json = JsonHelper.ToJson(datas, true);
        File.WriteAllText(dataPath, json);
    }
}

[System.Serializable]
public class UserInfo
{
    public string question;
    public string optionA;
    public string optionB;
    public string optionC;
    public string optionD;
    public string correctAnswer;
}