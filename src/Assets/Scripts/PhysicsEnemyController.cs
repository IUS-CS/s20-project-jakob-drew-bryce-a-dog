using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class PhysicsEnemyController : Singleton<PhysicsEnemyController>
{
    public GameObject[] PhysicsEnemies;
    public int EnemiesAlive;

    public void SpawnEnemies()
    {
        EnemiesAlive = PhysicsEnemies.Length;

        for (int i = 0; i < PhysicsEnemies.Length; i++)
        {
            PhysicsEnemies[i].SetActive(true);
        }
    }

    public void OnEnemyDeath()
    {
        EnemiesAlive--;
    }
}
