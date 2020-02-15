using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class RotatingEnemyController : MonoBehaviour
{
    public Transform[] RotatingEnemies;
    public Transform[] EnemyStopPoints;
    public float AnimationTime = 5f;
    public float PauseTime = 3f;

    private Transform[] enemyDestination;

    void Start()
    {
        StartRotations();
    }

    public void StartRotations()
    {
        InvokeRepeating("RotateEnemies", 0f, AnimationTime + PauseTime);
    }

    public void CancelRotations()
    {
        CancelInvoke();
    }

    void RotateEnemies()
    {
        int i;
        for (i = 0; i < RotatingEnemies.Length - 1; i++)
        {
            // move this enemy to the next position
            StartCoroutine(BasicAnimator.AnimateWorldPosition(RotatingEnemies[i], RotatingEnemies[i].position, EnemyStopPoints[i + 1].position, AnimationTime));
        }
        // if this is the last enemy in array, move it to the first position
        StartCoroutine(BasicAnimator.AnimateWorldPosition(RotatingEnemies[i], RotatingEnemies[i].position, EnemyStopPoints[0].position, AnimationTime));

        // rotate the end points for next pass
        Transform temp = EnemyStopPoints[0];
        for (i = 0; i < EnemyStopPoints.Length - 1; i++)
        {
            EnemyStopPoints[i] = EnemyStopPoints[i + 1];
        }
        EnemyStopPoints[i] = temp;
    }
}
