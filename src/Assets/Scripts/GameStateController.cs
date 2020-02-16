using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using Valve.VR.InteractionSystem;

public class GameStateController : Singleton<GameStateController>
{
    public GameObject BowItemPackage;
    public Hand LeftHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBowPickup()
    {
        BowItemPackage.SetActive(false);
        LeftHand.HideGrabHint();
    }
}
