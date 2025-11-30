using System;

namespace Hybrid
{
    // GameObject
    public partial class GameObject : Behaviour
    {
        private readonly List<Component> Components = new List<Component>();
        private readonly HashSet<Type> Processing = new HashSet<Type>();
        public string Layer { get; set; } = "Default";
        public string Tag { get; set; } = "Default";
        public Scene Scene { get; }
        
        
        public GameObject(string name = null)
        {
            // No Active Scene
            if (Scenes.GetActiveScene() == null)
                throw new Exception("Can't create GameObject when scene isn't loaded");
            
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

        internal override void OnDispose()
        {
            base.OnDispose();
            
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
    
    // Find Object
    public partial class GameObject
    {
        public static GameObject[] FindGameObjectsByName(string name)
        {
            List<GameObject> results = new();

            if (Scenes.GetActiveScene() != null)
            {
                // For Each GameObject In Scene
                foreach(var gameObject in Scenes.GetActiveScene().GetSceneGameObjects())
                {
                    // Find Match
                    if (gameObject.Name == name)
                    {
                        results.Add(gameObject);
                    }
                }
            }
            
            return results.ToArray();
        }
        
        public static GameObject[] FindGameObjectsByTag(string tag)
        {
            List<GameObject> results = new();

            if (Scenes.GetActiveScene() != null)
            {
                // For Each GameObject In Scene
                foreach(var gameObject in Scenes.GetActiveScene().GetSceneGameObjects())
                {
                    // Find Match
                    if (gameObject.Tag == tag)
                    {
                        results.Add(gameObject);
                    }
                }
            }
            
            return results.ToArray();
        }
        
        public static GameObject[] FindGameObjectsByLayer(string layer)
        {
            List<GameObject> results = new();

            if (Scenes.GetActiveScene() != null)
            {
                // For Each GameObject In Scene
                foreach(var gameObject in Scenes.GetActiveScene().GetSceneGameObjects())
                {
                    // Find Match
                    if (gameObject.Layer == layer)
                    {
                        results.Add(gameObject);
                    }
                }
            }
            
            return results.ToArray();
        }
    }

    // Add Component
    public partial class GameObject
    {
        public Component AddComponent(Type type)
        {
            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type?.Name}' does not inherit from Component");

            // Create Component Instance
            var component = Activator.CreateInstance(type) as Component;

            // Attach & Return
            return AddComponent(component);
        }
        
        public T AddComponent<T>() where T : Component
        {
            // Create Component Instance
            var component = Activator.CreateInstance(typeof(T)) as Component;

            // Attach & Return
            return AddComponent(component) as T;
        }

        internal T AddComponent<T>(T component) where T : Component
        {
            // Invalid Component
            if (component == null)
                return null;

            // Get Component Type
            var type = component.GetType();
            
            // DISALLOW MULTIPLE COMPONENT ATTRIBUTE
            if (Attribute.IsDefined(type, typeof(DisallowMultipleComponentAttribute)))
            {
                // Find Component
                if (GetComponent(type))
                {
                    throw new Exception($"Can't have multiple instances of '{type.Name}' on GameObject '{GameObject.Name}'");
                }
            }
            
            // REQUIRE COMPONENT ATTRIBUTE
            if (Attribute.IsDefined(type, typeof(RequireComponentAttribute)))
            {
                // Processing Component
                if (!Processing.Add(type))
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
                Processing.Remove(type);
            }

            // Assign
            component.Name = Name;
            component.GameObject = this;
            component.Transform = Transform;

            // Attach to GameObject
            Console.WriteLine($"Component '{type.Name}' attached to GameObject '{GameObject.Name}'");
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
                throw new Exception($"Type '{type?.Name}' does not inherit from Component");

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

            // Get Component Type
            var type = component.GetType();
            
            // Find Component
            if(GetComponent(type))
            {
                // DISALLOW DESTROY COMPONENT ATTRIBUTE
                if (Attribute.IsDefined(type, typeof(DisallowMultipleComponentAttribute)))
                {
                    if (!GameObject.IsDestroying())
                    {
                        throw new Exception($"Can't remove component '{type.Name}' from GameObject '{GameObject.Name}'");
                    }
                }
                
                // Remove Component
                Console.WriteLine($"Component '{type.Name}' detached from GameObject '{GameObject.Name}'");
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
                throw new Exception($"Type '{type?.Name}' does not inherit from Component");
            
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
            List<T> results = new();

            // Find Matching Components
            foreach (var c in GetComponents())
            {
                if (c.GetType() == typeof(T))
                {
                    results.Add(c as T);
                }
            }

            return results.ToArray();
        }
    }
    
    // Get All Components
    public partial class GameObject
    {
        public Component[] GetComponents()
        {
            // Return All Components
            return Components.ToArray();
        }
    }
}