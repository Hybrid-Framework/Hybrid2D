using System.Collections.Generic;
using System.Collections;
using System;

namespace Hybrid
{
    // Object
    public abstract partial class Object : IEquatable<Object>
    {
        private readonly Guid Guid = Guid.NewGuid();
        
        private bool MarkedDontDestroyOnLoad { get; set; }
        private bool MarkedDestroying { get; set; }
        private bool MarkedDestroyed { get; set; }
        

        internal virtual void OnDispose()
        {
            // Internal dispose
        }
    }
    
    // Object Destruction
    public partial class Object
    {
        public static void DontDestroyOnLoad(Object obj)
        {
            if (!IsDestroyed(obj))
            {
                if (obj is Behaviour behaviour)
                {
                    if (behaviour.GameObject.Transform.Parent != null)
                    {
                        Debug.Warning($"Can only call '{nameof(DontDestroyOnLoad)}' on root Objects");
                        return;
                    }
            
                    behaviour.GameObject.MarkedDontDestroyOnLoad = true;
                    behaviour.MarkedDontDestroyOnLoad = true;
                }
            }
        }
        
        public static void Destroy(Object obj, float delay = 0)
        {
            if (!IsDestroyed(obj))
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
                
                // Destroy
                if (!obj.MarkedDestroying)
                {
                    // Mark Destroying
                    obj.MarkedDestroying = true;
                    
                    try
                    {
                        // Dispose
                        obj.OnDispose();
                    
                        // Mark All
                        obj.MarkedDestroyed = true;
                        obj.MarkedDestroying = false;
                        obj.MarkedDontDestroyOnLoad = false;
                    }
                    catch (Exception ex)
                    {
                        // Unmark All
                        obj.MarkedDestroyed = false;
                        obj.MarkedDestroying = false;
                    
                        // Throw Exception
                        Exceptions.Throw(ex);
                    }
                }
            }
        }

        public static bool IsDontDestroyOnLoad(Object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            return obj.MarkedDontDestroyOnLoad;
        }
        
        public static bool IsDestroying(Object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }
            
            return obj.MarkedDestroying;
        }

        public static bool IsDestroyed(Object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }
            
            return obj.MarkedDestroyed;
        }
    }

    // Operators
    public partial class Object
    {
        public static implicit operator bool(Object obj)
        {
            return obj is not null && !obj.MarkedDestroyed;
        }
        
        public static bool operator !=(Object a, Object b)
        {
            return !(a == b);
        }

        public static bool operator ==(Object a, Object b)
        {
            if (a is null) return b?.MarkedDestroyed ?? true;
            if (b is null) return a.MarkedDestroyed;
            
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
            return !MarkedDestroyed ? $"{GetType().Name}" : $"{GetType().Name} (Destroyed)";
        }

        public int GetInstanceID()
        {
            return !MarkedDestroyed ? Guid.GetHashCode() : 0;
        }
    }
}