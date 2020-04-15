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

    private GameObject scorePopupPrefab;

    private void Start()
    {

        currentScore = 0;

        UpdateScoreBoard();
    }

    private void Awake()
    {
        scorePopupPrefab = (GameObject)Resources.Load("Prefab/ScorePopup", typeof(GameObject));
    }

    private void UpdateScoreBoard()
    {
        for (int i = 0; i < ScoreBoardLabels.Length; i++)
        {
            ScoreBoardLabels[i].text = currentScore.ToString();
        }
    }

    public void AddScoreFromArrowHit(float distanceFromPlayer, Vector3 position)
    {
        int scoreAdded = 0;

        if (distanceFromPlayer <= midDistance)
        {
            scoreAdded = scorePerArrowHit * scoreMultShortRange;
        }
        else if (distanceFromPlayer > midDistance && distanceFromPlayer <= longDistance)
        {
            scoreAdded = scorePerArrowHit * scoreMultMidRange;
        }
        else if (distanceFromPlayer > longDistance)
        {
            scoreAdded = scorePerArrowHit * scoreMultLongRange;
        }

        currentScore += scoreAdded;

        StartCoroutine(ScorePopup(scoreAdded, position));

        UpdateScoreBoard();
    }

    // give feedback for score added above enemy when it's hit by arrow
    private IEnumerator ScorePopup(int score, Vector3 position)
    {
        GameObject scorePopup = Instantiate(scorePopupPrefab);

        scorePopup.transform.position = new Vector3(position.x, position.y + 4f, position.z);
        scorePopup.GetComponent<TextMeshPro>().text = "+" + score.ToString();

        yield return new WaitForSeconds(2f);

        Destroy(scorePopup);
    }
    
    public void AddScoreFromKillbox()
    {
        currentScore += scorePerKill;

        UpdateScoreBoard();
    }
}
