using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Utility;

public class ScoreController : Singleton<ScoreController>
{
    public TextMeshProUGUI[] ScoreBoardLabels;

    public int currentScore;
    public int scorePerKill = 50;
    public int scorePerArrowHit = 25;
    public int scoreMultShortRange = 1;
    public int scoreMultMidRange = 2;
    public int scoreMultLongRange = 3;
    public float midDistance;
    public float longDistance;


    private void Start()
    {
        currentScore = 0;

        UpdateScoreBoard();
    }

    private void UpdateScoreBoard()
    {
        for (int i = 0; i < ScoreBoardLabels.Length; i++)
        {
            ScoreBoardLabels[i].text = currentScore.ToString();
        }
    }

    public void AddScoreFromArrowHit(float distanceFromPlayer)
    {
        if (distanceFromPlayer <= midDistance)
        {
            currentScore += scorePerArrowHit * scoreMultShortRange;
        }
        else if (distanceFromPlayer > midDistance && distanceFromPlayer <= longDistance)
        {
            currentScore += scorePerArrowHit * scoreMultMidRange;
        }
        else if (distanceFromPlayer > longDistance)
        {
            currentScore += scorePerArrowHit * scoreMultLongRange;
        }

        UpdateScoreBoard();
    }
    
    public void AddScoreFromKillbox()
    {
        currentScore += scorePerKill;

        UpdateScoreBoard();
    }
}
