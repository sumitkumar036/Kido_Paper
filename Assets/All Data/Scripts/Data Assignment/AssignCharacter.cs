using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignCharacter : MonoBehaviour
{
    public Image characterImage;

    void OnEnable()
    {
        CharacterButtonClicked.buttonIsClicked += CharacterAssignment; //Subscribing to event when character is being selected
    }

    void OnDisable()
    {
        CharacterButtonClicked.buttonIsClicked -= CharacterAssignment;//Unsubscribing to event when character is being selected
    }

    /// <summary>
    /// This is to assing the selected character to icon
    /// </summary>
    /// <param name="sprite">Selected character sprite</param>
    public void CharacterAssignment(Sprite sprite)
    {
        characterImage.sprite = sprite;
    }

}
