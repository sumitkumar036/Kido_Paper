using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateNumber : MonoBehaviour
{
    public int number;
    public static List<int> allNumber = new List<int>();

    public delegate void UniqueNumber(int number);
    public static UniqueNumber uniqueNumber;


    void Start()
    {
        GenerateRandomNumber();
    }
   
    public void GenerateRandomNumber()
    {
        number = Generate(0,11);
        if(allNumber.Count == 0)
        {
            allNumber.Add(number);
            return;
        } 

        if(allNumber.Contains(number))
        {
            number = Generate(0,11);
            Debug.Log("Same => " +number);
        }
        else
        {
            allNumber.Add(number);
            Debug.Log("Different => " +number);
        }
    }

    public int Generate(int min, int max)
    {
        if(uniqueNumber != null)
            uniqueNumber(Random.Range(min, max));
        
        return Random.Range(min, max);
    }

}
