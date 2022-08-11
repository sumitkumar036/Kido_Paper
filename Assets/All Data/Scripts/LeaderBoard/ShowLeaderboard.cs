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

    public void DestroyPrevRecord()
    {
        for (int i = 0; i < boardData.Count; i++)
        {
            Destroy(boardData[i]);
        }
        boardData.Clear();
    }


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

        Debug.Log(InternetConnectivity.isInternetAvailable);
    }

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
