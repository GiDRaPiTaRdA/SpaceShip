using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.ToolKit
{
    public static class Spawn
    {
        public static void MoveToParrent(this GameObject spawnObject, GameObject gameObject) => spawnObject.MoveTo(gameObject.transform.parent);

        public static void MoveTo(this GameObject spawnObject, Transform parrent) => spawnObject.transform.parent = parrent;

        public static void TranferPhisicsToChildDebris(this GameObject target, Rigidbody2D donor)
        {
            var velocity = donor.GetComponent<Rigidbody2D>().velocity;
            var angvelocity = donor.GetComponent<Rigidbody2D>().angularVelocity;

            var rigidbodies = target.GetComponentsInChildren<Rigidbody2D>();
            rigidbodies.ToList().ForEach(rgb =>
            {
                rgb.TranferPhisics(velocity,angvelocity);
            });
        }

        public static void TranferPhisics(this Rigidbody2D target, Rigidbody2D donor)
        {
            var velocity = donor.velocity;
            var angularVelocity = donor.angularVelocity;

            target.TranferPhisics(velocity, angularVelocity);
        }

        public static void TranferPhisics(this Rigidbody2D targetRigid, Vector2 velocity, float angularVelocity)
        {
            targetRigid.velocity = velocity;
            targetRigid.angularVelocity = angularVelocity;
        }

        public static void ApplyScale(this Rigidbody2D targetRigid, float scale)
        {
            targetRigid.velocity *= scale;
            targetRigid.angularVelocity *= scale;
            targetRigid.mass *= scale;
        }
    }
}
