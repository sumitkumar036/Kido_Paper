using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AssignMainMenuData : MonoBehaviour
{

    public TMP_Dropdown dropDown; // Dropdown for selecting level type
    public TMP_InputField nameField; // Input field for user name

    public string userIconURL; // Image for character icon

    void OnEnable()
    {
        CharacterButtonClicked.buttonIsClicked += CharacterAssignment; //Subscribing to event when character is being selected
    }

    void OnDisable()
    {
        CharacterButtonClicked.buttonIsClicked -= CharacterAssignment; //Subscribing to event when character is being selected
    }

    void CharacterAssignment(Sprite useless, string url)
    {
        this.userIconURL = url;
    }

    /// <summary>
    /// This is assigning the user selected data to scriptableObject.
    /// </summary>
    public void SetData()
    {
        GameData._instance.SetUserData(dropDown, nameField, userIconURL);
        //  Debug.Log(dropDown.value);
        //   Debug.Log(nameField.text);
        // Debug.Log(userIconURL);
    }
}
