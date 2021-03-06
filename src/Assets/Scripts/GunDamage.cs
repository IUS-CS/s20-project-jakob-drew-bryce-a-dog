﻿using System.Collections;
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
        if (Input.GetButtonDown("Fire1")) // left click to shoot
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        float distance;
        // shoot a ray from the camera straigth forward and see if it hits any objects with colliders
        if (Physics.Raycast(FPSCam.transform.position, FPSCam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);

            PatrollingChickenEnemy Cenemy = hit.transform.GetComponent<PatrollingChickenEnemy>();
            ChasingChickenEnemy Benemy = hit.transform.GetComponent<ChasingChickenEnemy>();
            BowStandEnemy bowStand = hit.transform.GetComponent<BowStandEnemy>();
            TargetEnemy target = hit.transform.GetComponent<TargetEnemy>();

            distance = Vector3.Distance(FPSCam.transform.position, hit.transform.position);

            if (Cenemy != null)
            {
                Cenemy.TakeDamageFromEvent();
                
                //ScoreController.Instance?.AddScoreFromArrowHit(distance);
            }

            if (Benemy != null)
            {
                Benemy.TakeDamageFromEvent();

                //ScoreController.Instance?.AddScoreFromArrowHit(distance);
            }

            if (bowStand != null)
            {
                bowStand.TakeDamageFromEvent();
            }

            if (target != null)
            {
                target.TakeDamageFromEvent();
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }
    }
}
