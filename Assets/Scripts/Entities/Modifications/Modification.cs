using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Entities.Modifications
{
    public abstract class Modification
    {
        protected GameObject gameObject;

        public Modification(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public abstract void ToggleMode(bool value);
    }
}
