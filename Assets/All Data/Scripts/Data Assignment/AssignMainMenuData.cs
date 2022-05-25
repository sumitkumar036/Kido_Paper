using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AssignMainMenuData : MonoBehaviour
{
    
    public TMP_Dropdown dropDown;
    public TMP_InputField nameField;

    public Image characterImage;

    public void SetData()
    {
        AllQuestion._instance.SetUserData(dropDown, nameField);
    }
}
