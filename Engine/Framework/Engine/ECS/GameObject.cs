using System;

namespace Hybrid
{
    public partial class GameObject : Behaviour
    {
        private List<Component> Components { get; set; } = new List<Component>();
        public Scene Scene { get; private set; }
        public bool Enabled { get; set; }
        
        
        public GameObject(string name = null)
        {
            // Assign
            GameObject = this;
            Name = name ?? Name;

            // Create Transform
            Transform = AddComponentInternal(new Transform
            {
                GameObject = this,
                Name = Name
            });
            
            // Add To Scene
            Scene = Scenes.GetActiveScene();
            Scene.Add(this);
            
            // Activate
            Enabled = true;
        }

        internal override void OnDispose()
        {
            // Destroy All Components
            foreach (var component in GetComponents())
            {
                Object.Destroy(component);
            }
            
            // Remove From Scene
            Scene.Remove(this);
            base.OnDispose();
        }
    }

    // Add Component
    public partial class GameObject
    {
        public Component AddComponent(Type type)
        {
            return AddComponentInternal((Component)Activator.CreateInstance(type));
        }
        
        public T AddComponent<T>() where T : Component
        {
            return AddComponentInternal((Component)Activator.CreateInstance(typeof(T))) as T;
        }

        internal T AddComponentInternal<T>(T component) where T : Component
        {
            // Invalid Component
            if (component == null) return null;
            
            // Component Type
            var type = component.GetType();
            
            // Invalid Component
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");
            
            // Disallow Multiple Component
            if (Attribute.IsDefined(type, typeof(DisallowMultipleComponentAttribute)))
            {
                if (GetComponent<T>())
                {
                    throw new Exception($"Can't have multiple instances of '{type.Name}' on GameObject '{GameObject.Name}'");
                }
            }

            // Add To GameObject
            component.GameObject = this.GameObject;
            component.Transform = this.Transform;
            component.Name = this.Name;
            Components.Add(component);
            
            // Require Component
            if (Attribute.IsDefined(type, typeof(RequireComponentAttribute)))
            {
                // For Each Required Component
                foreach (RequireComponentAttribute required in type.GetCustomAttributes(typeof(RequireComponentAttribute), true))
                {
                    if (!GetComponent(required.Type))
                    {
                        AddComponent(required.Type);
                    }
                }
            }
            
            Console.WriteLine($"Component '{component.GetType()}' added to GameObject '{GameObject.Name}'");
            return component;
        }
    }

    // Get Component
    public partial class GameObject
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
            if (type == null) return null;
            
            // Invalid Component
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");
            
            // Find Matching Component
            foreach (var c in GetComponents())
            {
                if (type.IsAssignableFrom(c.GetType()))
                {
                    return c;
                }
            }

            return null;
        }
    }
    
    // Get Components
    public partial class GameObject
    {
        public Component[] GetComponents(Type type)
        {
            return GetComponentsInternal(type);
        }

        public T[] GetComponents<T>() where T : Component
        {
            return GetComponentsInternal(typeof(T)).Cast<T>().ToArray();
        }
        
        internal Component[] GetComponentsInternal(Type type)
        {
            // Invalid Component
            if (type == null) return Array.Empty<Component>();
            
            // Invalid Component
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");

            // Create Results
            var results = new List<Component>();
            
            // Find All Matching Components
            foreach (var c in GetComponents())
            {
                if (type.IsAssignableFrom(c.GetType()))
                {
                    results.Add(c);
                }
            }

            return results.ToArray();
        }
    }
    
    // Destroy Component
    public partial class GameObject
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
            if (component == null) return false;
            
            // Component Type
            var type = component.GetType();
            
            // Invalid Component
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");

            // Has Component
            if (GetComponents().Contains(component))
            {
                // Disallow Destroy Component
                if (Attribute.IsDefined(type, typeof(DisallowDestroyComponentAttribute)))
                {
                    if (!GameObject.IsDestroying())
                    {
                        throw new Exception($"Can't remove Component '{type.Name}' from GameObject '{GameObject.Name}'");
                    }
                }
                
                // Remove From GameObject
                Components.Remove(component);
                Destroy(component);
                
                Console.WriteLine($"Component '{type.Name}' removed from GameObject '{GameObject.Name}'");
                return true;
            }

            return false;
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