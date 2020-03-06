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

    protected MeshRenderer mesh;
    protected AudioSource audio;

    private void Awake()
    {
        mesh = this.gameObject.GetComponent<MeshRenderer>();
        audio = this.gameObject.GetComponent<AudioSource>();
    }

    void Start()
    {
        // some enemies will have rigidbodies for physics, others will just die in place on arrow hit
        if (GetComponent<Rigidbody>() != null)
        {
            myRigidBody = GetComponent<Rigidbody>();
        }
    }

    public void FadeIn()
    {
        StartCoroutine(FadeInCo());
    }

    private IEnumerator FadeInCo()
    {
        ToggleCollider(false);

        Color targetColor = mesh.material.color;

        // gradually increase the material's alpha transparency
        for (float f = 0f; f <= 1f; f += 0.05f)
        {
            targetColor.a = f;
            mesh.material.color = targetColor;

            yield return new WaitForSeconds(0.05f);
        }

        targetColor.a = 1.0f;
        mesh.material.color = targetColor;

        ToggleCollider(true);
    }

    public void ToggleCollider(bool enabled)
    {
        if (this.gameObject.GetComponent<CapsuleCollider>() != null)
        {
            this.gameObject.GetComponent<CapsuleCollider>().enabled = enabled;
        }
        if (this.gameObject.GetComponent<BoxCollider>() != null)
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = enabled;
        }
        if (this.gameObject.GetComponent<MeshCollider>() != null)
        {
            this.gameObject.GetComponent<MeshCollider>().enabled = enabled;
        }
    }
}
