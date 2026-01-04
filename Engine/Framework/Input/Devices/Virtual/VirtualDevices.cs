using System.Collections.Generic;
using System;

namespace Hybrid
{
    internal class VirtualDevices : InputDevices
    {
        internal readonly List<VirtualDevice> AllDevices = new List<VirtualDevice>();
        internal const int MaxDevices = 4;
        

        // Dispose
        internal override void OnDispose()
        {
            foreach (var virtualDevice in AllDevices.ToArray())
            {
                Destroy(virtualDevice.Device);
            }
        }

        // Reset
        internal override void OnReset()
        {
            foreach (var virtualDevice in AllDevices)
            {
                virtualDevice.OnReset();
            }
        }

        // Destroy
        internal void Destroy(ulong device)
        {
            var result = GetByDevice(device);
            
            if (result != null)
            {
                Debug.Log($"Keyboard {result.Device} {result.Player} disconnected");
                
                AllDevices.Remove(result);
                result.OnDispose();
            }
        }

        // Create
        internal VirtualDevice Create(ulong device)
        {
            var result = GetByDevice(device);
            
            if (result == null)
            {
                for (int i = 0; i < MaxDevices; i++)
                {
                    var player = (Player)i;
                    
                    if (GetByPlayer(player) == null)
                    {
                        Debug.Log($"Virtual Device {device} {player} connected");
                        
                        result = new VirtualDevice(device, player);
                        AllDevices.Add(result);
                        return result;
                    }
                }
            }
            
            return result;
        }
        
        // Get By Player
        internal VirtualDevice GetByPlayer(Player player)
        {
            foreach (var virtualDevice in AllDevices)
            {
                if (virtualDevice.Player == player)
                {
                    return virtualDevice;
                }
            }

            return null;
        }

        // Get By Device
        internal VirtualDevice GetByDevice(ulong device)
        {
            foreach (var virtualDevice in AllDevices)
            {
                if (virtualDevice.Device == device)
                {
                    return virtualDevice;
                }
            }

            return null;
        }
    }
}