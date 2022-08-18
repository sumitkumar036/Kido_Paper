using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenFinish : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.onFinish += WhenAllQUestionCompleted;
    }

    private void OnDisable()
    {
        GameManager.onFinish -= WhenAllQUestionCompleted;

    }
    public void WhenAllQUestionCompleted()
    {
        GameManager._instance.allDataReference.whenFinish.SetActive(true);
        GameManager._instance.allDataReference.finishMessage.text = "<color=green>!! Congratulation !! </color>" + "\n\n" + "<color=yellow>" + GameData._instance.userDetails.userName + "</color>" + " ! You have completed the paper." + "\n" +
                                                                    " Goto Leaderboard to see your Rank";
        GameManager._instance.allDataReference.questionPanel.SetActive(false);
    }
}