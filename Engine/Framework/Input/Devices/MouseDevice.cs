using System;

namespace Hybrid
{
    // Mouse Device
    internal partial class MouseDevice : InputDevice
    {
        internal override void OnEvent(SDL.Event e)
        {
            Console.WriteLine($"Mouse {e.type}");

            switch (e.type)
            {
                case SDL.EventType.MouseButtonUp:
                    break;
                
                case SDL.EventType.MouseButtonDown:
                    break;
                
                case SDL.EventType.MouseMotion:
                    break;
                
                case SDL.EventType.MouseWheel:
                    break;
            }
        }
    }
    
    
    // Properties & Methods
    internal partial class MouseDevice
    {
        internal Vector2 Position
        {
            get
            {
                return Vector2.Zero;
            }
        }
        
        internal Vector2 Delta
        {
            get
            {
                return Vector2.Zero;
            }
        }
        
        internal Vector2 ScrollDelta
        {
            get
            {
                return Vector2.Zero;
            }
        }
        
        internal bool GetMouseButton(int button)
        {
            return false;
        }

        internal bool GetMouseButtonUp(int button)
        {
            return false;
        }
        
        internal bool GetMouseButtonDown(int button)
        {
            return false;
        }
    }
}