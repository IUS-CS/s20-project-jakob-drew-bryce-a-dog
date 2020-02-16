using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxEnemy : Enemy
{
    public bool HideOnHit = true;
    public bool PhysicsOnHit = false;
    public float respawnTime = 3f;

    // called when the capsule collider is hit by an arrow with enough force
    public void TakeDamageFromEvent()
    {
        // cancel any running coroutines on this gameObject just in case
        StopAllCoroutines();

        if (HideOnHit)
        {
            // do nothing
        }
        else if (PhysicsOnHit)
        {
            // do nothing (yet)
        }
    }
}
