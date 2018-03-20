using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ToolKit
{
    public static class TreeTraversal
    {
        public static GameObject FindParentWithTag(this GameObject childObject, string tag)
        {
            Transform t = childObject.transform;
            while (t.parent != null)
            {
                if (t.parent.tag == tag)
                {
                    return t.parent.gameObject;
                }
                t = t.parent.transform;
            }
            return null;
        }
    }
}
