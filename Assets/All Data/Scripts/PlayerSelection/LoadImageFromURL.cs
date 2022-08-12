using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Events;
public class LoadImageFromURL : MonoBehaviour
{
    public string url;
    private Texture2D downloadedTexture;
    public Image image;

    public bool isThisPlayerSelection;
    public UnityEvent WhenCompleted;


    void Start()
    {
        if (!isThisPlayerSelection)
        {
            if (!string.IsNullOrEmpty(GameData._instance.userDetails.userIconURL))
            {
                this.url = GameData._instance.userDetails.userIconURL;
            }
        }

        StartCoroutine(FetchImage(url));
    }


    IEnumerator FetchImage(string url)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
            downloadedTexture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        image.sprite = TextureToPng(downloadedTexture);
        WhenCompleted.Invoke();

    }

    public Sprite TextureToPng(Texture2D texture)
    {
        var bytes = texture.EncodeToPNG();
        Sprite sp = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(texture.width / 2, texture.height / 2));
        return sp;
    }
}
