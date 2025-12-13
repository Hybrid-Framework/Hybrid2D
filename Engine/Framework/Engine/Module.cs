using System;

namespace Hybrid
{
    // Module<T> Singleton
    public abstract class Module<T> : Module where T : Module<T>
    {
        private static T _Instance;
        
        internal static T Instance
        {
            get => FindOrCreate();
        }

        internal static T FindOrCreate()
        {
            if (_Instance == null)
            {
                _Instance = Activator.CreateInstance(typeof(T), nonPublic: true) as T;
            }

            return _Instance;
        }
    }
    
    // Module
    public abstract class Module
    {
        private static readonly List<Module> Modules = new List<Module>();
        
        
        internal static T Register<T>(T module) where T : Module
        {
            Modules.Add(module);
            return module;
        }

        internal static T UnRegister<T>(T module) where T : Module
        {
            Modules.Remove(module);
            module.OnDispose();
            return module;
        }

        internal static Module[] GetModules()
        {
            return Modules.ToArray();
        }
        
        internal virtual void OnStartOfFrame() {}
        internal virtual void OnEvent(SDL.Event e) {}
        internal virtual void OnInitialize() {}
        internal virtual void OnUpdate() {}
        internal virtual void OnFixedUpdate() {}
        internal virtual void OnRender() {}
        internal virtual void OnEndOfFrame() {}
        
        internal virtual void OnDispose() {}
    }
}