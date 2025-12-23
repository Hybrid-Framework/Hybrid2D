using System.Collections.Generic;
using System.Collections;
using System;

namespace Hybrid
{
    // Object
    public abstract partial class Object : IEquatable<Object>
    {
        private readonly Guid Guid = Guid.NewGuid();
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
                // Delay
                if (delay > 0)
                {
                    // Destroy Coroutine
                    IEnumerator DestroyCoroutine()
                    {
                        yield return new WaitForSeconds(delay);
                        Destroy(obj);
                    }
                    
                    // Destroy After Delay
                    Coroutines.StartCoroutine(obj, DestroyCoroutine());
                    return;
                }

                // Mark For Destroying
                Objects.MarkObjectForDestroying(obj);
            }
        }

        public static void DestroyImmediate(Object obj)
        {
            if (!IsDestroyed(obj))
            {
                try
                {
                    // Mark For Destroying
                    Objects.MarkObjectForDestroying(obj);
                    
                    // Dispose
                    obj.OnDispose();
                    {
                        // Destroy
                        obj.Destroyed = true;
                        
                        // Debug Information
                        Debug.Log($"{obj.GetType().Name} Destroyed at {Time.FrameCount} {Time.Timer}");
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

        public static void DontDestroyOnLoad(Object obj)
        {
            if (!IsDestroyed(obj))
            {
                if (obj is Behaviour behaviour)
                {
                    if (behaviour.GameObject.Transform.Parent != null)
                    {
                        Debug.Warning($"Can only call '{nameof(DontDestroyOnLoad)}' on objects that don't have a parent");
                        return;
                    }
                    
                    Scenes.MoveGameObjectToScene(behaviour.GameObject, Scenes.DontDestroyOnLoad);
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

        internal static bool IsDestroyed(Object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return true;
            }
            
            return obj.Destroyed;
        }
    }

    // Find By Type
    public partial class Object
    {
        public static T[] FindObjectsByType<T>(bool activeOnly = false) where T : Object
        {
            var results = new List<T>();

            // For Each Active Scene
            foreach(var scene in Scenes.GetActiveScenes())
            {
                // For Each Root GameObject In Scene
                foreach (var gameObject in scene.GetRootGameObjects())
                {
                    // If Active Only And Disabled
                    if (gameObject == null) continue;
                    if (activeOnly && !gameObject.Active) continue;

                    if (typeof(T).IsAssignableFrom(gameObject.GetType()))
                    {
                        results.Add(gameObject as T);
                    }

                    // For Each Child Components Of GameObject (Including Parent)
                    foreach (var component in gameObject.GetComponentsInChildren<Component>(true))
                    {
                        // If Active Only And Disabled
                        if (component == null) continue;
                        if (activeOnly && !component.Enabled) continue;

                        if (typeof(T).IsAssignableFrom(component.GetType()))
                        {
                            results.Add(component as T);
                        }
                    }
                }
            }

            return results.ToArray();
        }
        
        public static T FindObjectByType<T>(bool activeOnly = false) where T : Object
        {
            // For Each Active Scene
            foreach(var scene in Scenes.GetActiveScenes())
            {
                // For Each Root GameObject In Scene
                foreach (var gameObject in scene.GetRootGameObjects())
                {
                    // If Active Only And Disabled
                    if(gameObject == null) continue;
                    if(activeOnly && !gameObject.Active) continue;
                
                    if (typeof(T).IsAssignableFrom(gameObject.GetType()))
                    {
                        return gameObject as T;
                    }

                    // For Each Child Components Of GameObject (Including Parent)
                    foreach (var component in gameObject.GetComponentsInChildren<Component>(true))
                    {
                        // If Active Only And Disabled
                        if(component == null) continue;
                        if(activeOnly && !component.Enabled) continue;
                    
                        if (typeof(T).IsAssignableFrom(component.GetType()))
                        {
                            return component as T;
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