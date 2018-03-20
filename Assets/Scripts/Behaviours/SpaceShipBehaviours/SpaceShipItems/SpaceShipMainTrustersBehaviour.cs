using GameControls;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Behaviours.SpaceShipBehaviours;
using UnityEngine;

public class SpaceShipMainTrustersBehaviour : ShipMonoBehaviour {

    Animator animator;

	// Use this for initialization
    protected override void Start ()
    {
        base.Start();

	    this.animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        this.animator.SetBool("TrustActivated", this.SpaceShip.IsTrusting);
    }
}
