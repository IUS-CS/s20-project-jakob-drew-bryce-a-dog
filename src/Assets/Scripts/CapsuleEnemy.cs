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
        Destroy(this.gameObject);

        RotatingEnemyController.Instance?.OnEnemyDeath();
    }
    /*
    // called when the capsule collider is hit by an arrow with enough force
    public void TakeDamageFromEvent()
    {
        // cancel any running coroutines on this gameObject just in case
        StopAllCoroutines();

        if (HideOnHit)
        {
            // hide this gameObject's mesh when it is hit by an arrow
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;

            // turn it back on (primitive "respawn") some amount of seconds later
            StartCoroutine(DelayReenableMesh(respawnTime));
        }
        else if (PhysicsOnHit)
        {
            // do nothing
        }
    }

    private IEnumerator DelayReenableMesh(float delay)
    {
        yield return new WaitForSeconds(delay);

        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
    */
}
