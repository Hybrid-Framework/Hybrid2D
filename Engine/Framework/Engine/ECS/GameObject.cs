namespace Hybrid
{
    // GameObject
    public partial class GameObject : Behaviour
    {
        internal List<Component> Components { get; private set; } = new List<Component>();
        
        public Scene Scene { get; private set; }
        
        
        public GameObject(string name = null)
        {
            Name = name ?? Name;
            
            Scene = SceneManager.ActiveScene;
            Scene.Add(this);
            
            GameObject = this;
            Transform = AddComponent<Transform>();
        }

        protected internal override void OnProcess()
        {
            // For Each Component
            for(int i=0; i<Components.Count; i++)
            {
                if (Components[i] != null)
                {
                    // Process
                    Components[i].OnProcess();
                }
            }
        }

        protected internal override void OnDestroy()
        {
            // For Each Component
            for(int i=0; i<Components.Count; i++)
            {
                // Remove All Components
                Destroy(Components[i]);
            }
            
            // Remove Object
            Scene.Remove(this);
        }
    }
    
    // Component Management
    public partial class GameObject
    {
        public T AddComponent<T>(T component) where T : Component
        {
            if (component == null) return null;
            if (component is Transform t && Transform == null) Transform = t;

            component.GameObject = this;
            component.Transform = Transform;

            Console.WriteLine($"Component '{component.GetType().Name}' added to '{Name}'");
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
            
            Console.WriteLine($"Component '{component.GetType().Name}' added to '{Name}'");
            Components.Add(component);
            
            return component as T;
        }
        
        public void RemoveComponent<T>(T component) where T : Component
        {
            for(int i=0; i<Components.Count; i++)
            {
                if (Components[i] == component)
                {
                    Console.WriteLine($"Component '{Components[i].Name}' removed from '{GameObject.Name}'");
                    Components.RemoveAt(i);
                    
                    break;
                }
            }
        }
        
        public void RemoveComponent<T>() where T : Component
        {
            for(int i=0; i<Components.Count; i++)
            {
                if (Components[i].GetType() == typeof(T))
                {
                    Console.WriteLine($"Component '{Components[i].Name}' removed from '{GameObject.Name}'");
                    Components.RemoveAt(i);
                    
                    break;
                }
            }
        }
        
        public T GetComponent<T>(T component) where T : Component
        {
            for(int i=0; i<Components.Count; i++)
            {
                if (Components[i] == component)
                {
                    return Components[i] as T;
                }
            }

            return null;
        }

        public T GetComponent<T>() where T : Component
        {
            for(int i=0; i<Components.Count; i++)
            {
                if (Components[i].GetType() == typeof(T))
                {
                    return Components[i] as T;
                }
            }
            
            return null;
        }
    }
}