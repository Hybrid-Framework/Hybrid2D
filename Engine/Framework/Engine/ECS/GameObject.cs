using System;

namespace Hybrid
{
    public partial class GameObject : Behaviour
    {
        private List<Component> Components { get; set; } = new List<Component>();
        public Scene Scene { get; private set; }
        
        
        public GameObject(string name = null)
        {
            // Assign
            GameObject = this;
            Name = name ?? Name;

            // Create Transform
            Transform = AddComponent(new Transform
            {
                GameObject = this,
                Name = Name
            });
            
            // Add To Scene
            Scene = Scenes.GetActiveScene();
            Scene.Add(this);
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

    // Add Components
    public partial class GameObject
    {
        public Component AddComponent(Type type)
        {
            // Invalid Component
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type?.Name}' does not inherit from Component");
            
            // Create Component
            var component = (Component)Activator.CreateInstance(type);

            // Add Component
            return AddComponent(component);
        }
        
        public T AddComponent<T>() where T : Component
        {
            // Create Component
            var component = (Component)Activator.CreateInstance(typeof(T));
            
            // Add Component
            return AddComponent(component) as T;
        }

        internal T AddComponent<T>(T component) where T : Component
        {
            // Invalid Component
            if (component == null)
                return null;
            
            // Required Properties
            component.GameObject = this.GameObject;
            component.Transform = this.Transform;
            component.Name = this.Name;
            
            // Add To GameObject
            Console.WriteLine($"Component '{component.GetType()}' added to GameObject '{GameObject.Name}'");
            Components.Add(component);
            return component;
        }
    }

    // Get Components
    public partial class GameObject
    {
        public Component GetComponent(Type type)
        {
            // Invalid Component
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type?.Name}' does not inherit from Component");

            // Find Matching Component
            foreach (var component in GetComponents())
            {
                if (component.GetType() == type)
                {
                    return component;
                }
            }

            return null;
        }

        public T GetComponent<T>() where T : Component
        {
            // Find Matching Component
            foreach (var component in GetComponents())
            {
                if (component.GetType() == typeof(T))
                {
                    return component as T;
                }
            }

            return null;
        }

        public T[] GetComponents<T>() where T : Component
        {
            List<T> results = new List<T>();
            
            // Find Matching Components
            foreach (var component in GetComponents())
            {
                if (component.GetType() == typeof(T))
                {
                    results.Add(component as T);
                }
            }

            return results.ToArray();
        }
        
        public Component[] GetComponents()
        {
            return Components.ToArray();
        }
    }
    
    // Destroy Components
    public partial class GameObject
    {
        internal bool DestroyComponent(Type type)
        {
            // Invalid Component
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type?.Name}' does not inherit from Component");
            
            // Find Component
            var component = GetComponent(type);
            
            // Remove Component
            return DestroyComponent(component);
        }
        
        internal bool DestroyComponent<T>() where T : Component
        {
            // Find Component
            var component = GetComponent<T>();
            
            // Remove Component
            return DestroyComponent(component);
        }

        internal bool DestroyComponent<T>(T component) where T : Component
        {
            // Invalid Component
            if (component == null)
                return false;

            // Has Component
            if (Components.Contains(component))
            {
                // Remove From GameObject
                Console.WriteLine($"Component '{component.GetType().Name}' removed from GameObject '{GameObject.Name}'");
                Components.Remove(component);
                
                // Destroy
                Destroy(component);
                return true;
            }

            return false;
        }
    }
}