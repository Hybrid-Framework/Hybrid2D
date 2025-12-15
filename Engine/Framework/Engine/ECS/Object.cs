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


        internal Object()
        {
            // Invalid Scene
            if (Scenes.GetActiveScene() == null)
                throw new Exception($"Can't create '{GetType().Name}' with no scene loaded");
        }
        
        public static void Destroy(Object obj, float delay = 0)
        {
            if (obj != null)
            {
                // Delay
                if (delay > 0)
                {
                    // Local Coroutine
                    IEnumerator DestroyCoroutine()
                    {
                        yield return new WaitForSeconds(delay);
                        Destroy(obj);
                    }
                    
                    // Destroy After Seconds
                    Coroutines.StartCoroutine(obj, DestroyCoroutine());
                    return;
                }
                
                // Mark For Destroying
                if(obj.Destroying) return;
                obj.Destroying = true;
                
                // Destroy
                obj.OnDispose();
                obj.Destroyed = true;
            }
        }

        internal virtual void ThrowOnDestroyed()
        {
            if (Destroyed)
            {
                if (this is Behaviour behaviour)
                {
                    throw new NullReferenceException($"Trying to access ({GetType().Name}) on GameObject '{behaviour.Name}' but it has been destroyed");
                }
                
                throw new NullReferenceException($"Trying to access ({GetType().Name}) but it has been destroyed");
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