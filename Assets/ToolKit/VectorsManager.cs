using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ToolKit
{
    public static class VectorsManager
    {
        public static Vector2 DirrectionDependentBehavoir(this Vector2 vector, double radAngle)
        {
            float x = (float)(vector.x * Math.Cos(radAngle) + vector.y * - Math.Sin(radAngle));
            float y = (float)(vector.x * Math.Sin(radAngle) + vector.y * Math.Cos(radAngle));

            return new Vector2(x, y);
        }

        public static Vector2 DirrectionDependentBehavoir(this Vector2 vector, Transform transform)
        {
            float radAngle = transform.eulerAngles.z / Mathf.Rad2Deg;

            float x = (float)(vector.x * Math.Cos(radAngle) + vector.y * -Math.Sin(radAngle));
            float y = (float)(vector.x * Math.Sin(radAngle) + vector.y * Math.Cos(radAngle));

            return new Vector2(x, y);
        }
    }
}
