using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using Valve.VR.InteractionSystem;

public enum Difficulty
{
    veryEasy,
    easy,
    normal,
    hard,
    veryHard
}

public class GameStateController : Singleton<GameStateController>
{
    public GameObject BowItemPackage;
    public Hand LeftHand;
    public GameObject bowStand;
    public GameObject endpoint;

    [SerializeField]
    private Difficulty currentDifficulty;

    [HideInInspector]
    public bool RotatingEnemiesAwaitingRespawn = true;
    [HideInInspector]
    public bool PhysicsEnemiesAwaitingRespawn;


    public void OnBowPickup()
    {
        BowItemPackage.SetActive(false);
        LeftHand.HideGrabHint();
        StartCoroutine(BasicAnimator.AnimateWorldPosition(bowStand.transform, bowStand.transform.position, endpoint.transform.position, 8f));
    }

    public void StartGame()
    {
        TimerController.Instance?.StartTimer();
        MusicController.Instance?.StartMusic();
        RotatingEnemyController.Instance?.InitialSpawn();

        // debug
        //PhysicsEnemyController.Instance?.Invoke("SpawnEnemies", 2f);
    }

    public void OnRotatingEnemiesCleared()
    {
        RotatingEnemiesAwaitingRespawn = true;
        PhysicsEnemiesAwaitingRespawn = false;

        PhysicsEnemyController.Instance?.Invoke("SpawnEnemies", 2f);
    }

    public void OnPhysicsEnemiesCleared()
    {
        PhysicsEnemiesAwaitingRespawn = true;
        RotatingEnemiesAwaitingRespawn = false;

        RotatingEnemyController.Instance?.Invoke("SpawnEnemies", 2f);
    }

    public void SetDifficulty(Difficulty targetDifficulty)
    {
        currentDifficulty = targetDifficulty;
    }

    public Difficulty GetCurrentDifficulty()
    {
        return currentDifficulty;
    }
}
