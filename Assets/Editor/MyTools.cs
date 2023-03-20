using UnityEngine;
using UnityEditor;

public static class MyTools
{

    [MenuItem("My Tools/1. Add Defaults To Report %F1")]
    static void DEV_AppendDefaultsToReport()
    {
        for (var i = 0; i < Leaderboard._instance.members.Length; i++)
        {
            CSVManager.AppendToReport(
                new string[4] {
                "#" + Leaderboard._instance.members[i].rank,
                Leaderboard._instance.members[i].member_id,
                Leaderboard._instance.members[i].score.ToString(),
                "Try Hard",
                }
            );
        }
        EditorApplication.Beep();
        Debug.Log("<color=green>Report updated successfully!</color>");
    }

    [MenuItem("My Tools/2. Reset Report %F12")]
    static void DEV_ResetReport()
    {
        CSVManager.CreateReport();
        EditorApplication.Beep();
        Debug.Log("<color=orange>The report has been reset...</color>");
    }

}
