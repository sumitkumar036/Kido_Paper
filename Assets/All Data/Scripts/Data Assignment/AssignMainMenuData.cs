using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class AssignMainMenuData : MonoBehaviour
{

    public TMP_Dropdown dropDown; // Dropdown for selecting level type
    public TMP_InputField nameField; // Input field for user name
    public TMP_Dropdown questionField; // Input field for question

    public string userIconURL; // Image for character icon

    private void Start()
    {
        StartCoroutine(GetText());
    }

    void OnEnable()
    {
        CharacterButtonClicked.buttonIsClicked += CharacterAssignment; //Subscribing to event when character is being selected
                                                                       // GameData._instance.ResetData();
    }

    void OnDisable()
    {
        CharacterButtonClicked.buttonIsClicked -= CharacterAssignment; //Subscribing to event when character is being selected
    }

    void CharacterAssignment(Sprite useless, string url)
    {
        this.userIconURL = url;
    }

    IEnumerator GetText()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(GameData._instance._questionURL))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                GameData._instance.dataPath = www.downloadHandler.text;
            }
        }
    }


    /// <summary>
    /// This is assigning the user selected data to ScriptableObject.
    /// </summary>
    public void SetData()
    {
        GameData._instance.SetUserData(dropDown, nameField, userIconURL, questionField);
    }

}
