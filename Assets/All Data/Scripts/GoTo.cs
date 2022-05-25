using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoTo : MonoBehaviour
{

    /// <summary>
    /// This is for changing scene
    /// </summary>
    /// <param name="SceneNumber">sceneName to be changed to</param>
    public void ChangeScene(string SceneNumber)
    {
        SceneManager.LoadScene(SceneNumber);
    }
}
