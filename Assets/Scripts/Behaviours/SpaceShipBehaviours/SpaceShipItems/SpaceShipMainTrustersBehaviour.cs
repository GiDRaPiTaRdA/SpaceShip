using GameControls;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipMainTrustersBehaviour : MonoBehaviour {

    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("TrustActivated", GameManager.SpaceShip.IsTrusting);
    }
}
