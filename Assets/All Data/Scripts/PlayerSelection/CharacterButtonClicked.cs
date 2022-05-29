using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButtonClicked : MonoBehaviour
{
    public Button button; //Character selectionn button
    public GameObject tickImage; //If Selected tick image
    public Image characterImage; //Character image
    public bool isMine = false;

    public delegate void ButtonIsClicked(Sprite sprite, string userIconURL);
    public static ButtonIsClicked buttonIsClicked;

    void Start()
    {
        button.onClick.AddListener(()=> { ButtonClicked(); });
    }

    void OnEnable()
    {
        CharacterButtonClicked.buttonIsClicked += IsThisMine;
    }

    void OnDisable()
    {
        CharacterButtonClicked.buttonIsClicked -= IsThisMine;
    }

    /// <summary>
    /// This is to know weather selected character is Mine then other character will be deselected
    /// </summary>
    /// <param name="useless">not using</param>
    public void IsThisMine(Sprite useless, string uselessToo)
    {
        if(isMine)
        {
         tickImage.SetActive(true);
        }
         else tickImage.SetActive(false);
    }

    /// <summary>
    /// This is to whern button is clicked IsMine ia active and tick image of selected character will be activated
    /// </summary>
    public void ButtonClicked()
    {
        isMine = true;
        if(buttonIsClicked != null) buttonIsClicked(characterImage.sprite, GetComponent<LoadImageFromURL>().url);
      
        isMine = false;

    }
}
