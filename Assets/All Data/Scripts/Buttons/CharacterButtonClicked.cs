using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButtonClicked : MonoBehaviour
{
    public Button button;
    public GameObject tickImage;
    public Image characterImage;
    public bool isMine = false;

    public delegate void ButtonIsClicked(Sprite sprite);
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

    public void IsThisMine(Sprite useless)
    {
        if(isMine)
         tickImage.SetActive(true);
         else tickImage.SetActive(false);
    }
    public void ButtonClicked()
    {
        isMine = true;
        if(buttonIsClicked != null) buttonIsClicked(characterImage.sprite);
        isMine = false;
    }
}
