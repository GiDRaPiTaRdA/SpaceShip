using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Entities.Modifications.Mods
{
    class AntiGravitySpeedModification : Modification
    {
        public AntiGravitySpeedModification(GameObject gameObject) : base(gameObject){}

        public override void ToggleMode(bool value)
        {
            if (gameObject != null)
                ((ZeroGravityOnMoveBehaviour)gameObject.GetComponent(typeof(ZeroGravityOnMoveBehaviour))).enabled = value;
        }
    }
}
