using System;

namespace Hybrid
{
    // Object
    public partial class Object
    {
        private readonly Guid Guid = Guid.NewGuid();
        private bool IsDestroyed { get; set; }
        public string Name { get; set; }
        

        internal Object()
        {
            Name = GetType().Name;
        }

        public static void Destroy(Object obj)
        {
            if (obj != null)
            {
                // Destroy
                obj.OnDestroy();
                obj.IsDestroyed = true;
            }
        }

        internal virtual void OnDestroy()
        {
            // Called before object is marked as destroyed.
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
            if (b is null) return a.IsDestroyed;
            
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
            return Name;
        }

        public int GetInstanceID()
        {
            return Guid.GetHashCode();
        }
    }
}