using System.Collections.Generic;
using System;

namespace Hybrid
{
    public class InputButton : InputAction
    {
        private readonly List<Func<bool>> GetKeyDownFunctions = new List<Func<bool>>();
        private readonly List<Func<bool>> GetKeyUpFunctions = new List<Func<bool>>();
        private readonly List<Func<bool>> GetKeyFunctions = new List<Func<bool>>();
        
        
        internal InputButton(string name)
        {
            this.Name = name;
        }
        
        public void Add(Func<bool> GetKey = null, Func<bool> GetKeyDown = null, Func<bool> GetKeyUp = null)
        {
            if (GetKey != null)
            {
                GetKeyFunctions.Add(GetKey);
            }

            if (GetKeyUp != null)
            {
                GetKeyUpFunctions.Add(GetKeyUp);
            }

            if (GetKeyDown != null)
            {
                GetKeyDownFunctions.Add(GetKeyDown);
            }
        }
        
        public void Remove(Func<bool> GetKey, Func<bool> GetKeyDown, Func<bool> GetKeyUp)
        {
            if (GetKey != null)
            {
                GetKeyFunctions.Remove(GetKey);
            }

            if (GetKeyUp != null)
            {
                GetKeyUpFunctions.Remove(GetKeyUp);
            }

            if (GetKeyDown != null)
            {
                GetKeyDownFunctions.Remove(GetKeyDown);
            }
        }
        
        public bool GetButton()
        {
            foreach (var function in GetKeyFunctions)
            {
                var value = function();
                
                if (value)
                {
                    return true;
                }
            }

            return false;
        }
        
        public bool GetButtonUp()
        {
            foreach (var function in GetKeyUpFunctions)
            {
                var value = function();
                
                if (value)
                {
                    return true;
                }
            }

            return false;
        }
        
        public bool GetButtonDown()
        {
            foreach (var function in GetKeyDownFunctions)
            {
                var value = function();
                
                if (value)
                {
                    return true;
                }
            }

            return false;
        }
    }
}