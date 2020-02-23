using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowStandEnemy : Enemy
{
    public void TakeDamageFromEvent()
    {
        GameStateController.Instance?.OnBowPickup();
    }
}
