using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class InternetConnectivity : MonoBehaviour
{
    public static bool isInternetAvailable = false;
    public static InternetConnectivity _instance = null;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        CheckConnectivity();
    }

    /// <summary>
    /// This is to check internet connectivity
    /// </summary>
    public void CheckConnectivity()
    {
        StartCoroutine(CheckInternetConnection());
    }
    IEnumerator CheckInternetConnection()
    {
        UnityWebRequest request = new UnityWebRequest("http://google.com");
        yield return request.SendWebRequest();
        if (request.error != null)
        {
           // Debug.Log("No Internet");
            isInternetAvailable = false;

        }
        else
        {
           // Debug.Log("Internet Available");
            isInternetAvailable = true;
        }
    }
}
