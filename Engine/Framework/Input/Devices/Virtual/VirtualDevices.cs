using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal class VirtualDevices : InputDevice
    {
        internal readonly List<VirtualDevice> AllDevices = new List<VirtualDevice>();
        internal const int MaxDevices = 4;
        

        // Dispose
        internal override void OnDispose()
        {
            foreach (var device in AllDevices.ToArray())
            {
                Destroy(device.Player);
            }
        }

        // Reset
        internal override void OnReset()
        {
            foreach (var device in AllDevices)
            {
                device.OnReset();
            }
        }
        
        internal void Destroy(Player player)
        {
            var device = GetByPlayer(player);
            
            if (device != null)
            {
                Debug.Log($"Virtual Device {device.Player} disconnected");
                
                AllDevices.Remove(device);
                device.OnDispose();
            }
        }

        internal VirtualDevice Create(Player player)
        {
            var found = GetByPlayer(player);
            
            if (found == null)
            {
                for (int i = 0; i < MaxDevices; i++)
                {
                    if (GetByPlayer(player) == null)
                    {
                        Debug.Log($"Virtual Device {player} connected");
                        
                        var device = new VirtualDevice(player);
                        AllDevices.Add(device);
                        return device;
                    }
                }
            }
            
            return found;
        }
        
        internal VirtualDevice GetByPlayer(Player player)
        {
            foreach (var device in AllDevices)
            {
                if (device.Player == player)
                {
                    return device;
                }
            }

            return null;
        }
    }
}