using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class PhysicsEnemyKillbox : Singleton<PhysicsEnemyKillbox>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        Destroy(collider.gameObject);

        if (collider.gameObject.CompareTag("PhysicsEnemyBox"))
        {
            PhysicsEnemyController.Instance?.OnEnemyDeath();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
