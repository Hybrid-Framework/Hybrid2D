using System;

namespace Hybrid
{
    // Keyboard API
    public partial class Keyboard : Device
    {
        private readonly HashSet<Key> Down = new HashSet<Key>();
        private readonly HashSet<Key> Press = new HashSet<Key>();
        private readonly HashSet<Key> Release = new HashSet<Key>();
        
        public bool GetKey(Key key)
        {
            return Press.Contains(key);
        }

        public bool GetKeyUp(Key key)
        {
            return Release.Contains(key);
        }
        
        public bool GetKeyDown(Key key)
        {
            return Down.Contains(key);
        }
    }
    
    // Keyboard Handling
    public partial class Keyboard
    {
        internal override void OnEvent(SDL.Event e)
        {
            switch (e.type)
            {
                // Handle Keyboard Up
                case SDL.EventType.KeyboardButtonUp:
                {
                    var key = (Key)e.keyboard.keyCode;

                    Press.Remove(key);
                    Release.Add(key);
                    
                    break;
                }

                // Handle Keyboard Down
                case SDL.EventType.KeyboardButtonDown:
                {
                    var key = (Key)e.keyboard.keyCode;

                    if (!Press.Contains(key))
                    {
                        Down.Add(key);
                        Press.Add(key);
                    }
                    
                    break;
                }
            }
        }
        
        internal override void Reset()
        {
            Release.Clear();
            Down.Clear();
        }
        
        internal override void Dispose()
        {
            Down.Clear();
            Press.Clear();
            Release.Clear();
        }
    }
}