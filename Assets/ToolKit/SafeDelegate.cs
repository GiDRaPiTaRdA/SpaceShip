using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolKit
{
    public static class SafeDelegate
    {
        public static void SafeInvoke(this EventHandler eventHandler, object sender, EventArgs args)
        {
            if (eventHandler != null)
            {
                eventHandler.Invoke(sender, args);
            }
        }

        public static void SafeInvoke<T>(this EventHandler<T> eventHandler,object sender,T args) where T : EventArgs
        {
            if (eventHandler != null)
            {
                eventHandler.Invoke(sender, args);
            }
        }
    }
}
