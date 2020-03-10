using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestSuite
    {
        [SetUp]
        public void Setup()
        {
            LogAssert.ignoreFailingMessages = true;
        }

        [TearDown]
        public void Teardown()
        {

        }

        // A Test behaves as an ordinary method
        [Test]
        public void TestSuiteSimplePasses()
        {
            // Use the Assert class to test conditions

        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator test_rotating_enemies_death_on_hit()
        {
            // prevent exceptions on components we don't care about from stopping the test
            LogAssert.ignoreFailingMessages = true;

            GameObject enemyGO = new GameObject("PatrollingChickenEnemy");
            enemyGO.AddComponent<MeshRenderer>();
            enemyGO.AddComponent<CapsuleCollider>();
            enemyGO.AddComponent<AudioSource>();
            PatrollingChickenEnemy enemy = enemyGO.AddComponent<PatrollingChickenEnemy>();

            enemy.TakeDamageFromEvent();
            yield return new WaitForSeconds(4f);

            Assert.IsFalse(enemyGO.activeInHierarchy);
        }
        
        [UnityTest]
        public IEnumerator test_rotating_enemies_cleared()
        {
            LogAssert.ignoreFailingMessages = true;

            GameObject controllerGO = new GameObject("RotatingEnemyController");
            RotatingEnemyController controller = controllerGO.AddComponent<RotatingEnemyController>();

            GameObject enemyGO1 = new GameObject("PatrollingChickenEnemy");
            PatrollingChickenEnemy enemy1 = enemyGO1.AddComponent<PatrollingChickenEnemy>();
            GameObject enemyGO2 = new GameObject("PatrollingChickenEnemy");
            PatrollingChickenEnemy enemy2 = enemyGO2.AddComponent<PatrollingChickenEnemy>();
            GameObject enemyGO3 = new GameObject("PatrollingChickenEnemy");
            PatrollingChickenEnemy enemy3 = enemyGO3.AddComponent<PatrollingChickenEnemy>();
            GameObject enemyGO4 = new GameObject("PatrollingChickenEnemy");
            PatrollingChickenEnemy enemy4 = enemyGO4.AddComponent<PatrollingChickenEnemy>();

            enemy1.TakeDamageFromEvent();
            yield return null;
            enemy2.TakeDamageFromEvent();
            yield return null;
            enemy3.TakeDamageFromEvent();
            yield return null;
            enemy4.TakeDamageFromEvent();

            yield return new WaitForSeconds(3f);

            Assert.AreEqual(0, controller.EnemiesAlive);
        }

        [UnityTest]
        public IEnumerator test_physics_enemies_death_on_killbox_enter()
        {
            LogAssert.ignoreFailingMessages = true;

            //GameObject physicsEnemy = new GameObject("enemy");
            GameObject physicsEnemy = (GameObject)Resources.Load("Prefab/PhysicsChickenPrefab", typeof(GameObject));

            GameObject killbox = new GameObject("killbox");
            killbox = (GameObject)Resources.Load("Prefab/EnemyKillBox", typeof(GameObject));
            // place killbox below enemy
            killbox.transform.position = new Vector3(0f, -10f, 0f);

            yield return new WaitForSeconds(10f);

            Assert.IsNull(physicsEnemy);
        }
    }
}
