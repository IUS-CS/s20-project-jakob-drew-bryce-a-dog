using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using Valve.VR.InteractionSystem;

public class GameStateController : Singleton<GameStateController>
{
    public GameObject BowItemPackage;
    public Hand LeftHand;
    public GameObject bowStand;
    public GameObject endpoint;
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
        StartCoroutine(BasicAnimator.AnimateWorldPosition(bowStand.transform, bowStand.transform.position, endpoint.transform.position, 10f));
    }
}
