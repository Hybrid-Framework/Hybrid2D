using System;

namespace Hybrid
{
    // Object
    public partial class Object : IEquatable<Object>
    {
        protected internal bool IsDestroyed { get; set; } = false;
        public string Name { get; set; }
        private Guid Guid { get; set; }
        

        protected Object()
        {
            Guid = Guid.NewGuid();
        }

        public int GetInstanceID()
        {
            return Guid.GetHashCode();
        }

        internal virtual void Process()
        {
            
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