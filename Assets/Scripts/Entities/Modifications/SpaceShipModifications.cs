using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Entities.Modifications;
using Assets.Scripts.Entities.Modifications.Mods;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class SpaceShipModifications
    {
        private GameObject gameObject;
        public Dictionary<Type, Modification> modifications;

        public SpaceShipModifications(GameObject gameObject)
        {
            this.modifications = new Dictionary<Type, Modification>();
            this.gameObject = gameObject;

            // Initialize modifications
            this.modifications.Add(typeof(AntiGravitySpeedModification), new AntiGravitySpeedModification(this.gameObject));
        }

        public void ToggleModifiCation<ModificationType>(bool value) where ModificationType : Modification
        {
            this.modifications[typeof(ModificationType)].ToggleMode(value);
        }

    }
}
