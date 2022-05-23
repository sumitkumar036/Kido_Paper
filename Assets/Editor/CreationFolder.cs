using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class CreationFolder : MonoBehaviour
{
    [MenuItem("MR SINGH/Create Folder")]
    static void CreateFolder()
    {
        AssetDatabase.CreateFolder("Assets", "All Data");
        AssetDatabase.CreateFolder("Assets/All Data", "Scenes");
        AssetDatabase.CreateFolder("Assets/All Data", "Scripts");
        AssetDatabase.CreateFolder("Assets/All Data", "ScriptableObject");
        AssetDatabase.CreateFolder("Assets/All Data", "AudioClips");
        AssetDatabase.CreateFolder("Assets/All Data", "VideoClips");
        AssetDatabase.CreateFolder("Assets/All Data", "JSON");

        
    }
}
