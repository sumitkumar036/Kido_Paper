using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateInstance : MonoBehaviour
{
    public GameData gameData; // All question data
    
    void Awake()
    {
        gameData.CreateInstance(); // Creating instance of all question data ACCESS FROM OTHER CLASSES
        gameData.userDetails.userName = "";
        gameData.userDetails.userIconURL = "";

    }
}
