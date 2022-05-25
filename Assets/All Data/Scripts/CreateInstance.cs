using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateInstance : MonoBehaviour
{
    public AllQuestion allQuestion; // All question data
    
    void Awake()
    {
        allQuestion.CreateInstance(); // Creating instance of all question data ACCESS FROM OTHER CLASSES
    }
}
