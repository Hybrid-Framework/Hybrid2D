using System;

namespace Hybrid
{
    // Clone
    internal static class Clone
    {
        internal static GameObject Shallow(Object obj)
        {
            // Invalid Object
            if (obj == null || obj is not Behaviour behaviour || behaviour.GameObject == null)
                throw new Exception($"Failed to instantiate '{nameof(obj)}' because no GameObject associated");

            // Create Copy Of Object
            return CopyGameObject(behaviour.GameObject);
        }
        
        internal static GameObject CopyGameObject(GameObject source)
        {
            // Create GameObject
            GameObject clone = new GameObject($"{source.Name} (Clone)")
            {
                Scene = source.Scene,
                Tag = source.Tag,
            };
            
            // Create Components
            foreach (var component in source.GetComponents())
            {
                try
                {
                    Component instance = (Component)Activator.CreateInstance(component.GetType());
                    
                    clone.AddComponent(instance);
                }
                catch
                {
                    // Ignore
                }
            }
            
            // Return
            return clone;
        }
    }
}