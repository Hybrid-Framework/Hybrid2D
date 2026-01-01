using System.Collections.Generic;
using System;

namespace Hybrid
{
    public class InputAction
    {
        private readonly List<InputAxis> Axis = new List<InputAxis>();
        private readonly List<InputKey> Keys = new List<InputKey>();
        internal string Name;
        
        internal InputAction(string name)
        {
            this.Name = name;
        }
        
        public void Add(Func<bool> GetKey, Func<bool> GetKeyDown, Func<bool> GetKeyUp)
        {
            Keys.Add(new InputKey(GetKey, GetKeyDown, GetKeyUp));
        }
        
        public void Add(Func<float> Value)
        {
            Axis.Add(new InputAxis(Value));
        }
        
        public bool GetKey()
        {
            foreach (var key in Keys)
            {
                if (key.GetKey())
                {
                    return true;
                }
            }

            return false;
        }

        public bool GetKeyDown()
        {
            foreach (var key in Keys)
            {
                if (key.GetKeyDown())
                {
                    return true;
                }
            }

            return false;
        }
        
        public bool GetKeyUp()
        {
            foreach (var key in Keys)
            {
                if (key.GetKeyUp())
                {
                    return true;
                }
            }

            return false;
        }

        public float GetAxis()
        {
            foreach (var axis in Axis)
            {
                if (axis.Value() > 0)
                {
                    return axis.Value();
                }
            }

            return 0;
        }
    }
}