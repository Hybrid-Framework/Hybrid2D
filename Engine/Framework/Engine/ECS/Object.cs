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
            
            if (SceneManager.ActiveScene == null)
            {
                throw new Exception($"Can't create Object '{Name}' with no scene loaded");
            }
        }
        
        protected internal virtual void OnInitialize()
        {
            
        }
        
        protected internal virtual void OnProcess()
        {
            
        }

        protected internal virtual void OnDestroy()
        {
            
        }
    }
    
    // Static Methods
    public partial class Object
    {
        public static void Destroy(Object obj)
        {
            if (obj != null && !obj.IsDestroyed)
            {
                obj.OnDestroy();
                obj.IsDestroyed = true;
            }
        }
        
        public static T[] FindObjectsOfType<T>() where T : Object
        {
            List<T> objects = new();

            if (SceneManager.ActiveScene != null)
            {
                foreach(var obj in SceneManager.ActiveScene.GetSceneObjects())
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
            if (SceneManager.ActiveScene != null)
            {
                foreach(var obj in SceneManager.ActiveScene.GetSceneObjects())
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