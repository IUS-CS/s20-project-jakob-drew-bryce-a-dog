using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class RotatingEnemyController : Singleton<RotatingEnemyController>
{
    public Transform[] RotatingEnemies;
    public Transform[] EnemyStopPoints;
    public float AnimationTime = 5f;
    public float PauseTime = 3f;
    public int EnemiesAlive = 4;

    private Transform[] enemyDestination;

    private bool firstRotation = true;

    void Start()
    {
        //StartRotations();
    }



    public void InitialSpawn()
    {
        for (int i = 0; i < RotatingEnemies.Length; i++)
        {
            //StartCoroutine(BasicAnimator.AnimateWorldPosition(RotatingEnemies[i], RotatingEnemies[i].position, EnemyStopPoints[i].position, 2F));
            RotatingEnemies[i].GetComponent<CapsuleEnemy>().FadeIn();
        }
        Invoke("StartRotations", 3f);
    }

    public void StartRotations()
    {
        CancelRotations();

        StartCoroutine(DelayStartRotations(1.5f));
    }

    private IEnumerator DelayStartRotations(float delay)
    {
        yield return new WaitForSeconds(delay);

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
            if (RotatingEnemies[i] != null)
            {
                //RotatingEnemies[i].LookAt(EnemyStopPoints[i + 1]);
                if (!firstRotation)
                {
                    RotatingEnemies[i].Rotate(Vector3.up, -90, Space.World);
                }
                
                // move this enemy to the next position
                StartCoroutine(BasicAnimator.AnimateWorldPosition(RotatingEnemies[i], RotatingEnemies[i].position, EnemyStopPoints[i + 1].position, AnimationTime, new System.Action(() =>
                {
                    //RotatingEnemies[i].Rotate(Vector3.up, 90, Space.World);
                    //StartCoroutine(BasicAnimator.AnimateLocalRotation(RotatingEnemies[i], RotatingEnemies[i].localRotation, RotatingEnemies[i].localRotation.eulerAngles.x))
                })));
            }
        }
        if (RotatingEnemies[i] != null)
        {
            //RotatingEnemies[i].LookAt(EnemyStopPoints[0]);
            if (!firstRotation)
            {
                RotatingEnemies[i].Rotate(Vector3.up, -90, Space.World);
            }

            // if this is the last enemy in array, move it to the first position
            StartCoroutine(BasicAnimator.AnimateWorldPosition(RotatingEnemies[i], RotatingEnemies[i].position, EnemyStopPoints[0].position, AnimationTime, new System.Action(() =>
            {
                //RotatingEnemies[i].Rotate(Vector3.up, 90, Space.World);
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
            RotatingEnemies[i].GetComponent<CapsuleEnemy>().FadeIn();
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
}
