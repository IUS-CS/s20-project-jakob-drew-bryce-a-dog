using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxEnemy : Enemy
{
    public Transform player;

    public float respawnTime = 3f;
    // speed which enemy chases player, controlled by difficulty level in GameStateController
    public float moveSpeed = 1.0f;
    public float stunTime = 2.0f;

    bool shouldFollow = false;

    private void OnEnable()
    {
        shouldFollow = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        FadeIn();

        Invoke("ReEnableCollider", 0.01f);
    }

    private void Update()
    {
        //Calculate player's position
        Vector3 direction = player.position - transform.position;

        direction.Normalize();

        //Calculate enemy's speed
        Vector3 velocity = direction * moveSpeed;

        //if (magnitude > mShootThreshold && magnitude < mFarThreshold)
        if (shouldFollow)
        {
            //Move the enemy toward player
            myRigidbody.velocity = new Vector3(velocity.x, myRigidbody.velocity.y, velocity.z);
        }
    }

    // turn collider back on immediately so it doesn't fall through floor
    private void ReEnableCollider()
    {
        //this.gameObject.GetComponent<BoxCollider>().enabled = true;
        ToggleCollider(true);

        shouldFollow = true;
    }

    // called when the capsule collider is hit by an arrow with enough force
    public void TakeDamageFromEvent()
    {
        // "stun" the enemy when it's hit by the arrow so physics can happen for a bit
        shouldFollow = false;
        Invoke("FollowPlayer", stunTime);
    }

    private void FollowPlayer()
    {
        shouldFollow = true;
    }

}
