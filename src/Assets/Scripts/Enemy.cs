using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// not using these yet, might need em later
public enum EnemyState
{
    idle,
    moving,
    chasing,
    staggered,
    awaitingRespawn
}

public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public Rigidbody myRigidBody;

    void Start()
    {
        // some enemies will have rigidbodies for physics, others will just die in place on arrow hit
        if (GetComponent<Rigidbody>() != null)
        {
            myRigidBody = GetComponent<Rigidbody>();
        }
    }
}
