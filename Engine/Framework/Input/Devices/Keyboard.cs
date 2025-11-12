using System;

namespace Hybrid
{
    // Keyboard Device
    internal partial class Keyboard : Device
    {
        private readonly HashSet<Key> Down = new HashSet<Key>();
        private readonly HashSet<Key> Press = new HashSet<Key>();
        private readonly HashSet<Key> Release = new HashSet<Key>();
        
        
        internal override void OnEvent(SDL.Event e)
        {
            // Keyboard Press
            if (e.type == SDL.EventType.KeyboardButtonDown)
            {
                var key = (Key)e.keyboard.keyCode;

                if (!Press.Contains(key))
                {
                    Down.Add(key);
                    Press.Add(key);
                }
            }
            
            // Keyboard Release
            if (e.type == SDL.EventType.KeyboardButtonUp)
            {
                var key = (Key)e.keyboard.keyCode;

                Press.Remove(key);
                Release.Add(key);
            }
        }
        
        internal bool GetKey(Key key)
        {
            return Press.Contains(key);
        }

        internal bool GetKeyUp(Key key)
        {
            return Release.Contains(key);
        }
        
        internal bool GetKeyDown(Key key)
        {
            return Down.Contains(key);
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