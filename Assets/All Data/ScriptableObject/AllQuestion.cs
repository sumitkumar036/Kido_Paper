using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "AllQuestion", menuName = "AllQuestion/CreateData", order = 1)]
public class AllQuestion : ScriptableObject
{
   public int currectQuestionNumber;
   public UserDetails userDetails;
   public DataContainer[] dataContainer;
   private string dataPath;

   public static AllQuestion _instance = null;
   public void CreateInstance()
   {
       if(_instance == null)
       {
           _instance = this;
       }
       else
       {
           Destroy(this);
       }
   }

   public void GetAllQuestion()
   {
       dataPath = Application.dataPath + "/StreamingAssets/Questions.json";
       dataContainer = JsonHelper.FromJson<DataContainer>(File.ReadAllText (dataPath));
   }


   public void SetUserData(TMP_Dropdown dropDown, TMP_InputField nameField)
   {
       userDetails.userName = nameField.text;
       userDetails.levelType = (TestType)dropDown.value;
   }
}
