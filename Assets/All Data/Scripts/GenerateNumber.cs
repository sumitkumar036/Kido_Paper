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
   
    /// <summary>
    /// This is to generate number to get question
    /// </summary>
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

    /// <summary>
    /// This is used to generate number at particular range
    /// </summary>
    /// <param name="min">Minimum number</param>
    /// <param name="max">Maximum number</param>
    /// <returns></returns>
    public int Generate(int min, int max)
    {
        if(uniqueNumber != null)
            uniqueNumber(Random.Range(min, max));
        
        return Random.Range(min, max);
    }

}
