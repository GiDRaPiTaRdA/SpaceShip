using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Behaviours
{
    public class SpaceShipTurnLeftTrustersBehaviour : MonoBehaviour
    {
        Animator animator;

        // Use this for initialization
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            animator.SetBool("TrustActivated", GameManager.SpaceShip.IsTurningLeft);
        }
    }
}
