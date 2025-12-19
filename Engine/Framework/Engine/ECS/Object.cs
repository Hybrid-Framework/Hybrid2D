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
        private bool Destroyed { get; set; }
        

        internal virtual void OnDispose()
        {
            // base dispose
        }
    }
    
    // Destroy
    public partial class Object
    {
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

                // Destroy later
                Objects.MarkObjectForDestroying(obj);
            }
        }

        public static void DestroyImmediate(Object obj)
        {
            if (!IsDestroying(obj))
            { 
                try
                {
                    // Dispose
                    obj.OnDispose();
                    {
                        // Destroy
                        obj.Destroyed = true;
                        obj.MarkedDontDestroyOnLoad = false;
                        
                        // Debug Information
                        Debug.Log($"{obj.GetType().Name} Destroyed");
                    }
                }
                catch (Exception ex)
                {
                    // Undo Destroy
                    Objects.UnMarkObjectForDestroying(obj);
                    obj.Destroyed = false;
                    
                    // Throw Exception
                    Exceptions.Throw(ex);
                }
            }
        }
        
        internal static bool IsDestroying(Object obj)
        {
            if (Objects.IsMarkedForDestroying(obj))
            {
                return true;
            }
            
            return IsDestroyed(obj);
        }

        public static bool IsDestroyed(Object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return true;
            }
            
            return obj.Destroyed;
        }
    }

    // Dont Destroy On Load
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
        
        internal static bool IsDontDestroyOnLoad(Object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            return obj.MarkedDontDestroyOnLoad;
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