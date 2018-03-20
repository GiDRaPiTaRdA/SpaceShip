using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Entities
{
    public class SpaceShipEventArgs : EventArgs
    {
        public float TrustForce { get; set; }
        public float RetardForce { get; set; }
        public float TurnForce { get; set; }
        public float StabelizingForce { get; set; }
    }
}
