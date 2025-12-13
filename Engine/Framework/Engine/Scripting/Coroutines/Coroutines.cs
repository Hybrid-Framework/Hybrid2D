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

        internal override void OnDispose()
        {
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
                // Create Coroutine
                Coroutine coroutine = new Coroutine(owner, enumerator.Method.Name, enumerator());

                // Create Map Entry for owner
                if (!Map.TryGetValue(owner, out var list))
                {
                    list = new List<Coroutine>();
                    Map[owner] = list;
                }

                // Assign Coroutine
                Debug.Log($"Coroutine '{enumerator.Method.Name}' started on '{owner.GetType().Name}'");
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
                        // Create Coroutine
                        Coroutine coroutine = new Coroutine(owner, name, enumerator);

                        // Create Map Entry for owner
                        if (!Map.TryGetValue(owner, out var list))
                        {
                            list = new List<Coroutine>();
                            Map[owner] = list;
                        }

                        // Assign Coroutine
                        Debug.Log($"Coroutine '{name}' started on '{owner.GetType().Name}'");
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
                if (Map.TryGetValue(owner, out var list))
                {
                    // Stop & Remove All Coroutines With Name
                    for (int i = list.Count - 1; i >= 0; i--)
                    {
                        if (list[i] == coroutine)
                        {
                            Debug.Log($"Coroutine '{list[i].Name}' stopped on '{owner.GetType().Name}'");

                            list[i].Stop();
                            list.RemoveAt(i);
                        }
                    }

                    // Remove Empty
                    if (list.Count == 0)
                    {
                        Map.Remove(owner);
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
                        if (Map.TryGetValue(owner, out var list))
                        {
                            // Stop & Remove All Coroutines With Name
                            for (int i = list.Count - 1; i >= 0; i--)
                            {
                                if (list[i].Name == name)
                                {
                                    Debug.Log($"Coroutine '{name}' stopped on '{owner.GetType().Name}'");

                                    list[i].Stop();
                                    list.RemoveAt(i);
                                }
                            }

                            // Remove Empty
                            if (list.Count == 0)
                            {
                                Map.Remove(owner);
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
                if (Map.TryGetValue(owner, out var list))
                {
                    // Stop All Coroutines
                    for (int i = list.Count - 1; i >= 0; i--)
                    {
                        Debug.Log($"Coroutine '{list[i].Name}' stopped on '{owner.GetType().Name}'");

                        list[i].Stop();
                        list.RemoveAt(i);
                    }

                    // Remove Empty
                    Map.Remove(owner);
                }
            }
        }
    }
    
    // Get Coroutines Count
    internal partial class Coroutines
    {
        internal static int GetCoroutinesCount(object owner)
        {
            if (Map.TryGetValue(owner, out var list))
            {
                return list.Count;
            }

            return 0;
        }
    }
}