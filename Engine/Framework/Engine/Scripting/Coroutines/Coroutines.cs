using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System;

namespace Hybrid
{
    // Internal
    internal sealed partial class Coroutines : Module<Coroutines>
    {
        private static readonly Dictionary<object, List<Coroutine>> Map = new();
        
        
        internal override void OnUpdate()
        {
            base.OnUpdate();
        }

        internal override void OnFixedUpdate()
        {
            base.OnFixedUpdate();
        }

        internal override void OnEndOfFrame()
        {
            base.OnEndOfFrame();
        }

        // Dispose
        internal override void OnDispose()
        {
            // For Each Coroutines List
            foreach (var coroutines in Map.Values)
            {
                // For Each Coroutine
                foreach (var coroutine in coroutines)
                {
                    // Stop
                    coroutine.Stop();
                }
            }
            
            // Clear
            Map.Clear();
            base.OnDispose();
        }
    }
    
    // Start Coroutine
    internal partial class Coroutines
    {
        internal static Coroutine StartCoroutine(object owner, Func<IEnumerator> enumerator)
        {
            if (owner != null && enumerator != null)
            {
                // Create Map Entry for owner
                if (!Map.TryGetValue(owner, out var list))
                {
                    list = new List<Coroutine>();
                    Map[owner] = list;
                }

                // Create Coroutine
                var coroutine = new Coroutine(owner, enumerator.Method.Name, enumerator());
                list.Add(coroutine);
                return coroutine;
            }

            return null;
        }

        internal static Coroutine StartCoroutine(object owner, string name)
        {
            // Invalid Owner
            if (owner != null)
            {
                // Find Method Using Reflection
                var method = owner.GetType().GetMethod(name,
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance |
                    BindingFlags.FlattenHierarchy);

                // Invalid Method
                if (method != null)
                {
                    // Invalid IEnumerator
                    if (method.Invoke(owner, null) is IEnumerator enumerator)
                    {
                        // Create Map Entry for owner
                        if (!Map.TryGetValue(owner, out var list))
                        {
                            list = new List<Coroutine>();
                            Map[owner] = list;
                        }

                        // Create Coroutine
                        var coroutine = new Coroutine(owner, name, enumerator);
                        list.Add(coroutine);
                        return coroutine;
                    }
                }
            }

            return null;
        }
    }
    
    // Stop Coroutine
    internal partial class Coroutines
    {
        internal static void StopCoroutine(object owner, Coroutine coroutine)
        {
            if (owner != null && coroutine != null)
            {
                // Find Owners Coroutines
                if (Map.TryGetValue(owner, out var coroutines))
                {
                    // For Each Coroutine
                    foreach(var c in coroutines)
                    {
                        // Stop
                        if (c == coroutine)
                        {
                            c.Stop();
                        }
                    }
                }
            }
        }

        internal static void StopCoroutine(object owner, string name)
        {
            // Invalid Owner
            if (owner != null)
            {
                // Find Method Using Reflection
                var method = owner.GetType().GetMethod(name,
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance |
                    BindingFlags.FlattenHierarchy);

                // Invalid Method
                if (method != null)
                {
                    // Invalid IEnumerator
                    if (method.Invoke(owner, null) is IEnumerator enumerator)
                    {
                        // Find Owners Coroutines
                        if (Map.TryGetValue(owner, out var coroutines))
                        {
                            // For Each Coroutine
                            foreach(var c in coroutines)
                            {
                                // Stop
                                if (c.Name == name)
                                {
                                    c.Stop();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    
    // Stop All Coroutines
    internal partial class Coroutines
    {
        internal static void StopAllCoroutines(object owner)
        {
            if (owner != null)
            {
                // Find Owners Coroutines
                if (Map.TryGetValue(owner, out var coroutines))
                {
                    // For Each Coroutine
                    foreach(var c in coroutines)
                    {
                        // Stop
                        c.Stop();
                    }
                }
            }
        }
    }
}