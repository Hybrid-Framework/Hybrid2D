using System;

namespace Hybrid
{
    // Object
    public abstract partial class Object
    {
        private readonly Guid Guid = Guid.NewGuid();
        private bool Destroying { get; set; }
        private bool Destroyed { get; set; }
        public string Name { get; set; }
        

        internal Object()
        {
            Name = GetType().Name;
        }

        public static void Destroy(Object obj)
        {
            if (obj != null)
            {
                // Mark For Destroying
                if(obj.Destroying) return;
                obj.Destroying = true;
                
                // Destroy
                obj.OnDispose();
                obj.Destroyed = true;
            }
        }

        internal virtual void OnDispose()
        {
            // Internal dispose
        }
        
        public bool IsDestroying()
        {
            // Useful for knowing if an object is about to be destroyed
            return Destroying;
        }

        public bool IsDestroyed()
        {
            // Useful for knowing if an object has been destroyed
            return Destroyed;
        }
    }

    public partial class Object
    {
        public static T[] FindObjectsByType<T>() where T : Object
        {
            List<T> results = new();

            if (Scenes.GetActiveScene() != null)
            {
                foreach(var gameObject in Scenes.GetActiveScene().GetSceneGameObjects())
                {
                    if (gameObject is T t)
                    {
                        results.Add(t);
                    }
                    
                    foreach (Component component in gameObject.GetComponents())
                    {
                        if (component is T c)
                        {
                            results.Add(c);
                        }
                    }
                }
            }
            
            return results.ToArray();
        }
    }

    // Operators
    public partial class Object
    {
        public static implicit operator bool(Object obj)
        {
            return obj is not null && !obj.Destroyed;
        }
        
        public static bool operator !=(Object a, Object b)
        {
            return !(a == b);
        }

        public static bool operator ==(Object a, Object b)
        {
            if (a is null) return b?.Destroyed ?? true;
            if (b is null) return a.Destroyed;
            
            return ReferenceEquals(a, b);
        }

        public override bool Equals(object obj)
        {
            if (obj is Object other)
            {
                return Equals(other);
            }

            return false;
        }
        
        public bool Equals(Object obj)
        {
            return this == obj;
        }

        public override int GetHashCode()
        {
            return GetInstanceID();
        }

        public override string ToString()
        {
            return Destroyed ? "Null" : Name;
        }

        public int GetInstanceID()
        {
            return Destroyed ? 0 : Guid.GetHashCode();
        }
    }
}