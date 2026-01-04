using System.Collections.Generic;
using System;

namespace Hybrid
{
    public class VirtualDevice : InputDevice
    {
        internal Player Player;
        
        // Constructor
        internal VirtualDevice(Player player)
        {
            this.Player = player;
        }

        // Reset
        internal override void OnReset()
        {
            
        }
    }
}