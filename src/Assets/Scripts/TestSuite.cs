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

            GameObject physicsEnemy = new GameObject("enemy");
            physicsEnemy.AddComponent<ChasingChickenEnemy>();
            physicsEnemy.AddComponent<Rigidbody>();
            physicsEnemy.AddComponent<BoxCollider>();
            physicsEnemy.tag = "Enemy";

            GameObject killbox = new GameObject("killbox");
            killbox.AddComponent<PhysicsEnemyKillbox>();
            killbox.AddComponent<BoxCollider>();
            // place killbox below enemy
            killbox.transform.position = new Vector3(0f, -10f, 0f);

            yield return new WaitForSeconds(3f);

            //Assert.IsNull(physicsEnemy); // doesn't work - destroyed gameobjects are pseudo-null? wtf
            Assert.IsTrue(physicsEnemy == null);
        }

        [UnityTest]
        public IEnumerator test_physics_enemies_cleared()
        {
            LogAssert.ignoreFailingMessages = true;

            GameObject controllerGO = new GameObject("PhysicsEnemyController");
            PhysicsEnemyController controller = controllerGO.AddComponent<PhysicsEnemyController>();

            GameObject physicsEnemy1 = new GameObject("enemy");
            physicsEnemy1.transform.position = new Vector3(2f, 0, 0); // move these around so they aren't hitting each other
            physicsEnemy1.AddComponent<ChasingChickenEnemy>();
            physicsEnemy1.AddComponent<Rigidbody>();
            physicsEnemy1.AddComponent<BoxCollider>();
            physicsEnemy1.tag = "Enemy";
            GameObject physicsEnemy2 = new GameObject("enemy");
            physicsEnemy2.transform.position = new Vector3(-2f, 0, 0);
            physicsEnemy2.AddComponent<ChasingChickenEnemy>();
            physicsEnemy2.AddComponent<Rigidbody>();
            physicsEnemy2.AddComponent<BoxCollider>();
            physicsEnemy2.tag = "Enemy";
            GameObject physicsEnemy3 = new GameObject("enemy");
            physicsEnemy3.transform.position = new Vector3(0, 2f, 0);
            physicsEnemy3.AddComponent<ChasingChickenEnemy>();
            physicsEnemy3.AddComponent<Rigidbody>();
            physicsEnemy3.AddComponent<BoxCollider>();
            physicsEnemy3.tag = "Enemy";
            GameObject physicsEnemy4 = new GameObject("enemy");
            physicsEnemy4.transform.position = new Vector3(0, -2f, 0);
            physicsEnemy4.AddComponent<ChasingChickenEnemy>();
            physicsEnemy4.AddComponent<Rigidbody>();
            physicsEnemy4.AddComponent<BoxCollider>();
            physicsEnemy4.tag = "Enemy";

            controller.EnemiesAlive = 4;

            GameObject killbox = new GameObject("killbox");
            killbox.AddComponent<PhysicsEnemyKillbox>();
            killbox.AddComponent<BoxCollider>();
            // place killbox below enemies
            killbox.transform.position = new Vector3(0f, -10f, 0f);
            // scale it up a bit
            killbox.transform.localScale = killbox.transform.localScale * 5;

            yield return new WaitForSeconds(3f);

            Assert.AreEqual(0, controller.EnemiesAlive);
        }
    }
}
