namespace Hybrid
{
    // Entity
    public partial class Entity : Object
    {
        internal List<Component> Components { get; private set; } = new List<Component>();
        public Transform Transform { get; private set; }
        public Scene Scene { get; private set; }
        
        
        public Entity(string name = null)
        {
            if (SceneManager.ActiveScene == null)
            {
                throw new Exception("Can't create object with no scene loaded");
            }
            
            Transform = AddComponent<Transform>();
            Scene = SceneManager.ActiveScene;
            Name = name ?? "Object";
            
            Scene.Add(this);
        }

        internal override void Process()
        {
            Console.WriteLine($"Updating {Name} ");
            
            foreach (var component in Components)
            {
                component.Process();
            }
        }
        
        public void Destroy()
        {
            if (!IsDestroyed)
            {
                IsDestroyed = true;

                foreach (var component in Components.ToList())
                {
                    Components.Remove(component);
                }
                
                Scene.Remove(this);
            }
        }
    }
    
    // Component Management
    public partial class Entity
    {
        public T AddComponent<T>() where T : Component
        {
            var instance = Activator.CreateInstance(typeof(T)) as Component;

            if (instance != null)
            {
                instance.Name = typeof(T).Name;
                instance.Transform = Transform;
                instance.Entity = this;
                
                Components.Add(instance);
            }
            
            return instance as T;
        }
        
        public void RemoveComponent<T>() where T : Component
        {
            foreach (var component in Components.ToList())
            {
                if (component is T target)
                {
                    Components.Remove(target);
                    return;
                }
            }
        }
        
        public T GetComponent<T>() where T : Component
        {
            foreach (var component in Components.ToList())
            {
                if (component is T target)
                {
                    return target;
                }
            }
            
            return null;
        }
    }
}