using System;

namespace Hybrid
{
    // Module<T> Singleton
    public abstract class Module<T> : Module where T : Module<T>
    {
        private static T Instance;

        internal static T FindOrCreate()
        {
            if (Instance == null)
            {
                Instance = Activator.CreateInstance(typeof(T), nonPublic: true) as T;

                if (Instance != null)
                {
                    Instance.OnCreate();
                    Modules.Add(Instance);
                }
            }

            return Instance;
        }
        
        protected Module()
        {
            FindOrCreate();
        }
    }
    
    // Module
    public class Module
    {
        protected static HashSet<Module> Modules = new HashSet<Module>();
        
        internal static Module[] GetModules()
        {
            return Modules.ToArray();
        }
        
        internal virtual void OnEvent(SDL.Event e) {}
        internal virtual void OnInitialize() {}
        internal virtual void OnRender() {}
        internal virtual void OnUpdate() {}
        internal virtual void OnDestroy() {}
        internal virtual void OnCreate() {}
    }
}