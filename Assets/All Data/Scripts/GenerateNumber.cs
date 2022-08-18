using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateNumber : MonoBehaviour
{
    public int number;
    public static List<int> allNumber = new List<int>();

    public int maxNumber;

    public delegate void UniqueNumber(int number);
    public static UniqueNumber uniqueNumber;
    public TextMeshProUGUI _text;

    void Awake()
    {
        allNumber.Clear();
    }

    void Start()
    {
        maxNumber = GameData._instance.dataContainer.Length;
        GenerateRandomNumber();
    }

    /// ========================================================================================================================
    ///                             GENERATE RANDOM NUMBER
    /// ========================================================================================================================
    /// 
    /// <summary>
    /// This is to generate number to get question
    /// </summary>
    public void GenerateRandomNumber()
    {
        if (allNumber.Count >= maxNumber)
        {
            return;
        }

        number = Generate(0, maxNumber);
        while (allNumber.Contains(number))
        {
            number = Generate(0, maxNumber);
        }


        allNumber.Add(number);
        uniqueNumber(number);
        _text.text += number + " ";
    }

    /// ========================================================================================================================
    ///                             GENERATE NUMBER FUNCTION
    /// ========================================================================================================================
    /// <summary>
    /// This is used to generate number at particular range
    /// </summary>
    /// <param name="min">Minimum number</param>
    /// <param name="max">Maximum number</param>
    /// <returns></returns>
    public int Generate(int min, int max)
    {
        if (uniqueNumber != null)
            uniqueNumber(Random.Range(min, max));

        return Random.Range(min, max);
    }

}
