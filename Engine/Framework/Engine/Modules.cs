using System;

namespace Hybrid.Internal
{
    public class Modules
    {
        private List<Module> Cache { get; set; } = new List<Module>();
        
        
        internal T Register<T>(T module) where T : Module
        {
            Cache.Add(module);
            return module;
        }

        internal T UnRegister<T>(T module) where T : Module
        {
            Cache.Remove(module);
            module.OnDestroy();
            return module;
        }

        internal Module[] GetModules()
        {
            return Cache.ToArray();
        }

        internal Modules()
        {
            
        }
    }
}