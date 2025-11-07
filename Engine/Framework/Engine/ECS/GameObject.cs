using System;

namespace Hybrid
{
    // GameObject
    public sealed partial class GameObject : Behaviour
    {
        private List<Component> Components { get; set; } = new();
        public string Tag { get; internal set; } = "Default";
        public Scene Scene { get; internal set; } = null;
        public bool Enabled { get; set; } = true;
        
        
        public GameObject(string name = null)
        {
            Name = name ?? Name;
            
            Scene = SceneManagement.ActiveScene;
            Scene.Add(this);
            
            GameObject = this;
            Transform = new Transform();
            Transform.Transform = Transform;
            Transform.GameObject = this;
            Transform.Name = Name;
            
            AttachComponent(Transform);
        }

        internal override void Dispose()
        {
            base.Dispose();
            
            // For Each Component
            foreach (var component in Components.ToArray())
            {
                // Destroy
                Destroy(component);
            }
            
            // Remove From Scene
            Scene.Remove(this);
        }
    }
    
    // Find GameObjects
    public sealed partial class GameObject
    {
        public static GameObject FindGameObjectWithName(string name)
        {
            if (SceneManagement.ActiveScene != null)
            {
                var SceneObjects = SceneManagement.ActiveScene.GetSceneObjects();

                for (int i = 0; i < SceneObjects.Length; i++)
                {
                    if (SceneObjects[i].Name == name)
                    {
                        return SceneObjects[i];
                    }
                }
            }

            return null;
        }
        
        public static GameObject[] FindGameObjectsWithName(string name)
        {
            List<GameObject> gameObjects = new();

            if (SceneManagement.ActiveScene != null)
            {
                var SceneObjects = SceneManagement.ActiveScene.GetSceneObjects();

                for (int i = 0; i < SceneObjects.Length; i++)
                {
                    if (SceneObjects[i].Name == name)
                    {
                        gameObjects.Add(SceneObjects[i]);
                    }
                }
            }

            return gameObjects.ToArray();
        }

        public static GameObject FindGameObjectWithTag(string tag)
        {
            if (SceneManagement.ActiveScene != null)
            {
                var SceneObjects = SceneManagement.ActiveScene.GetSceneObjects();

                for (int i = 0; i < SceneObjects.Length; i++)
                {
                    if (SceneObjects[i].Tag == tag)
                    {
                        return SceneObjects[i];
                    }
                }
            }

            return null;
        }
        
        public static GameObject[] FindGameObjectsWithTag(string tag)
        {
            List<GameObject> gameObjects = new();

            if (SceneManagement.ActiveScene != null)
            {
                var SceneObjects = SceneManagement.ActiveScene.GetSceneObjects();

                for (int i = 0; i < SceneObjects.Length; i++)
                {
                    if (SceneObjects[i].Tag == tag)
                    {
                        gameObjects.Add(SceneObjects[i]);
                    }
                }
            }

            return gameObjects.ToArray();
        }
    }
    
    // Add Components
    public sealed partial class GameObject
    {
        // Add Component
        public T AddComponent<T>(T component) where T : Component
        {
            // Invalid Component
            if (component == null)
                return null;

            // Find Existing
            var existing = GetComponent<T>();

            // Can't have multiple instances of component
            if (existing != null && existing.SingletonComponent())
                throw new Exception($"Can't have multiple instances of '{typeof(T).Name}' on GameObject '{GameObject.Name}'");

            // Add Component
            return AttachComponent(component);
        }

        public T AddComponent<T>() where T : Component
        {
            // Create Component
            Component component = Activator.CreateInstance(typeof(T)) as Component;

            // Invalid Component
            if (component == null)
                return null;

            // Find Existing
            var existing = GetComponent<T>();

            // Can't have multiple instances of component
            if (existing != null && existing.SingletonComponent())
                throw new Exception($"Can't have multiple instances of '{typeof(T).Name}' on GameObject '{GameObject.Name}'");

            // Add Component
            return AttachComponent(component) as T;
        }

        internal T AttachComponent<T>(T component) where T : Component
        {
            // Invalid Component
            if (component == null)
                return null;
            
            // Already Attached
            if (GetComponent(component))
                throw new Exception($"Component '{component.GetType().Name}' already added to GameObject '{GameObject.Name}'");

            // Assign Values
            component.Name = Name;
            component.GameObject = this;
            component.Transform = Transform;

            // Add Component To GameObject
            Console.WriteLine($"Component '{component.GetType().Name}' added to GameObject '{GameObject.Name}'");
            Components.Add(component);

            // Return
            return component as T;
        }
    }
    
    // Remove Components
    public sealed partial class GameObject
    {
        // Remove Component
        public void RemoveComponent<T>(T component) where T : Component
        {
            // Invalid Component
            if (component == null)
                return;

            // Find Matching Component
            foreach (var c in GetComponents())
            {
                if (c == component)
                {
                    // Cant Remove Required Component
                    if (component.RequiredComponent())
                        throw new Exception($"Can't destroy required '{typeof(T).Name}' on GameObject '{GameObject.Name}'");

                    // Remove Component
                    DetachComponent(c);
                    break;
                }
            }
        }

        public void RemoveComponent<T>() where T : Component
        {
            // Find Matching Component
            foreach (var c in GetComponents())
            {
                if (c.GetType() == typeof(T))
                {
                    // Cant Remove Required Component
                    if (c.RequiredComponent())
                        throw new Exception($"Can't destroy required '{typeof(T).Name}' on GameObject '{GameObject.Name}'");

                    // Remove Component
                    DetachComponent(c);
                    break;
                }
            }
        }

        public void RemoveComponents<T>() where T : Component
        {
            // Find Matching Components
            foreach (var c in GetComponents())
            {
                if (c.GetType() == typeof(T))
                {
                    // Cant Remove Required Component
                    if (c.RequiredComponent())
                        throw new Exception($"Can't destroy required '{typeof(T).Name}' on GameObject '{GameObject.Name}'");

                    // Remove Component
                    DetachComponent(c);
                }
            }
        }

        internal void DetachComponent<T>(T component) where T : Component
        {
            // Invalid Component
            if (component == null)
                return;

            // Remove Component From GameObject
            Console.WriteLine($"Component '{component.GetType().Name}' removed from GameObject '{Name}'");
            Components.Remove(component);
        }
    }
    
    // Get Components
    public sealed partial class GameObject
    {
        // Get Component
        public T GetComponent<T>(T component) where T : Component
        {
            // Find Matching Component
            foreach(var c in GetComponents())
            {
                if (c == component)
                {
                    // Return
                    return c as T;
                }
            }

            return null;
        }

        public T GetComponent<T>() where T : Component
        {
            // Find Matching Component
            foreach(var c in GetComponents())
            {
                if (c.GetType() == typeof(T))
                {
                    // Return
                    return c as T;
                }
            }
            
            return null;
        }
        
        public T[] GetComponents<T>() where T : Component
        {
            List<T> components = new();
            
            // Find Matching Components
            foreach(var c in GetComponents())
            {
                if (c.GetType() == typeof(T))
                {
                    // Add To List
                    components.Add(c as T);
                }
            }
            
            // Return All Components
            return components.ToArray();
        }

        public Component[] GetComponents()
        {
            // Return All Components
            return Components.ToArray();
        }
    }
}