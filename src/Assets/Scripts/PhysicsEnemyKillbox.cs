using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class PhysicsEnemyKillbox : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        // if anything with a collider hits this box, destroy it from the scene to save memory
        Destroy(collider.gameObject);

        // if it's a physics enemy or boss, let their controllers know about it
        if (collider.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("enemy hit killbox");
            PhysicsEnemyController.Instance?.OnEnemyDeath();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
