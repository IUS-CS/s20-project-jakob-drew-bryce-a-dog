using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class TargetEnemy : Enemy
{
    public void TakeDamageFromEvent()
    {
        // scale this object down on hit, and when it's 0,0,0 start the game then turn it off
        StartCoroutine(BasicAnimator.AnimateScale(this.gameObject.transform.parent, this.gameObject.transform.parent.localScale, Vector3.zero, 2f, new Action(() =>
        {
            GameStateController.Instance?.StartGame();
            this.gameObject.SetActive(false);
        })));
    }
}
