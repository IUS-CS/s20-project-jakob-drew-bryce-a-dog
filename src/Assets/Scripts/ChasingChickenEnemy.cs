using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingChickenEnemy : Enemy
{
    public Transform player;

    public float respawnTime = 3f;
    // speed which enemy chases player, controlled by difficulty level in GameStateController
    public float movementSpeedVeryEasy = 1.0f;
    public float movementSpeedEasy = 1.1f;
    public float movementSpeedNormal = 1.2f;
    public float movementSpeedHard = 1.3f;
    public float movementSpeedVeryHard = 1.4f;
    public float stunTime = 2.0f;

    private float moveSpeed;
    private bool shouldFollow = false;

    private void OnEnable()
    {
        shouldFollow = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        FadeIn();

        Invoke("ReEnableCollider", 0.01f);

        StartCoroutine(UpdateChaseSpeed());
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
            //Face the enemy toward the player
            //transform.LookAt(new Vector3(player.transform.position.x, transform.position.y + 90, player.transform.position.z));
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
        float distance = Vector3.Distance(this.transform.position, player.transform.position);
        ScoreController.Instance?.AddScoreFromArrowHit(distance, this.transform.position);

        // "stun" the enemy when it's hit by the arrow so physics can happen for a bit
        shouldFollow = false;
        Invoke("FollowPlayer", stunTime);
    }

    private void FollowPlayer()
    {
        shouldFollow = true;
    }

    // update the enemy's chase speed every half second while it's active
    private IEnumerator UpdateChaseSpeed()
    {
        while (true)
        {
            SetChaseSpeed();

            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SetChaseSpeed()
    {
        switch (GameStateController.Instance?.GetCurrentDifficulty())
        {
            case Difficulty.veryEasy:
                moveSpeed = movementSpeedVeryEasy;

                break;
            case Difficulty.easy:
                moveSpeed = movementSpeedEasy;

                break;
            case Difficulty.normal:
                moveSpeed = movementSpeedNormal;

                break;
            case Difficulty.hard:
                moveSpeed = movementSpeedHard;

                break;
            case Difficulty.veryHard:
                moveSpeed = movementSpeedVeryHard;

                break;
        }
    }
}
