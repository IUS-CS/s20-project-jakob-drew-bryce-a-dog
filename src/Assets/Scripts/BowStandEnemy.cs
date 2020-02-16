using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowStandEnemy : Enemy
{
    public GameStateController GameStateController;

    public void TakeDamageFromEvent()
    {
        GameStateController.OnBowPickup();
    }
}
