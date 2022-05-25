using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoTo : MonoBehaviour
{
    public void ChangeScene(string SceneNumber)
    {
        SceneManager.LoadScene(SceneNumber);
    }
}
