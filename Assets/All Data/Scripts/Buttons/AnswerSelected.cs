using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerSelected : MonoBehaviour
{
    public Button button;
    public TextMeshProUGUI optionSelected;
    
    public delegate void OnButtonClick(TextMeshProUGUI answer);
    public static OnButtonClick onButtonClick;

    void Start()
    {
        if(button == null) button = GetComponent<Button>();
        button.onClick.AddListener(()=> { ButtonIsClicked();});
    }

    public void ButtonIsClicked()
    {
        if(onButtonClick != null) onButtonClick(optionSelected);
    }
}
