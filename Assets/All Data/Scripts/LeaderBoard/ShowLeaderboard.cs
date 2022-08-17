using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;

public class ShowLeaderboard : MonoBehaviour
{
    public GameObject leaderBoard;
    public Transform parent;
    private LeaderBoardText leaderBoardText;

    public List<GameObject> boardData;

    public GameObject leaderBoardPanel;

    void OnEnable()
    {
        Leaderboard.onLeaderboardUpdate += GenerateLeaderboard;
        DestroyPrevRecord();
    }

    void OnDisable()
    {
        Leaderboard.onLeaderboardUpdate -= GenerateLeaderboard;
    }

    /// ========================================================================================================================
    ///                             GENERATE LEADERBOARD
    /// ========================================================================================================================
    /// 
    /// <summary>
    /// This is to generate leaderboard
    /// </summary>
    /// <param name="members">all member list played</param>
    public void GenerateLeaderboard(LootLockerLeaderboardMember[] members)
    {
        Debug.Log(members.Length);
        for (int i = 0; i < members.Length; i++)
        {
            GameObject obj = Instantiate(leaderBoard);
            obj.transform.SetParent(parent);
            obj.transform.localScale = new Vector3(1, 1, 1);
            boardData.Add(obj);
            leaderBoardText = obj.GetComponent<LeaderBoardText>();

            leaderBoardText.rank.text = "#" + members[i].rank.ToString() + "                " + members[i].member_id;
            leaderBoardText.score.text = members[i].score.ToString();
        }
    }

    /// ========================================================================================================================
    ///                             DESTROY PREVIOUS RECORD
    /// ========================================================================================================================
    /// 
    /// <summary>
    /// This is to destroy previous record
    /// </summary>
    public void DestroyPrevRecord()
    {
        for (int i = 0; i < boardData.Count; i++)
        {
            Destroy(boardData[i]);
        }
        boardData.Clear();
    }

    /// ========================================================================================================================
    ///                             SHOW LEADERBOARD
    /// ========================================================================================================================
    /// 
    /// <summary>
    /// This is to show all leaderboard data
    /// </summary>
    public void ShowLeaderBoard()
    {
        if (InternetConnectivity.isInternetAvailable)
        {
            leaderBoardPanel.SetActive(true);
        }
        else
        {
            InternetConnectivity._instance.CheckConnectivity();
            Invoke("CheckAgain", 1);
        }
    }

    /// ========================================================================================================================
    ///                             CHECK AGAIN
    /// ========================================================================================================================
    /// 
    /// <summary>
    /// This is to check internet connection again
    /// </summary>
    private void CheckAgain()
    {
        if (InternetConnectivity.isInternetAvailable)
        {
            leaderBoardPanel.SetActive(true);
        }
        else
        {
            InternetConnectivity._instance.CheckConnectivity();
        }
    }
}
