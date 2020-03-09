using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class RotatingEnemyController : Singleton<RotatingEnemyController>
{
    public Transform[] RotatingEnemies;
    public Transform[] EnemyStopPoints;

    public float AnimationTimeVeryEasy = 5f;
    public float AnimationTimeEasy;
    public float AnimationTimeNormal;
    public float AnimationTimeHard;
    public float AnimationTimeVeryHard;
    public float PauseTimeVeryEasy = 3f;
    public float PauseTimeEasy;
    public float PauseTimeNormal;
    public float PauseTimeHard;
    public float PauseTimeVeryHard;

    public int EnemiesAlive = 4;

    private Transform[] enemyDestination;

    private bool firstRotation = true;
    private bool cancelRotations;
    private float AnimationTime;
    private float PauseTime;

    void Start()
    {
        //StartRotations();
    }

    public void InitialSpawn()
    {
        for (int i = 0; i < RotatingEnemies.Length; i++)
        {
            //StartCoroutine(BasicAnimator.AnimateWorldPosition(RotatingEnemies[i], RotatingEnemies[i].position, EnemyStopPoints[i].position, 2F));
            RotatingEnemies[i].GetComponent<PatrollingChickenEnemy>().FadeIn();
        }
        Invoke("StartRotations", 2f);
    }

    public void StartRotations()
    {
        StartCoroutine(DelayStartRotations(1.5f));
    }

    private IEnumerator DelayStartRotations(float delay)
    {
        yield return new WaitForSeconds(delay);

        //InvokeRepeating("RotateEnemies", 0f, AnimationTime + PauseTime);
        cancelRotations = false;
        Invoke("RotateEnemies", 0f);
    }

    public void CancelRotations()
    {
        CancelInvoke();
        cancelRotations = true;
    }

    void RotateEnemies()
    {
        UpdateAnimationAndPauseTime();

        int i;
        for (i = 0; i < RotatingEnemies.Length - 1; i++)
        {
            if (RotatingEnemies[i] != null)
            {
                if (!firstRotation)
                {
                    // turn to face next destination (can make this a smooth animation later)
                    RotatingEnemies[i].Rotate(Vector3.up, -90, Space.World);
                }
                
                // move this enemy to the next position
                StartCoroutine(BasicAnimator.AnimateWorldPosition(RotatingEnemies[i], RotatingEnemies[i].position, EnemyStopPoints[i + 1].position, AnimationTime));
            }
        }
        if (RotatingEnemies[i] != null)
        {
            if (!firstRotation)
            {
                RotatingEnemies[i].Rotate(Vector3.up, -90, Space.World);
            }

            // if this is the last enemy in array, move it to the first position
            StartCoroutine(BasicAnimator.AnimateWorldPosition(RotatingEnemies[i], RotatingEnemies[i].position, EnemyStopPoints[0].position, AnimationTime, new System.Action(() =>
            {
                // restart the cycle if allowed
                if (!cancelRotations)
                {
                    Invoke("RotateEnemies", PauseTime);
                }
            })));
        }
        firstRotation = false;

        // rotate the end points for next pass
        Transform temp = EnemyStopPoints[0];
        for (i = 0; i < EnemyStopPoints.Length - 1; i++)
        {
            EnemyStopPoints[i] = EnemyStopPoints[i + 1];
        }
        EnemyStopPoints[i] = temp;
    }

    public void SpawnEnemies()
    {
        for (int i = 0; i < RotatingEnemies.Length; i++)
        {
            RotatingEnemies[i].gameObject.SetActive(true);
            RotatingEnemies[i].GetComponent<PatrollingChickenEnemy>().FadeIn();
        }
        EnemiesAlive = RotatingEnemies.Length;

        StartRotations();
    }

    public void OnEnemyDeath()
    {
        EnemiesAlive--;

        if (EnemiesAlive < 1)
        {
            GameStateController.Instance?.OnRotatingEnemiesCleared();
            CancelRotations();
        }
    }

    private void UpdateAnimationAndPauseTime()
    {
        switch (GameStateController.Instance?.GetCurrentDifficulty())
        {
            case Difficulty.veryEasy:
                AnimationTime = AnimationTimeVeryEasy;
                PauseTime = PauseTimeVeryEasy;

                break;
            case Difficulty.easy:
                AnimationTime = AnimationTimeEasy;
                PauseTime = PauseTimeEasy;

                break;
            case Difficulty.normal:
                AnimationTime = AnimationTimeNormal;
                PauseTime = PauseTimeNormal;

                break;
            case Difficulty.hard:
                AnimationTime = AnimationTimeHard;
                PauseTime = PauseTimeHard;

                break;
            case Difficulty.veryHard:
                AnimationTime = AnimationTimeVeryHard;
                PauseTime = PauseTimeVeryHard;

                break;
        }
    }
}
