using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class PhysicsEnemyController : Singleton<PhysicsEnemyController>
{
    public GameObject PhysicsEnemyPrefab;
    //public GameObject[] PhysicsEnemies;
    public Transform[] SpawnPoints;
    public int EnemiesToSpawn = 4;
    public int EnemiesAlive;

    public void SpawnEnemies()
    {
        for (int i = 0; i < EnemiesToSpawn; i++)
        {
            Instantiate(PhysicsEnemyPrefab, SpawnPoints[i].position, SpawnPoints[i].rotation);
        }

        EnemiesAlive = EnemiesToSpawn;

        //EnemiesAlive = PhysicsEnemies.Length;

        //for (int i = 0; i < PhysicsEnemies.Length; i++)
        //{
        //    PhysicsEnemies[i].SetActive(true);
        //}
    }

    public void OnEnemyDeath()
    {
        EnemiesAlive--;
        
        if (EnemiesAlive < 1)
        {
            GameStateController.Instance?.OnPhysicsEnemiesCleared();
        }

        ScoreController.Instance?.AddScoreFromKillbox();
    }
}