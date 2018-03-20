using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GameControls
{
    public static class ApplicationKeyBindings
    {
        public static KeyCode TrustUp { get; set; }
        public static KeyCode TurnLeft { get; set; }
        public static KeyCode TurnRight { get; set; }

        public static KeyCode GetKeyCode(this KeyBinding keyBinding)
        {
            KeyCode keyCode;
            try
            {
                keyCode = (KeyCode)typeof(ApplicationKeyBindings).GetProperty(keyBinding.ToString()).GetValue(null, new object[0]);
            }
            catch(NullReferenceException)
            {
                throw new NullReferenceException("Cannot find corresponding key in " + typeof(ApplicationKeyBindings).Name);
            }

            return keyCode;
        }
    }
}
