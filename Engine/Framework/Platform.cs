using System;
using SDL;

namespace Hybrid
{
    public abstract partial class Platform
    {
        public static Platform Current;

        public static void Create(Platform platform)
        {
            Current = platform;
            Current.Init();
        }
    }
    
    public abstract partial class Platform
    {
        public virtual bool IsRunning { get; set; } = true;
        public virtual bool Initialized { get; set; } = false;

        internal virtual Behaviour Behaviour { get; set; }
        internal virtual IFileSystem FileSystem { get; set; }
        internal virtual IDebug Debug { get; set; }
        
        public virtual void Init() {}
        public virtual void Run() {}
        
        internal virtual void Dispose()
        {
            // Dispose Everything
        }
        
        private const int events_per_peep = 64;
        private readonly SDL_Event[] events = new SDL_Event[events_per_peep];

        public void PollEvents()
        {
            SDL3.SDL_PumpEvents();

            int eventsRead;

            do
            {
                eventsRead = SDL3.SDL_PeepEvents(events, SDL_EventAction.SDL_GETEVENT, SDL_EventType.SDL_EVENT_FIRST, SDL_EventType.SDL_EVENT_LAST);
                for (int i = 0; i < eventsRead; i++)
                    Platform.Current.Behaviour.Update(events[i]);
            } while (eventsRead == events_per_peep);
        }
    }
}