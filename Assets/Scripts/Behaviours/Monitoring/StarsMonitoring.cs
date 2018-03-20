using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Behaviours.SpaceShipBehaviours;
using UnityEngine;

namespace Assets.Scripts.Behaviours
{
    public class StarsMonitoring : ShipMonoBehaviour
    {

        public int countStars = 0;

        SpriteRenderer render;

        // Use this for initialization
        protected override void Start ()
        {
            base.Start();

            this.render = this.GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            if (this.SpaceShip.Stars >= this.countStars)
            {
                this.render.maskInteraction = SpriteMaskInteraction.None;
            }
        }
    }
}
