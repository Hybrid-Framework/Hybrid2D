using static Hybrid.SDL2.SDL;
using System;

namespace Hybrid
{
    public abstract class Behaviour
    {
        public virtual void Init()
        {
            
        }
        
        public virtual void Events(SDL_Event e)
        {
            
        }

        public virtual void Update()
        {
            
        }
        
        public virtual void Render()
        {
            
        }
    }
}