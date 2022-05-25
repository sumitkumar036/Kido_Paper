using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignCharacter : MonoBehaviour
{
    public Image characterImage;

    void OnEnable()
    {
        CharacterButtonClicked.buttonIsClicked += CharacterAssignment;
    }

    void OnDisable()
    {
        CharacterButtonClicked.buttonIsClicked -= CharacterAssignment;
    }
    public void CharacterAssignment(Sprite sprite)
    {
        characterImage.sprite = sprite;
    }

}
