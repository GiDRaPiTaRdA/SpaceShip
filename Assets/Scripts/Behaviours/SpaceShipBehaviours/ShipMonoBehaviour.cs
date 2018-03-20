using System;
using Assets.Scripts.Entities;
using UnityEngine;

namespace Assets.Scripts.Behaviours.SpaceShipBehaviours
{
    public class ShipMonoBehaviour :MonoBehaviour
    {
        private SpaceShipBehaviour skeleton;

        public SpaceShip SpaceShip => this.skeleton.SpaceShip;

        protected virtual void Start()
        {
            this.Initialize();
        }

        public void Initialize()
        {
            this.skeleton = GameObject.FindObjectOfType<SpaceShipBehaviour>();

            if (this.skeleton == null)
            {
                throw new Exception("NO such object");
            }
        }
    }
}