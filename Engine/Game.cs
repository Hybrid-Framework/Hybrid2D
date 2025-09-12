using static Engine.Internal.SDL2.SDL;
using System;

namespace Engine
{
    public class Game : IDisposable
    {
        public virtual void Init(string title, int width, int height, SDL_WindowFlags flags)
        {
            
        }

        public virtual bool Update()
        {
            return false;
        }

        public virtual void Dispose()
        {
            
        }
    }
}