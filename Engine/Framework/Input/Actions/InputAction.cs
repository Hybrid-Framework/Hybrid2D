using System.Collections.Generic;
using System;

namespace Hybrid
{
    public class InputAction
    {
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
    }
}