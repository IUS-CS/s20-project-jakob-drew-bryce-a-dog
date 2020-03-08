using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CapsuleEnemy : Enemy
{
    public float respawnTime = 3f;
    
    private GameObject explosionPrefab;

    private void Awake()
    {
        // load the explosion prefab at runtime instead of linking in inspector, a little slower but accomodates unit tests
        explosionPrefab = (GameObject)Resources.Load("Prefab/BigExplosion", typeof(GameObject));

        mesh = this.gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
        audio = this.gameObject.GetComponent<AudioSource>();
    }

    private void Start()
    {
        // set material's alpha to 0 at start (completely transparent)
        Color invis = mesh.material.color;
        invis.a = 0f;
        mesh.material.color = invis;
    }

    public void TakeDamageFromEvent()
    {
        // delay turning them off so you can see the arrow stick, could add an explosion animation here
        Invoke("KillEnemy", .5f);
    }

    private void KillEnemy()
    {
        RotatingEnemyController.Instance?.OnEnemyDeath();

        Coroutine explodeCoroutine = StartCoroutine(Explode());

        // don't destroy these from the scene, we may as well just turn them back on later
        this.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        this.gameObject.GetComponent<CapsuleCollider>().enabled = false;

        if (StartupController.Instance.VRMode)
        {
            GameObject arrow = gameObject.GetComponentInChildren<Arrow>().gameObject;
            Destroy(arrow);
        }
    }

    private IEnumerator Explode()
    {
        audio.Play(0);

        GameObject explosion = Instantiate(explosionPrefab);
        explosion.transform.position = this.gameObject.transform.position;

        yield return new WaitForSeconds(1.98f);

        Destroy(explosion);

        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
        this.gameObject.SetActive(false);
    }
}
