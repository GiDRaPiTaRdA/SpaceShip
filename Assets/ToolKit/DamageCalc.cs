using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.ToolKit
{
    public class DamageCalc
    {
        public static Vector2 GetDamageForceVector(Collision2D collision2D)
        {
            var normal = collision2D.contacts.Length > 0 ? collision2D.contacts[0].normal : new Vector2(1, 1).normalized;
            var velocity = collision2D.relativeVelocity;

            //var a = collision2D.contacts.Any() ? collision2D.contacts[0].normalImpulse : 1;

            Vector2 force = new Vector2(velocity.x * normal.x, velocity.y * normal.y);

            return force;
        }

        public static float GetDamageForce(Collision2D collision2D)
        {
            return GetDamageForceVector(collision2D).magnitude;
        }

        public static float PowerFunc(float force, float pow = 4)
        {
            return (float)Math.Pow(force, pow);
        }

        public static float NormalVectorImpulse(Collision2D collision2D)
        {
            return collision2D.contacts.Any() ? collision2D.contacts[0].normalImpulse : 1;
        }
    }
}
