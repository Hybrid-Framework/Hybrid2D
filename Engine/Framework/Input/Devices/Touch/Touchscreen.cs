using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal class Touchscreen : InputDevice
    {
        internal List<InputTouch> Touches = new List<InputTouch>();
        internal ulong DeviceID;
        internal int PlayerID;
        
        
        internal Touchscreen(ulong deviceID, int playerID)
        {
            this.DeviceID = deviceID;
            this.PlayerID = playerID;
        }
        
        // Dispose
        internal override void OnDispose()
        {
            Touches.Clear();
        }

        // Reset
        internal override void OnReset()
        {
            foreach (var touch in Touches)
            {
                touch.Reset();
            }
        }

        // Events
        internal override void OnEvent(SDL.Event e)
        {
            switch (e.type)
            {
                // Touch Up
                case SDL.EventType.TouchFingerUp:
                {
                    break;
                }
                
                // Touch Down
                case SDL.EventType.TouchFingerDown:
                {
                    break;
                }
                
                // Touch Motion
                case SDL.EventType.TouchFingerMotion:
                {
                    break;
                }
                
                // Touch Cancel
                case SDL.EventType.TouchFingerCancel:
                {
                    break;
                }
            }
        }
    }
}