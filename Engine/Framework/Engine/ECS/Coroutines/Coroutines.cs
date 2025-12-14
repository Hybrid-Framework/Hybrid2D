using System.Collections.Generic;
using System.Collections;
using System;

namespace Hybrid
{
    // Internal
    internal sealed partial class Coroutines : Module<Coroutines>
    {
        private static readonly Dictionary<object, List<Coroutine>> AllCoroutines = new();
        
        
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

            base.OnUpdate();
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

            base.OnFixedUpdate();
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

            base.OnEndOfFrame();
        }

        // Dispose
        internal override void OnDispose()
        {
            // For Each Owner
            foreach (var owner in AllCoroutines.Keys.ToArray())
            {
                StopAllCoroutines(owner);
            }
            
            // Clear
            AllCoroutines.Clear();
            base.OnDispose();
        }
    }
    
    // Coroutines
    internal partial class Coroutines
    {
        internal static Coroutine StartCoroutine(object owner, IEnumerator enumerator)
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
        
        internal static void StopCoroutine(object owner, Coroutine coroutine)
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
        
        internal static void StopAllCoroutines(object owner)
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
            int start = name.IndexOf('<');
            int end = name.IndexOf('>');

            if (start >= 0 && end > start)
            {
                return name.Substring(start + 1, end - start - 1);
            }

            return name;
        }
    }
}