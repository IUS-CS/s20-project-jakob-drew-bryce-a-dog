using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDamage : MonoBehaviour
{
    public float damage = 1f;
    public float range = 100f;
    public float impactForce = 30f;

    public Camera FPSCam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        // shoot a ray from the camera straigth forward and see if it hits any objects with colliders
        if (Physics.Raycast(FPSCam.transform.position, FPSCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            BlobEnemy enemy = hit.transform.GetComponent<BlobEnemy>();
            if (enemy != null)
            {
                enemy.TakeDamageFromEvent();
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }
    }
}
