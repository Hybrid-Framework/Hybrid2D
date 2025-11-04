using System;

namespace Hybrid
{
    // Object
    public partial class Object : IEquatable<Object>
    {
        public string Name { get; set; } = "Object";
        
        private Guid Guid { get; set; } = Guid.NewGuid();
        private bool IsDestroyed { get; set; }
        

        public int GetInstanceID()
        {
            return Guid.GetHashCode();
        }

        public static void Destroy(Object obj)
        {
            if (obj == null) return;

            if (!obj.IsDestroyed)
            {
                obj.IsDestroyed = true;
                obj.OnDestroy();
            }
        }

        protected internal virtual void OnDestroy()
        {
            // What happens on destroyed?
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
    }
}