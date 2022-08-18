using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{

    public void Quit()
    {
#if (UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_ANDROID || UNITY_IOS)
        Application.Quit();
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
