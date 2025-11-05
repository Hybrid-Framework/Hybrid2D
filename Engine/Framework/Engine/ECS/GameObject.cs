namespace Hybrid
{
    // GameObject
    public partial class GameObject : Behaviour
    {
        internal List<Component> Components { get; private set; } = new();
        public string Tag { get; internal set; } = "Default";
        public Scene Scene { get; private set; }
        
        
        public GameObject(string name = null)
        {
            Name = name ?? Name;
            
            Scene = SceneManager.ActiveScene;
            Scene.Add(this);
            
            Transform = AddComponent<Transform>();
            GameObject = this;
        }

        protected internal override void OnProcess()
        {
            for(int i=0; i<Components.Count; i++)
            {
                if (Components[i] != null)
                {
                    Components[i].OnProcess();
                }
            }
        }

        protected internal override void OnDestroy()
        {
            for(int i=0; i<Components.Count; i++)
            {
                Destroy(Components[i]);
            }
            
            Scene.Remove(this);
        }
    }
    
    // Static Methods
    public partial class GameObject
    {
        public static GameObject[] FindByName(string name)
        {
            List<GameObject> gameObjects = new();

            if (SceneManager.ActiveScene != null)
            {
                var SceneObjects = SceneManager.ActiveScene.GetSceneObjects();

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

        public static GameObject[] FindByTag(string tag)
        {
            List<GameObject> gameObjects = new();

            if (SceneManager.ActiveScene != null)
            {
                var SceneObjects = SceneManager.ActiveScene.GetSceneObjects();

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
    
    // Methods
    public partial class GameObject
    {
        public T AddComponent<T>(T component) where T : Component
        {
            if (component == null) return null;
            if (component is Transform t && Transform == null) Transform = t;

            component.GameObject = this;
            component.Transform = Transform;

            Console.WriteLine($"Component '{component.Name}' added to GameObject '{Name}'");
            Components.Add(component);

            return component;
        }

        public T AddComponent<T>() where T : Component
        {
            var component = Activator.CreateInstance(typeof(T)) as Component;
            
            if (component == null) return null;
            if (component is Transform t && Transform == null) Transform = t;

            component.GameObject = this;
            component.Transform = Transform;
            
            Console.WriteLine($"Component '{component.Name}' added to GameObject '{Name}'");
            Components.Add(component);
            
            return component as T;
        }
        
        public void RemoveComponent<T>(T component) where T : Component
        {
            foreach(var c in Components.ToArray())
            {
                if (c == component)
                {
                    Console.WriteLine($"Component '{c.Name}' removed from GameObject '{Name}'");
                    Components.Remove(c);
                    break;
                }
            }
        }
        
        public void RemoveComponent<T>() where T : Component
        {
            foreach(var c in Components.ToArray())
            {
                if (c.GetType() == typeof(T))
                {
                    Console.WriteLine($"Component '{c.Name}' removed from GameObject '{Name}'");
                    Components.Remove(c);
                    break;
                }
            }
        }
        
        public void RemoveComponents<T>() where T : Component
        {
            foreach(var c in Components.ToArray())
            {
                if (c.GetType() == typeof(T))
                {
                    Console.WriteLine($"Component '{c}' removed from GameObject '{Name}'");
                    Components.Remove(c);
                }
            }
        }
        
        public T GetComponent<T>(T component) where T : Component
        {
            foreach(var c in Components.ToArray())
            {
                if (c == component)
                {
                    return c as T;
                }
            }

            return null;
        }

        public T GetComponent<T>() where T : Component
        {
            foreach(var c in Components.ToArray())
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
            List<T> components = new();
            
            foreach(var c in Components.ToArray())
            {
                if (c.GetType() == typeof(T))
                {
                    components.Add(c as T);
                }
            }
            
            return components.ToArray();
        }

        public Component[] GetComponents()
        {
            return Components.ToArray();
        }
    }
}