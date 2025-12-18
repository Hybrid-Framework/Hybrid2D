using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections;
using System;

namespace Hybrid
{
    // Internal
    internal sealed partial class Coroutines : Module<Coroutines>
    {
        private static readonly Dictionary<Object, List<Coroutine>> AllCoroutines = new();
        
        
        // Update
        internal override void OnUpdate()
        {
            // For Each Owner
            foreach (var owner in AllCoroutines.Keys.ToArray())
            {
                // For Each Coroutine List In Owner
                if (AllCoroutines.TryGetValue(owner, out var list))
                {
                    // Process Coroutines
                    for (int i = list.Count - 1; i >= 0; i--)
                    {
                        var coroutine = list[i];

                        if (coroutine.Done)
                        {
                            list.RemoveAt(i);
                            continue;
                        }

                        if (coroutine.Instruction is WaitForFixedUpdate) continue;
                        if (coroutine.Instruction is WaitForEndOfFrame) continue;

                        coroutine.MoveNext();
                    }
                    
                    // Remove Owner
                    if (list.Count == 0)
                    {
                        AllCoroutines.Remove(owner);
                    }
                }
            }
        }

        // Fixed Update
        internal override void OnFixedUpdate()
        {
            // For Each Owner
            foreach (var owner in AllCoroutines.Keys.ToArray())
            {
                // For Each Coroutine List In Owner
                if (AllCoroutines.TryGetValue(owner, out var list))
                {
                    // Process Coroutines
                    for (int i = list.Count - 1; i >= 0; i--)
                    {
                        var coroutine = list[i];

                        if (coroutine.Done)
                        {
                            list.RemoveAt(i);
                            continue;
                        }

                        if (coroutine.Instruction is WaitForFixedUpdate)
                        {
                            coroutine.MoveNext();
                        }
                    }
                    
                    // Remove Owner
                    if (list.Count == 0)
                    {
                        AllCoroutines.Remove(owner);
                    }
                }
            }
        }

        // End Of Frame
        internal override void OnEndOfFrame()
        {
            // For Each Owner
            foreach (var owner in AllCoroutines.Keys.ToArray())
            {
                // For Each Coroutine List In Owner
                if (AllCoroutines.TryGetValue(owner, out var list))
                {
                    // Process Coroutines
                    for (int i = list.Count - 1; i >= 0; i--)
                    {
                        var coroutine = list[i];

                        if (coroutine.Done)
                        {
                            list.RemoveAt(i);
                            continue;
                        }

                        if (coroutine.Instruction is WaitForEndOfFrame)
                        {
                            coroutine.MoveNext();
                        }
                    }
                    
                    // Remove Owner
                    if (list.Count == 0)
                    {
                        AllCoroutines.Remove(owner);
                    }
                }
            }
        }

        // Dispose
        internal override void OnDispose()
        {
            // For Each Owner
            foreach (var coroutines in AllCoroutines.Values.ToArray())
            {
                foreach (var coroutine in coroutines)
                {
                    coroutine.Stop();
                }
            }
            
            // Clear
            AllCoroutines.Clear();
        }
    }
    
    // Coroutines
    internal partial class Coroutines
    {
        internal static Coroutine StartCoroutine(Object owner, IEnumerator enumerator)
        {
            if (owner != null && enumerator != null)
            {
                // Create Map Entry for owner
                if (!AllCoroutines.TryGetValue(owner, out var list))
                {
                    list = new List<Coroutine>();
                    AllCoroutines[owner] = list;
                }

                // Create Coroutine
                var coroutine = new Coroutine(owner, GetName(enumerator), enumerator);
                list.Add(coroutine);
                return coroutine;
            }

            return null;
        }
        
        internal static void StopCoroutine(Object owner, Coroutine coroutine)
        {
            if (owner != null && coroutine != null)
            {
                // Find Owners Coroutines
                if (AllCoroutines.TryGetValue(owner, out var coroutines))
                {
                    // For Each Coroutine
                    foreach(var c in coroutines)
                    {
                        if (c == coroutine)
                        {
                            c.Stop();
                        }
                    }
                }
            }
        }
        
        internal static void StopAllCoroutines(Object owner)
        {
            if (owner != null)
            {
                // Find Owners Coroutines
                if (AllCoroutines.TryGetValue(owner, out var coroutines))
                {
                    // For Each Coroutine
                    foreach(var c in coroutines)
                    {
                        c.Stop();
                    }
                }
            }
        }
        
        private static string GetName(IEnumerator enumerator)
        {
            var name = enumerator.GetType().Name;
            var match = Regex.Match(name, "<([^<>]+)>");

            if (match.Success)
            {
                return match.Groups[1].Value;
            }

            return name;
        }
    }
}