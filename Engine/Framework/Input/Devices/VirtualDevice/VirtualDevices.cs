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
        
        // Destroy
        internal void Destroy(Player player)
        {
            var result = GetByPlayer(player);
            
            if (result != null)
            {
                Debug.Log($"Virtual Device {result.Player} disconnected");
                
                AllDevices.Remove(result);
                result.OnDispose();
            }
        }

        // Create
        internal VirtualDevice Create(Player player)
        {
            var result = GetByPlayer(player);
            
            if (result == null)
            {
                for (int i = 0; i < MaxDevices; i++)
                {
                    if (GetByPlayer(player) == null)
                    {
                        Debug.Log($"Virtual Device {player} connected");
                        
                        result = new VirtualDevice(player);
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