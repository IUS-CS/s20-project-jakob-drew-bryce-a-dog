using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PatrollingChickenEnemy : Enemy
{
    public float respawnTime = 3f;

    public Transform player;
    private GameObject explosionPrefab;

    private void Awake()
    {
        // load the explosion prefab at runtime instead of linking in inspector, a little slower but accomodates unit tests
        explosionPrefab = (GameObject)Resources.Load("Prefab/BigExplosion", typeof(GameObject));

        mesh = this.gameObject.GetComponent<MeshRenderer>();
        audio = this.gameObject.GetComponent<AudioSource>();
    }

    private void Start()
    {
        // set material's alpha to 0 at start (completely transparent)
        Color invis = mesh.material.color;
        invis.a = 0f;
        mesh.material.color = invis;
    }

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void TakeDamageFromEvent()
    {
        CancelInvoke();

        Invoke("KillEnemy", .5f);

        float distance = Vector3.Distance(this.transform.position, player.transform.position);
        ScoreController.Instance?.AddScoreFromArrowHit(distance, this.transform.position);
    }

    private void KillEnemy()
    {
        RotatingEnemyController.Instance?.OnEnemyDeath();

        Coroutine explodeCoroutine = StartCoroutine(Explode());

        // don't destroy these from the scene, we may as well just turn them back on later
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
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
        explosion.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 0.75f, this.gameObject.transform.position.z);

        yield return new WaitForSeconds(1.98f);

        Destroy(explosion);

        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
        this.gameObject.SetActive(false);
    }
}
