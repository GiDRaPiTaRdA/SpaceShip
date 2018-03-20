using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

using Random = System.Random;

namespace Assets.Scripts.Behaviours
{
    public class LootBehaviour : MonoBehaviour
    {
        public bool destoyOnPickUp = true;

        private static Random random;

        private Random Random
        {
            get
            {
                if (random == null)
                    random = new Random();

                return random;
            }
        }

        // Use this for initialization
        void Start()
        {
            GetComponent<Rigidbody2D>().angularVelocity = Random.Next(5, 20) * (Random.Next(-1, 1) == 0 ? -1 : 1);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
			if(destoyOnPickUp&&collision.gameObject.tag==GameTags.Lander)
                Destroy(this.gameObject);
        }
    }
}
