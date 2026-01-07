using System.Collections.Generic;
using System;

namespace Hybrid
{
    // Virtual
    internal partial class VirtualInputs
    {
        private readonly Dictionary<string, VirtualButton> Buttons = new Dictionary<string, VirtualButton>();
        private readonly Dictionary<string, VirtualStick> Sticks = new Dictionary<string, VirtualStick>();
        private readonly Dictionary<string, VirtualAxis> Axes = new Dictionary<string, VirtualAxis>();
    }

    // Button
    internal partial class VirtualInputs
    {
        internal VirtualButton CreateVirtualButton(string name)
        {
            if (!Buttons.TryGetValue(name, out var button))
            {
                button = new VirtualButton(name);
                Buttons[name] = button;
            }

            return button;
        }

        internal void DestroyVirtualButton(string name)
        {
            Buttons.Remove(name);
        }
    }

    // Stick
    internal partial class VirtualInputs
    {
        internal VirtualStick CreateVirtualStick(string name)
        {
            if (!Sticks.TryGetValue(name, out var stick))
            {
                stick = new VirtualStick(name);
                Sticks[name] = stick;
            }

            return stick;
        }

        internal void DestroyVirtualStick(string name)
        {
            Sticks.Remove(name);
        }
    }
    
    // Axis
    internal partial class VirtualInputs
    {
        internal VirtualAxis CreateVirtualAxis(string name)
        {
            if (!Axes.TryGetValue(name, out var axis))
            {
                axis = new VirtualAxis(name);
                Axes[name] = axis;
            }

            return axis;
        }

        internal void DestroyVirtualAxis(string name)
        {
            Axes.Remove(name);
        }
    }
}