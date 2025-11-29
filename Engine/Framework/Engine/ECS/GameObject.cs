using System;

namespace Hybrid
{
    // GameObject
    public partial class GameObject : Behaviour
    {
        private readonly List<Component> Components = new List<Component>();
        private readonly HashSet<Type> Processing = new HashSet<Type>();
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
            
            AddComponent(Transform);
        }

        internal override void OnDestroy()
        {
            base.OnDestroy();
            
            // For Each Component
            foreach (var component in GetComponents())
            {
                // Destroy Component
                Destroy(component);
            }
            
            // Remove From Scene
            Scene?.Remove(this);
        }
    }

    // Add Component
    public partial class GameObject
    {
        public Component AddComponent(Type type)
        {
            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new ArgumentException($"Type '{type?.Name}' does not inherit from Component");

            // Create Instance
            var component = Activator.CreateInstance(type) as Component;

            // Attach & Return
            return AddComponent(component);
        }
        
        public T AddComponent<T>() where T : Component
        {
            // Create Instance
            var component = Activator.CreateInstance(typeof(T)) as Component;

            // Attach & Return
            return AddComponent(component) as T;
        }

        internal T AddComponent<T>(T component) where T : Component
        {
            // Invalid Component
            if (component == null)
                return null;
            
            // Disallow Multiple Component
            // Can only have one instance of this Component per GameObject
            if (Attribute.IsDefined(component.GetType(), typeof(DisallowMultipleComponentAttribute)))
            {
                // Find Component
                if (GetComponent(component.GetType()))
                {
                    throw new Exception($"Can't have multiple instances of '{component.GetType().Name}' on GameObject '{GameObject.Name}'");
                }
            }
            
            // Require Component
            // Creates required Components for other Components
            if (Attribute.IsDefined(component.GetType(), typeof(RequireComponentAttribute)))
            {
                // Processing Component (Recursion)
                if (!Processing.Add(component.GetType()))
                    return component;
                
                // For Each Required Component
                foreach (RequireComponentAttribute required in component.GetType().GetCustomAttributes(typeof(RequireComponentAttribute), true))
                {
                    // Find Component
                    if (!GetComponent(required.Type))
                    {
                        // Attach & Return
                        AddComponent(required.Type);
                    }
                }
                
                // Finished Processing
                Processing.Remove(component.GetType());
            }

            // Assign
            component.Name = Name;
            component.GameObject = this;
            component.Transform = Transform;

            // Attach to GameObject
            Console.WriteLine($"Component '{component.GetType().Name}' attached to GameObject '{GameObject.Name}'");
            Components.Add(component);
            return component;
        }
    }
    
    // Remove Component
    public partial class GameObject
    {
        public void RemoveComponent(Type type)
        {
            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new ArgumentException($"Type '{type?.Name}' does not inherit from Component");

            // Find Component
            var component = GetComponent(type);

            // Attach & Return
            RemoveComponent(component);
        }
        
        public void RemoveComponent<T>() where T : Component
        {
            // Find Component
            var component = GetComponent<T>();

            // Remove & Return
            RemoveComponent(component);
        }

        internal void RemoveComponent<T>(T component) where T : Component
        {
            // Invalid Component
            if (component == null)
                return;
            
            // Find Component
            if(GetComponent(component.GetType()))
            {
                // Disallow Destroy Component
                // Can only be destroyed by destroying the GameObject
                if (Attribute.IsDefined(component.GetType(), typeof(DisallowMultipleComponentAttribute)))
                {
                    if (!GameObject.IsDestroying())
                    {
                        throw new Exception($"Can't remove component '{component.GetType().Name}' from GameObject '{GameObject.Name}'");
                    }
                }
                
                // Remove Component
                Console.WriteLine($"Component '{component.GetType().Name}' detached from GameObject '{GameObject.Name}'");
                Components.Remove(component);
                
                // Destroy
                Destroy(component);
            }
        }
    }
    
    // Get Component
    public partial class GameObject
    {
        public Component GetComponent(Type type)
        {
            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new ArgumentException($"Type '{type?.Name}' does not inherit from Component");
            
            // Find Matching Component
            foreach (var c in GetComponents())
            {
                if (c.GetType() == type)
                {
                    return c;
                }
            }

            return null;
        }
        
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