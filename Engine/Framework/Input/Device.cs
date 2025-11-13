using System;

namespace Hybrid
{
    // Input Device
    public class Device
    {
        internal Device()
        {
            
        }
        
        internal virtual void OnEvent(SDL.Event e)
        {
            
        }
        
        internal virtual void Reset()
        {
            
        }

        internal virtual void Dispose()
        {
            
        }
    }
}