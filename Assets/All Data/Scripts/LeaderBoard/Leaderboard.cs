using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;

public class Leaderboard : MonoBehaviour
{
    public int ID;
    public bool upload = false;
    public bool isInternetAvailable = false;

    public delegate void OnLeaderboardUpdate(LootLockerLeaderboardMember[] members);
    public static event OnLeaderboardUpdate onLeaderboardUpdate;
    void Start()
    {
        LootLockerSDKManager.StartGuestSession((response)=> 
        {
            if(response.success)
            {
                Debug.Log("Session started");
                isInternetAvailable = true;
            }
            else
            {
                Debug.Log("Session failed");
                isInternetAvailable = false;
            }
        });
    }

    void OnEnable()
    {
        ScoreManagement.scoreUpdated += SubmitScore;
    }

    void OnDisable()
    {
        ScoreManagement.scoreUpdated -= SubmitScore;
    }

    /// <summary>
    /// This is called when the score is updated.
    /// </summary>
    /// <param name="_currectScore"></param>
    public void SubmitScore(int _currectScore)
    {
        if(!isInternetAvailable) return;
        LootLockerSDKManager.SubmitScore(GameData._instance.userDetails.userName, _currectScore, ID, (response) => 
        {
            if(response.success)
            {
                Debug.Log("Score submitted");
            }
            else
            {
                Debug.Log("Score failed");
            }
        });
    }

    /// <summary>
    /// This is called to get all the scores
    /// </summary>
    public void FetchLeaderboardData()
    {
        if(!isInternetAvailable) return;
        LootLockerSDKManager.GetScoreListMain(ID,100,0, (response) => 
        {
            if(response.success)
            {
                LootLockerLeaderboardMember[] members = response.items;
               if(onLeaderboardUpdate != null)
                {
                    onLeaderboardUpdate(members);
               }
            }
        });
    }
}