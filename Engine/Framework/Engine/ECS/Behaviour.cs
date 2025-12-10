using System;
using System.Reflection;

namespace Hybrid
{
    public abstract partial class Behaviour : Object
    {
        private readonly HashSet<Type> RequireComponentsProcessing = new();
        
        public GameObject GameObject { get; internal set; }
        public Transform Transform { get; internal set; }
        
        private bool _Enabled { get; set; } = true;
        public bool Enabled
        {
            get => _Enabled;
            set
            {
                if (value != _Enabled && this is Component component)
                {
                    if(value) component.OnEnable();
                    if(!value) component.OnDisable();
                }

                _Enabled = value;
            }
        }
    }

    // Add Component
    public abstract partial class Behaviour
    {
        public Component AddComponent(Type type)
        {
            return AddComponentInternal
            (
                (Component)Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, null, null)
            );
        }
        
        public T AddComponent<T>() where T : Component
        {
            return AddComponentInternal
            (
                (T)Activator.CreateInstance(typeof(T), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, null, null)
            );
        }

        internal T AddComponentInternal<T>(T component) where T : Component
        {
            // Invalid Component
            if (component == null || GameObject == null)
                return null;
            
            // Component Type
            var type = component.GetType();
            
            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");
            
            // Disallow Multiple Component
            if (Attribute.IsDefined(type, typeof(DisallowMultipleComponentAttribute)))
            {
                // Has Component
                if (GetComponent<T>())
                {
                    throw new Exception($"Can't have multiple instances of '{type.Name}' on GameObject '{GameObject.Name}'");
                }
            }
            
            // Require Component
            if (Attribute.IsDefined(type, typeof(RequireComponentAttribute)))
            {
                // Processing Component
                if (!GameObject.RequireComponentsProcessing.Add(type))
                    return component;
                
                // For Each Required Component
                foreach (RequireComponentAttribute required in type.GetCustomAttributes(typeof(RequireComponentAttribute), true))
                {
                    // Find Component
                    if (!GetComponent(required.Type))
                    {
                        // Attach & Return
                        AddComponent(required.Type);
                    }
                }
                
                // Finished Processing
                GameObject.RequireComponentsProcessing.Remove(type);
            }

            // Set Properties
            component.GameObject = this.GameObject;
            component.Transform = this.Transform;
            component.Name = this.Name;
            
            // Add To GameObject
            // Debug.Log($"Component '{component.GetType()}' added to GameObject '{GameObject.Name}'");
            GameObject.Components.Add(component);
            return component;
        }
    }

    // Get Component
    public abstract partial class Behaviour
    {
        public Component GetComponent(Type type)
        {
            return GetComponentInternal(type);
        }

        public T GetComponent<T>() where T : Component
        {
            return GetComponentInternal(typeof(T)) as T;
        }
        
        internal Component GetComponentInternal(Type type)
        {
            // Invalid Component
            if (type == null || GameObject == null)
                return null;
            
            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");
            
            // Find Matching Component
            foreach (var component in GameObject.Components)
            {
                if (type.IsAssignableFrom(component.GetType()))
                {
                    return component;
                }
            }

            return null;
        }
    }
    
    // Get Components
    public abstract partial class Behaviour
    {
        public List<Component> GetComponents(Type type = null)
        {
            return GetComponentsInternal(type ?? typeof(Component));
        }

        public List<T> GetComponents<T>() where T : Component
        {
            return GetComponentsInternal(typeof(T)).Cast<T>().ToList();
        }
        
        internal List<Component> GetComponentsInternal(Type type)
        {
            // Invalid Component
            if (type == null || GameObject == null)
                return new List<Component>();
            
            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");

            // Create Results
            var results = new List<Component>();
            
            // Find All Matching Components
            foreach (var component in GameObject.Components)
            {
                if (type.IsAssignableFrom(component.GetType()))
                {
                    results.Add(component);
                }
            }

            return results;
        }
    }
    
    // Destroy Component
    public abstract partial class Behaviour
    {
        internal bool DestroyComponent(Type type)
        {
            return DestroyComponentInternal(GetComponent(type));
        }
        
        internal bool DestroyComponent<T>() where T : Component
        {
            return DestroyComponentInternal(GetComponent<T>());
        }

        internal bool DestroyComponentInternal<T>(T component) where T : Component
        {
            // Invalid Component
            if (component == null || GameObject == null)
                return false;
            
            // Component Type
            var type = component.GetType();
            
            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");

            // Check For Component
            if (GameObject.Components.Contains(component))
            {
                // Require Component
                if (!GameObject.IsDestroying())
                {
                    // For Each Component
                    foreach (var checkComponent in GameObject.Components)
                    {
                        // Component Type
                        var checkComponentType = checkComponent.GetType();
                        
                        // For Each Required Component
                        foreach (RequireComponentAttribute required in checkComponentType.GetCustomAttributes(typeof(RequireComponentAttribute), true))
                        {
                            if (required.Type == type)
                            {
                                throw new Exception($"Can't destroy Component '{type.Name}' on GameObject '{GameObject.Name}' because Component '{checkComponentType.Name}' requires it");
                            }
                        }
                    }
                }
                
                // Remove From GameObject
                // Debug.Log($"Component '{type.Name}' destroy on GameObject '{GameObject.Name}'");
                GameObject.Components.Remove(component);
                return true;
            }

            return false;
        }
    }
}