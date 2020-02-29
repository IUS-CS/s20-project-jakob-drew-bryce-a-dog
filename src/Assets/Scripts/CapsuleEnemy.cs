using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CapsuleEnemy : Enemy
{
    public GameObject explosionPrefab;

    public float respawnTime = 3f;

    private AudioSource audio;

    private void Awake()
    {
        audio = this.gameObject.GetComponent<AudioSource>();
    }

    public void TakeDamageFromEvent()
    {
        // delay turning them off so you can see the arrow stick, could add an explosion animation here
        Invoke("KillEnemy", .5f);
    }

    private void KillEnemy()
    {
        RotatingEnemyController.Instance?.OnEnemyDeath();

        StartCoroutine(Explode());

        // don't destroy these from the scene, we may as well just turn them back on later
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.GetComponent<CapsuleCollider>().enabled = false;

        GameObject arrow = gameObject.GetComponentInChildren<Arrow>().gameObject;
        Destroy(arrow);

        
    }

    private IEnumerator Explode()
    {
        audio.Play(0);

        GameObject explosion = Instantiate(explosionPrefab);
        explosion.transform.position = this.gameObject.transform.position;

        yield return new WaitForSeconds(2f);

        Destroy(explosion);

        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
        this.gameObject.SetActive(false);
    }
}
