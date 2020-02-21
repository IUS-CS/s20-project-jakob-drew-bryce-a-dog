using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class TargetEnemy : Enemy
{
    public RotatingEnemyController rotatingEnemyController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamageFromEvent()
    {
        GameStateController.Instance?.StartGame();

        // scale this object down on hit, and when it's 0,0,0 turn it off
        StartCoroutine(BasicAnimator.AnimateScale(this.gameObject.transform.parent, this.gameObject.transform.parent.localScale, Vector3.zero, 3f, new Action(() =>
        {
            this.gameObject.SetActive(false);
        })));
        
    }
}
