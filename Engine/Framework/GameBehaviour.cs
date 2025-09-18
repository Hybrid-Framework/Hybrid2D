using static Engine.SDL2.SDL;
using System;

namespace Engine
{
    public class GameBehaviour : IDisposable
    {
        public virtual void Init()
        {
            
        }

        public virtual void Update()
        {
            
        }
        
        public virtual void Render()
        {
            
        }

        public virtual void Dispose()
        {
            // Do all disposing here behind the scenes
        }
    }
}