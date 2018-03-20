using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Behaviours.SpaceShipBehaviours;
using UnityEngine;

namespace Assets.Scripts.Behaviours
{
    class SpaceShipTurnRightTrustersBehaviour : ShipMonoBehaviour
    {
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
            this.animator.SetBool("TrustActivated", this.SpaceShip.IsTurningRight);
        }
    }
}
