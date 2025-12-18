using System.Collections.Generic;
using System.Reflection;
using System;

namespace Hybrid
{
    // Internal
    internal sealed partial class Invokes : Module<Invokes>
    {
        private static readonly Dictionary<Object, List<Invoke>> AllInvokes = new();
        
        
        // Update
        internal override void OnUpdate()
        {
            // For Each Owner
            foreach (var owner in AllInvokes.Keys.ToArray())
            {
                // For Each Invoke List In Owner
                if (AllInvokes.TryGetValue(owner, out var list))
                {
                    // Process Invokes
                    for (int i = list.Count - 1; i >= 0; i--)
                    {
                        var invoke = list[i];

                        if (invoke.Done)
                        {
                            list.RemoveAt(i);
                            continue;
                        }

                        invoke.MoveNext();
                    }

                    // Remove Owner
                    if (list.Count == 0)
                    {
                        AllInvokes.Remove(owner);
                    }
                }
            }
        }

        // Dispose
        internal override void OnDispose()
        {
            // For Each Owner
            foreach (var invokes in AllInvokes.Values.ToArray())
            {
                foreach (var invoke in invokes)
                {
                    invoke.Stop();
                }
            }
            
            // Clear
            AllInvokes.Clear();
        }
    }

    // Invokes
    internal partial class Invokes
    {
        internal static void StartInvokeRepeating(Object owner, string name, float delay, float repeat)
        {
            if (owner != null)
            {
                var method = owner.GetType().GetMethod(name,
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance |
                    BindingFlags.FlattenHierarchy);

                // Invalid Method
                if (method != null)
                {
                    // Invalid Parameters
                    if (method.GetParameters().Length <= 0)
                    {
                        // Cancel Previous
                        StopInvoke(owner, name);
                        
                        // Create Invoke
                        var action = (Action)Delegate.CreateDelegate(typeof(Action), owner, method);

                        if (!AllInvokes.TryGetValue(owner, out var list))
                        {
                            list = new List<Invoke>();
                            AllInvokes[owner] = list;
                        }

                        var invoke = new Invoke(owner, action, name, Time.Timer + delay, repeat, true);
                        list.Add(invoke);
                    }
                }
            }
        }
        
        internal static void StartInvoke(Object owner, string name, float delay)
        {
            if (owner != null)
            {
                var method = owner.GetType().GetMethod(name,
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance |
                    BindingFlags.FlattenHierarchy);

                // Invalid Method
                if (method != null)
                {
                    // Invalid Parameters
                    if (method.GetParameters().Length <= 0)
                    {
                        // Cancel Previous
                        StopInvoke(owner, name);
                        
                        // Create Invoke
                        var action = (Action)Delegate.CreateDelegate(typeof(Action), owner, method);

                        if (!AllInvokes.TryGetValue(owner, out var list))
                        {
                            list = new List<Invoke>();
                            AllInvokes[owner] = list;
                        }

                        var invoke = new Invoke(owner, action, name, Time.Timer + delay, 0, false);
                        list.Add(invoke);
                    }
                }
            }
        }

        internal static void StopInvoke(Object owner, string name)
        {
            if (owner != null)
            {
                // Find Owners Invokes
                if (AllInvokes.TryGetValue(owner, out var invokes))
                {
                    // For Each Invoke
                    foreach (var invoke in invokes)
                    {
                        if (invoke.Name == name)
                        {
                            invoke.Stop();
                        }
                    }
                }
            }
        }
        
        internal static void StopAllInvokes(Object owner)
        {
            if (owner != null)
            {
                // Find Owners Invokes
                if (AllInvokes.TryGetValue(owner, out var invokes))
                {
                    // For Each Invoke
                    foreach (var invoke in invokes)
                    {
                        invoke.Stop();
                    }
                }
            }
        }
    }
}