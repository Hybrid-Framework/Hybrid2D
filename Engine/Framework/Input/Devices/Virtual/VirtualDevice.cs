using System.Collections.Generic;
using System.Linq;
using System;

namespace Hybrid
{
    public class VirtualDevice : InputDevice
    {
        private readonly Dictionary<string, VirtualButton> Buttons = new Dictionary<string, VirtualButton>();
        private readonly Dictionary<string, VirtualAxis> Axes = new Dictionary<string, VirtualAxis>();
        
        
        // Constructor
        internal VirtualDevice(ulong device, Player player)
        {
            this.Device = device;
            this.Player = player;
        }
        
        internal string[] GetDeviceButtons()
        {
            return Buttons.Keys.ToArray();
        }

        internal string[] GetDeviceAxes()
        {
            return Axes.Keys.ToArray();
        }
    }
}