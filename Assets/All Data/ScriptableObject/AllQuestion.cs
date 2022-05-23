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

   public void GetAllQuestion()
   {
       dataPath = Application.dataPath + "/StreamingAssets/Questions.json";
       dataContainer = JsonHelper.FromJson<DataContainer>(File.ReadAllText (dataPath));
   }
}
