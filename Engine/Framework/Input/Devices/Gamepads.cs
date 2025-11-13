using System;

namespace Hybrid
{
    internal unsafe class Gamepads : Device
    {
        internal bool GetButtonDown(Button button, int player) => GetGamepad(player, out var gamepad) && gamepad.GetButtonDown(button);
        internal bool GetButtonUp(Button button, int player) => GetGamepad(player, out var gamepad) && gamepad.GetButtonUp(button);
        internal bool GetButton(Button button, int player) => GetGamepad(player, out var gamepad) && gamepad.GetButton(button);
        internal float GetAxis(Axis axis, int player) => GetGamepad(player, out var gamepad) ? gamepad.GetAxis(axis) : 0f;
        
        internal HashSet<Gamepad> Connected = new ();
        internal const int Max = 4;
        
        
        internal override void OnEvent(SDL.Event e)
        {
            // Gamepad Add
            if (e.type == SDL.EventType.GamepadDeviceAdded)
            {
                AddGamepad(e.gamepadDevice.gamepadID);
            }

            // Gamepad Remove
            if (e.type == SDL.EventType.GamepadDeviceRemoved)
            {
                RemoveGamepad(e.gamepadDevice.gamepadID);
            }

            // Events
            foreach (var gamepad in Connected)
            {
                gamepad.OnEvent(e);
            }
        }

        internal void AddGamepad(uint hid)
        {
            if (Connected.Count < Max)
            {
                for (int i = 0; i < Max; i++)
                {
                    if (!GetGamepad(i, out var gamepad))
                    {
                        Connected.Add(new Gamepad(SDL.OpenGamepad(hid), hid, i));
                        Console.WriteLine($"Gamepad ({i}) Connected");
                        break;
                    }
                }
            }
        }

        internal void RemoveGamepad(uint hid)
        {
            if (GetGamepad(hid, out Gamepad gamepad))
            {
                Console.WriteLine($"Gamepad ({gamepad.Player}) Disconnected");
                Connected.Remove(gamepad);
                gamepad.Dispose();
            }
        }
        
        internal bool GetGamepad(uint hid, out Gamepad found)
        {
            found = Connected.FirstOrDefault(g => g.HID == hid);
            
            return found != null;
        }

        internal bool GetGamepad(int player, out Gamepad found)
        {
            found = Connected.FirstOrDefault(g => g.Player == player);
            
            return found != null;
        }
        
        internal override void Reset()
        {
            foreach (var gamepad in Connected)
            {
                gamepad.Reset();
            }
        }
        
        internal override void Dispose()
        {
            foreach (var gamepad in Connected)
            {
                gamepad.Dispose();
            }
            
            Connected.Clear();
        }
    }
}