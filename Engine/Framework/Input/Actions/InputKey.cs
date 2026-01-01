using System;

namespace Hybrid
{
    internal class InputKey
    {
        private readonly Func<bool> GetKeyFunction;
        private readonly Func<bool> GetKeyUpFunction;
        private readonly Func<bool> GetKeyDownFunction;
        
        internal InputKey(Func<bool> GetKey, Func<bool> GetKeyDown, Func<bool> GetKeyUp)
        {
            this.GetKeyFunction = GetKey;
            this.GetKeyUpFunction = GetKeyUp;
            this.GetKeyDownFunction = GetKeyDown;
        }
        
        public bool GetKey()
        {
            return GetKeyFunction();
        }
        
        public bool GetKeyUp()
        {
            return GetKeyUpFunction();
        }
        
        public bool GetKeyDown()
        {
            return GetKeyDownFunction();
        }
    }
}