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

        private Random Random => random ?? (random = new Random());

        // Use this for initialization
        void Start()
        {
            this.GetComponent<Rigidbody2D>().angularVelocity = this.Random.Next(5, 20) * (this.Random.Next(-1, 1) == 0 ? -1 : 1);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
			if(this.destoyOnPickUp&&collision.gameObject.tag==GameTags.Lander)
                Destroy(this.gameObject);
        }
    }
}
