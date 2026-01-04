using System.Collections.Generic;
using System;

namespace Hybrid
{
    // InputActions
    internal class InputActions
    {
        private readonly Dictionary<string, InputButton> Buttons = new Dictionary<string, InputButton>();
        private readonly Dictionary<string, InputAxis> Axes = new Dictionary<string, InputAxis>();
        
        
        internal T CreateAction<T>(string name) where T : InputAction
        {
            if (typeof(T) == typeof(InputButton))
            {
                if (!Buttons.TryGetValue(name, out var button))
                {
                    button = new InputButton(name);
                    Buttons[name] = button;
                }

                return button as T;
            }
            else if (typeof(T) == typeof(InputAxis))
            {
                if (!Axes.TryGetValue(name, out var axis))
                {
                    axis = new InputAxis(name);
                    Axes[name] = axis;
                }

                return axis as T;
            }
            else
            {
                throw new Exception($"Unsupported inputAction type: {typeof(T)}");
            }
        }
        
        internal void DestroyAction<T>(string name) where T : InputAction
        {
            if (typeof(T) == typeof(InputButton))
            {
                Buttons.Remove(name);
                return;
            }
            else if (typeof(T) == typeof(InputAxis))
            {
                Axes.Remove(name);
                return;
            }
            else
            {
                throw new Exception($"Unsupported inputAction type: {typeof(T)}");
            }
        }
        
        internal T GetAction<T>(string name) where T : InputAction
        {
            if (typeof(T) == typeof(InputButton))
            {
                return Buttons.GetValueOrDefault(name) as T;
            }
            else if (typeof(T) == typeof(InputAxis))
            {
                return Axes.GetValueOrDefault(name) as T;
            }
            else
            {
                throw new Exception($"Unsupported inputAction type: {typeof(T)}");
            }
        }
    }
}