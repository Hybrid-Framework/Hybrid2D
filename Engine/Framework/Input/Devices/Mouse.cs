using System;

namespace Hybrid
{
    // Mouse API
    public partial class Mouse : Device
    {
        private readonly HashSet<int> Release = new HashSet<int>();
        private readonly HashSet<int> Press = new HashSet<int>();
        private readonly HashSet<int> Down = new HashSet<int>();
        
        public Vector2 PositionDelta { get; private set; }
        public Vector2 ScrollDelta { get; private set; }
        public Vector2 Position { get; private set; }
        
        
        public bool GetMouseButton(int button)
        {
            return Press.Contains(button);
        }

        public bool GetMouseButtonUp(int button)
        {
            return Release.Contains(button);
        }
        
        public bool GetMouseButtonDown(int button)
        {
            return Down.Contains(button);
        }
    }
    
    // Mouse Handling
    public partial class Mouse
    {
        internal override void OnEvent(SDL.Event e)
        {
            switch (e.type)
            {
                // Handle Mouse Up
                case SDL.EventType.MouseButtonUp:
                {
                    var key = e.mouseButton.button switch
                    {
                        1 => 0, 2 => 2, 3 => 1, _ => -1
                    };

                    if (key != -1)
                    {
                        Press.Remove(key);
                        Release.Add(key);
                    }
                    
                    break;
                }
                
                // Handle Mouse Down
                case SDL.EventType.MouseButtonDown:
                {
                    var key = e.mouseButton.button switch
                    {
                        1 => 0, 2 => 2, 3 => 1, _ => -1
                    };

                    if (key != -1)
                    {
                        if (!Press.Contains(key))
                        {
                            Down.Add(key);
                            Press.Add(key);
                        }
                    }
                    
                    break;
                }
                
                // Handle Mouse Motion
                case SDL.EventType.MouseMotion:
                {
                    PositionDelta = new Vector2(e.mouseMotion.x_relative, e.mouseMotion.y_relative);
                    Position = new Vector2(e.mouseMotion.x, e.mouseMotion.y);
                    
                    break;
                }
                
                // Handle Mouse Wheel
                case SDL.EventType.MouseWheel:
                {
                    ScrollDelta = new Vector2(e.mouseWheel.x, e.mouseWheel.y);
                    
                    break;
                }
            }
        }
        
        internal override void Reset()
        {
            PositionDelta = Vector2.Zero;
            ScrollDelta = Vector2.Zero;
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