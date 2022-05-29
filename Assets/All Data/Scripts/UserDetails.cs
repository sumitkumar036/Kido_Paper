using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum TestType
{
    Easy,
    Medium,
    Hard
}

[System.Serializable]
public class UserDetails
{
    public      string       userName;
    public      TestType     levelType;
    public      int          userScore;
    public      string       userIconURL;
}
