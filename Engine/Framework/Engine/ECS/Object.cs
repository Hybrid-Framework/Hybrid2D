using System;

namespace Hybrid
{
    // Object
    public partial class Object : IEquatable<Object>
    {
        private Guid Guid { get; set; } = Guid.NewGuid();
        private bool IsDestroyed { get; set; }
        public string Name { get; set; }
        

        protected Object()
        {
            Name = GetType().Name;
            
            if (SceneManagement.ActiveScene == null)
            {
                throw new Exception($"Can't create '{this.Name}' because no scene is loaded");
            }
        }

        internal virtual void Dispose()
        {
            // Dispose logic called by Destroy(obj);
            // Implement this in types that inherit Object
            // This gives us control over what happens when destroyed
            // Called just before object is marked as destroyed
        }

        internal virtual Object Clone()
        {
            return null;
        }
    }
    
    // Static Methods
    public partial class Object
    {
        public static void Destroy(Object obj)
        {
            if (obj != null && !obj.IsDestroyed)
            {
                Console.WriteLine($"Destroyed: {obj.Name}");
                
                obj.Dispose();
                obj.IsDestroyed = true;
            }
        }

        public static T Instantiate<T>(T obj) where T : Object
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            
            Console.WriteLine("Clone: " + typeof(T).Name);
            return obj.Clone() as T;
        }
        
        public static T[] FindObjectsOfType<T>() where T : Object
        {
            List<T> objects = new();

            if (SceneManagement.ActiveScene != null)
            {
                foreach(var obj in SceneManagement.ActiveScene.GetSceneObjects())
                {
                    if (obj is T t)
                    {
                        objects.Add(t);
                    }
                    
                    foreach (Component component in obj.GetComponents())
                    {
                        if (component is T c)
                        {
                            objects.Add(c);
                        }
                    }
                }
            }
            
            return objects.ToArray();
        }
        
        public static T FindFirstObjectByType<T>() where T : Object
        {
            if (SceneManagement.ActiveScene != null)
            {
                foreach(var obj in SceneManagement.ActiveScene.GetSceneObjects())
                {
                    if (obj is T t)
                    {
                        return t;
                    }
                    
                    foreach (Component component in obj.GetComponents())
                    {
                        if (component is T c)
                        {
                            return c;
                        }
                    }
                }
            }
            
            return null;
        }
    }

    // Operators
    public partial class Object
    {
        public static implicit operator bool(Object obj)
        {
            return obj is not null && !obj.IsDestroyed;
        }
        
        public static bool operator !=(Object a, Object b)
        {
            return !(a == b);
        }

        public static bool operator ==(Object a, Object b)
        {
            if (a is null) return b?.IsDestroyed ?? true;
            if (b is null) return a?.IsDestroyed ?? true;
            
            return ReferenceEquals(a, b);
        }

        public bool Equals(Object other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            return obj is Object other && Equals(other);
        }

        public override int GetHashCode()
        {
            return GetInstanceID();
        }

        public override string ToString()
        {
            return Name;
        }
        
        public int GetInstanceID()
        {
            return Guid.GetHashCode();
        }
    }
}