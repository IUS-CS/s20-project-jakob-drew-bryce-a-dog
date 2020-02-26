using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleEnemy : Enemy
{
    public bool HideOnHit = true;
    public bool PhysicsOnHit = false;
    public float respawnTime = 3f;

    public void TakeDamageFromEvent()
    {
        // delay turning them off so you can see the arrow stick, could add an explosion animation here
        Invoke("KillEnemy", .5f);
    }

    private void KillEnemy()
    {
        // don't destroy these from the scene, we may as well just turn them back on later
        this.gameObject.SetActive(false);

        RotatingEnemyController.Instance?.OnEnemyDeath();
    }
}
