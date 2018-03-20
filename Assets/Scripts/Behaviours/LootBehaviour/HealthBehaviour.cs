using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Behaviours.SpaceShipBehaviours;
using UnityEngine;

namespace Assets.Scripts.Behaviours
{
    public class HealthBehaviour : ShipMonoBehaviour
    {
        public int health = 25;

        

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == GameTags.Lander)
                this.SpaceShip.HP += this.health;
        }
    }
}
