using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AssignMainMenuData : MonoBehaviour
{
    
    public TMP_Dropdown dropDown; // Dropdown for selecting level type
    public TMP_InputField nameField; // Input field for user name

    public Image characterImage; // Image for character icon

    /// <summary>
    /// This is assigning the user selected data to scriptableObject.
    /// </summary>
    public void SetData()
    {
        AllQuestion._instance.SetUserData(dropDown, nameField);
    }
}
