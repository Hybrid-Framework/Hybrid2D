using System;

namespace Hybrid
{
    // Mouse Device
    internal partial class Mouse : Device
    {
        private readonly HashSet<int> Release = new HashSet<int>();
        private readonly HashSet<int> Press = new HashSet<int>();
        private readonly HashSet<int> Down = new HashSet<int>();
        
        internal Vector2 PositionDelta { get; private set; }
        internal Vector2 ScrollDelta { get; private set; }
        internal Vector2 Position { get; private set; }
        
        
        internal override void OnEvent(SDL.Event e)
        {
            // Mouse Press
            if (e.type == SDL.EventType.MouseButtonDown)
            {
                // Remap Index
                var key = e.mouseButton.button switch { 1 => 0, 2 => 2, 3 => 1, _ => -1 };

                if (key != -1)
                {
                    if (!Press.Contains(key))
                    {
                        Down.Add(key);
                        Press.Add(key);
                    }
                }
            }
            
            // Mouse Release
            if (e.type == SDL.EventType.MouseButtonUp)
            {
                // Remap Index
                var key = e.mouseButton.button switch { 1 => 0, 2 => 2, 3 => 1, _ => -1 };

                if (key != -1)
                {
                    Press.Remove(key);
                    Release.Add(key);
                }
            }
            
            // Scroll Delta
            if (e.type == SDL.EventType.MouseWheel)
            {
                ScrollDelta = new Vector2(e.mouseWheel.x, e.mouseWheel.y);
            }

            // Position & Position Delta
            if (e.type == SDL.EventType.MouseMotion)
            {
                PositionDelta = new Vector2(e.mouseMotion.x_relative, e.mouseMotion.y_relative);
                Position = new Vector2(e.mouseMotion.x, e.mouseMotion.y);
            }
        }
        
        internal bool GetMouseButton(int button)
        {
            return Press.Contains(button);
        }

        internal bool GetMouseButtonUp(int button)
        {
            return Release.Contains(button);
        }
        
        internal bool GetMouseButtonDown(int button)
        {
            return Down.Contains(button);
        }
        
        internal override void Reset()
        {
            ScrollDelta = Vector2.Zero;
            PositionDelta = Vector2.Zero;
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