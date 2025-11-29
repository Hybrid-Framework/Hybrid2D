using System;

namespace Hybrid
{
    // GameObject
    public partial class GameObject : Behaviour
    {
        private readonly List<Component> Components = new List<Component>();
        public Scene Scene { get; private set; }
        
        
        public GameObject(string name = null)
        {
            // Name
            Name = name ?? Name;
            GameObject = this;
            
            // Add To Scene
            Scene = Scenes.GetActiveScene();
            Scene?.Add(this);
            
            // Create Transform
            Transform = new Transform();
            Transform.Transform = Transform;
            Transform.GameObject = this;
            Transform.Name = Name;
            
            AttachComponent(Transform);
        }

        internal override void OnDestroy()
        {
            base.OnDestroy();
            
            // For Each Component
            foreach (var component in GetComponents())
            {
                // Destroy Component
                Object.Destroy(component);
            }
            
            // Remove From Scene
            Scene?.Remove(this);
        }
    }

    // Internal Component
    public partial class GameObject
    {
        internal T AttachComponent<T>(T component) where T : Component
        {
            // Invalid Component
            if (component == null)
                return null;
            
            // Assign
            component.Name = Name;
            component.GameObject = this;
            component.Transform = Transform;
            
            // Attach to GameObject
            Console.WriteLine($"Component '{component.GetType().Name}' attached to GameObject '{GameObject.Name}'");
            Components.Add(component);
            return component;
        }
        
        internal T DetachComponent<T>(T component) where T : Component
        {
            // Invalid Component
            if (component == null)
                return null;
            
            // Detach From GameObject
            Console.WriteLine($"Component '{component.GetType().Name}' detached from GameObject '{GameObject.Name}'");
            Components.Remove(component);
            return component;
        }
    }

    // Add Component
    public partial class GameObject
    {
        public T AddComponent<T>() where T : Component
        {
            // Create Instance
            var component = Activator.CreateInstance(typeof(T)) as Component;

            // Attach & Return
            return AttachComponent(component) as T;
        }
        
        public Component AddComponent(Type component)
        {
            // Invalid Component
            if (!typeof(Component).IsAssignableFrom(component))
                throw new ArgumentException($"Type '{component?.Name}' does not inherit from Component");
            
            // Create Instance
            var instance = Activator.CreateInstance(component) as Component;

            // Attach & Return
            return AttachComponent(instance);
        }
    }
    
    // Get Component
    public partial class GameObject
    {
        public T GetComponent<T>() where T : Component
        {
            // Find Matching Component
            foreach (var c in GetComponents())
            {
                if (c.GetType() == typeof(T))
                {
                    return c as T;
                }
            }

            return null;
        }

        public T[] GetComponents<T>() where T : Component
        {
            List<T> list = new();

            // Find Matching Components
            foreach (var c in GetComponents())
            {
                if (c.GetType() == typeof(T))
                {
                    list.Add(c as T);
                }
            }

            return list.ToArray();
        }
        
        public Component GetComponent(Type component)
        {
            // Find Matching Component
            foreach (var c in GetComponents())
            {
                if (c.GetType() == component)
                {
                    return c;
                }
            }

            return null;
        }
    }
    
    // Get All Components
    public partial class GameObject
    {
        public Component[] GetComponents()
        {
            return Components.ToArray();
        }
    }
}