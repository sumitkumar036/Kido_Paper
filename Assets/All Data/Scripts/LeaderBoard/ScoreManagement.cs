using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagement : MonoBehaviour
{
    public int totalScore; // Total score of the player
    public int totalCorrect; // Total correct answers of the player
    public int singleCorrectScore = 10; // Score for correct answer

    public delegate void ScoreUpdated(int score);
    public static ScoreUpdated scoreUpdated; // Delegate to be called when score is updated

    void OnEnable()
    {
        CheckAnswer.whenCorrect += WhenCorrectAnswer; // Subscribing delegate in order to add score
    }

    void OnDisable()
    {
        CheckAnswer.whenCorrect -= WhenCorrectAnswer; // Unsubscribing delegate in order to add score
    }

    void WhenCorrectAnswer()
    {
        totalCorrect += 1; // Adding 1 to total correct answer
        totalScore = totalCorrect * singleCorrectScore;

        if(scoreUpdated != null) scoreUpdated(totalScore); // Calling delegate to update score
        GameData._instance.userDetails.userScore = totalScore; // Updating score in user details
    }
}
