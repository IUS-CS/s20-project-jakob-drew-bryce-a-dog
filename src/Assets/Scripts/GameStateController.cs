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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBowPickup()
    {
        BowItemPackage.SetActive(false);
        LeftHand.HideGrabHint();
        StartCoroutine(BasicAnimator.AnimateWorldPosition(bowStand.transform, bowStand.transform.position, endpoint.transform.position, 10f));
    }

    public void StartGame()
    {
        TimerController.Instance?.StartTimer();
        RotatingEnemyController.Instance?.MoveToStartPos();
    }

    public void OnRotatingEnemiesCleared()
    {
        PhysicsEnemyController.Instance?.Invoke("SpawnEnemies", 2f);
    }

    public void OnPhysicsEnemiesCleared()
    {
        RotatingEnemyController.Instance?.Invoke("SpawnEnemies", 2f);
    }
}
