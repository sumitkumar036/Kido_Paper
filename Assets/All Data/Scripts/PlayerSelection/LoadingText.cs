using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingText : MonoBehaviour
{
    public TextMeshProUGUI LoadingImageText;

    void OnEnable()
    {
        IsNetConnected(InternetConnectivity.isInternetAvailable);
    }

    public void IsNetConnected(bool isConnected)
    {
        if(isConnected)
        {
            
        }
        else
        {
            LoadingImageText.text = "No InternetrConnection";
        }
    }
}
