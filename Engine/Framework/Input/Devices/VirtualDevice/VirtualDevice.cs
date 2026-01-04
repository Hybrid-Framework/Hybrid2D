using System.Collections.Generic;
using System;

namespace Hybrid
{
    public class VirtualDevice : InputDevice
    {
        private readonly Dictionary<string, VirtualButton> Buttons = new Dictionary<string, VirtualButton>();
        private readonly Dictionary<string, VirtualVector> Vectors = new Dictionary<string, VirtualVector>();
        private readonly Dictionary<string, VirtualAxis> Axes = new Dictionary<string, VirtualAxis>();
        
        
        // Constructor
        internal VirtualDevice(ulong device, Player player)
        {
            this.Device = device;
            this.Player = player;
        }
    }
}