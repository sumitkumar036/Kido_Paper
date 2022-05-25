using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateCharacter : MonoBehaviour
{
    public GameObject characterPrefab;
    public List<Sprite> allCharacters = new List<Sprite>();
    public int characterNumber;
    void Awake()
    {
        CharacterIntantiate();
    }
    
    /// <summary>
    /// This is for Instantiating character on runTime
    /// </summary>
    public void CharacterIntantiate()
    {
        for(int i= 0;i < allCharacters.Count; i++)
        {
            GameObject obj = Instantiate(characterPrefab, characterPrefab.transform.position, Quaternion.identity);
            obj.transform.SetParent(this.transform);
            obj.transform.localScale = new Vector3(1,1,1);
            obj.GetComponent<CharacterButtonClicked>().characterImage.sprite = allCharacters[i];
        }
    }
}
