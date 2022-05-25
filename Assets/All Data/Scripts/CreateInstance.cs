using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateInstance : MonoBehaviour
{
    public AllQuestion allQuestion;
    
    void Awake()
    {
        allQuestion.CreateInstance();
    }
}
