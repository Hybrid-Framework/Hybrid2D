using System.Collections.Generic;
using System.Reflection;
using System;

namespace Hybrid
{
    // Internal
    internal sealed partial class Invoking : Module<Invoking>
    {
        private static readonly Dictionary<object, List<Invoke>> AllInvokes = new();
        
        
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
            
            base.OnUpdate();
        }

        // Dispose
        internal override void OnDispose()
        {
            // For Each Owner
            foreach (var owner in AllInvokes.Keys.ToArray())
            {
                StopAllInvokes(owner);
            }
            
            // Clear
            AllInvokes.Clear();
            base.OnDispose();
        }
    }

    // Invoking
    internal partial class Invoking
    {
        internal static void StartInvoke(object owner, string name, float delay, float repeat = 0)
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

                        var invoke = new Invoke(owner, action, name, Time.Timer + delay, repeat);
                        list.Add(invoke);
                    }
                }
            }
        }

        internal static void StopInvoke(object owner, string name)
        {
            if (owner != null)
            {
                // Find Owners Invokes
                if (AllInvokes.TryGetValue(owner, out var invokes))
                {
                    // For Each Invoke
                    foreach (var invoke in invokes)
                    {
                        // If Match Name Or Name Is Null
                        if (invoke.Name == name)
                        {
                            invoke.Stop();
                        }
                    }
                }
            }
        }
        
        internal static void StopAllInvokes(object owner)
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