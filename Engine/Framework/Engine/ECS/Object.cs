using System;

namespace Hybrid
{
    // Object
    public abstract partial class Object : IEquatable<Object>
    {
        private readonly Guid Guid = Guid.NewGuid();
        private bool Destroying { get; set; }
        private bool Destroyed { get; set; }

        private string _Name { get; set; }
        public string Name
        {
            set => _Name = value;
            get
            {
                if (Destroyed)
                {
                    return $"{_Name} (Destroyed)";
                }

                return _Name;
            }
        }
        

        internal Object()
        {
            // Invalid Scene
            if (Scenes.GetActiveScene() == null)
                throw new Exception($"Can't create '{GetType().Name}' with no scene loaded");
            
            Name = GetType().Name;
        }

        public static void Destroy(Object obj)
        {
            if (obj != null)
            {
                // Mark For Destroying
                if(obj.Destroying) return;
                obj.Destroying = true;
                var name = obj.Name;
                
                // Destroy
                obj.OnDispose();
                obj.Destroyed = true;

                // Output
                if (obj is GameObject) Debug.Log("Destroyed: " + name);
            }
        }

        internal virtual void OnDispose()
        {
            // Internal dispose
        }
        
        public bool IsDestroying()
        {
            return Destroying;
        }

        public bool IsDestroyed()
        {
            return Destroyed;
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
            return GetType().Name;
        }

        public int GetInstanceID()
        {
            return Guid.GetHashCode();
        }
    }
}