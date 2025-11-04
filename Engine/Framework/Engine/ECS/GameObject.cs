namespace Hybrid
{
    // GameObject
    public partial class GameObject : Behaviour
    {
        internal List<Component> Components { get; private set; } = new List<Component>();
        
        public Scene Scene { get; private set; }
        
        
        public GameObject(string name = null)
        {
            if (SceneManager.ActiveScene == null)
            {
                throw new Exception("Can't create object with no scene loaded");
            }
            
            GameObject = this;
            Transform = new Transform();
            Components.Add(Transform);
            
            Name = name ?? "Object";
            
            Scene = SceneManager.ActiveScene;
            Scene.Add(this);
        }

        protected internal override void OnProcess()
        {
            
        }

        protected internal override void OnDestroy()
        {
            
        }
    }
    
    // Component Management
    public partial class GameObject
    {
        public T AddComponent<T>() where T : Component
        {
            var component = Activator.CreateInstance(typeof(T)) as Component;

            if (component != null)
            {
                component.Name = typeof(T).Name;
                component.Transform = Transform;
                component.GameObject = this;
                
                Console.WriteLine($"Component '{component.Name}' added to '{GameObject.Name}'");
                Components.Add(component);
            }
            
            return component as T;
        }
        
        public void RemoveComponent<T>() where T : Component
        {
            foreach (var component in Components.ToList())
            {
                if (component.GetType() == typeof(T))
                {
                    Console.WriteLine($"Component '{component.Name}' removed from '{GameObject.Name}'");
                    Components.Remove(component);
                    return;
                }
            }
        }
        
        public T GetComponent<T>() where T : Component
        {
            foreach (var component in Components.ToList())
            {
                if (component.GetType() == typeof(T))
                {
                    Console.WriteLine($"Component '{component.Name}' removed from '{GameObject.Name}'");
                    return component as T;
                }
            }
            
            return null;
        }
    }
}