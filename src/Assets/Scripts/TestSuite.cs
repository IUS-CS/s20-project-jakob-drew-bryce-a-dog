using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestSuite
    {
        [SetUp]
        public void Setup()
        {

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
        public IEnumerator test_rotating_enemies_cleared()
        {
            GameObject GameController = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefab/GameFlowControllers"));
            GameStateController StateController = GameController.GetComponent<GameStateController>();
            RotatingEnemyController RotatingController = GameController.GetComponent<RotatingEnemyController>();

            yield return null;
            yield return null;

            RotatingController.SpawnEnemies();

            for (int i = 0; i < RotatingController.EnemiesAlive; i++)
            {
                RotatingController.OnEnemyDeath();
            }

            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;

            Assert.IsTrue(StateController.RotatingEnemiesAwaitingRespawn);
        }
    }
}
