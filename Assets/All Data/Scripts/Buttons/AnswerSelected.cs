using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerSelected : MonoBehaviour
{
    public Button button; //Current button
    public TextMeshProUGUI optionSelected; //Option selected text
    
    public delegate void OnButtonClick(TextMeshProUGUI answer);
    public static OnButtonClick onButtonClick;

    void Start()
    {
        if(button == null) button = GetComponent<Button>();
        button.onClick.AddListener(()=> { ButtonIsClicked();});
    }

    /// <summary>
    /// This is called when user selet any option
    /// </summary>
    public void ButtonIsClicked()
    {
        if(onButtonClick != null) onButtonClick(optionSelected);
    }
}
