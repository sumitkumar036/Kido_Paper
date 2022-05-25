using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowUserData : MonoBehaviour
{
    public  TextMeshProUGUI nameField;
    public TextMeshProUGUI levelType;

    void Awake()
    {
        if(AllQuestion._instance != null)
        {
            nameField.text = "<color=yellow>Name  : </color>"+AllQuestion._instance.userDetails.userName;
            levelType.text = "<color=yellow>Level : </color>"+AllQuestion._instance.userDetails.levelType.ToString();
        }
    }
}
