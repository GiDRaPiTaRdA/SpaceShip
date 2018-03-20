using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Behaviours
{
    public class HealthBehaviour : MonoBehaviour
    {
        public int health = 25;

        

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == GameTags.Lander)
                GameManager.SpaceShip.HP += health;
        }
    }
}
