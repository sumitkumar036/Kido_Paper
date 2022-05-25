using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowUserData : MonoBehaviour
{
    public  TextMeshProUGUI nameField; //user name field
    public TextMeshProUGUI levelType; //user level type field

    void Awake()
    {
        if(AllQuestion._instance != null)
        {
            nameField.text = "<color=yellow>Name  : </color>"+AllQuestion._instance.userDetails.userName;
            levelType.text = "<color=yellow>Level : </color>"+AllQuestion._instance.userDetails.levelType.ToString();
        }
    }
}
