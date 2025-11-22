using System;

namespace Hybrid
{
    // Global Module Management
    public abstract partial class Module
    {
        private static readonly List<Module> Modules = new List<Module>();
        
        
        public static T Register<T>(T module) where T : Module
        {
            Modules.Add(module);
            return module;
        }

        public static T UnRegister<T>(T module) where T : Module
        {
            Modules.Remove(module);
            return module;
        }

        public static Module[] GetModules()
        {
            return Modules.ToArray();
        }
    }
    
    // Module
    public abstract partial class Module
    {
        internal virtual void OnEvent(SDL.Event e) {}
        internal virtual void OnInitialize() {}
        internal virtual void OnRender() {}
        internal virtual void OnUpdate() {}
    }
}