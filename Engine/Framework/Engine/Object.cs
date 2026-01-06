using System.Collections.Generic;
using System.Collections;
using System;

namespace Hybrid
{
    // Object
    public abstract partial class Object : IEquatable<Object>
    {
        private readonly Guid Guid = Guid.NewGuid();
        private bool Destroying { get; set; }
        private bool Destroyed { get; set; }
        
        
        internal virtual void OnDispose()
        {
            // Base OnDispose
        }
    }
    
    // Destroy
    public partial class Object
    {
        public static void Destroy(Object obj, float delay = 0)
        {
            if (!IsDestroyed(obj))
            {
                obj.Destroying = true;
                
                // Dispose
                obj.OnDispose();
                {
                    // Destroy
                    obj.Destroyed = true;
                        
                    // Debug Information
                    Debug.Log($"{obj.GetType().Name} Destroyed at {Time.FrameCount} {Time.Timer}");
                }
            }
        }
        
        internal static bool IsDestroying(Object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return true;
            }
            
            return obj.Destroying;
        }

        internal static bool IsDestroyed(Object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return true;
            }
            
            return obj.Destroyed;
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
            return !Destroyed ? $"{GetType().Name}" : $"Null";
        }

        public int GetInstanceID()
        {
            return Guid.GetHashCode();
        }
    }
}