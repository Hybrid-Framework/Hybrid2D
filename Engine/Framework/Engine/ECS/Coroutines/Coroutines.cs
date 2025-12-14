using System.Collections.Generic;
using System.Collections;
using System;

namespace Hybrid
{
    // Internal
    internal sealed partial class Coroutines : Module<Coroutines>
    {
        private static readonly Dictionary<object, List<Coroutine>> Map = new();
        
        // Update
        internal override void OnUpdate()
        {
            foreach (var list in Map.Values)
            {
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
            }
            
            base.OnUpdate();
        }

        // Fixed Update
        internal override void OnFixedUpdate()
        {
            foreach (var list in Map.Values)
            {
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
            }
            
            base.OnFixedUpdate();
        }

        // End Of Frame
        internal override void OnEndOfFrame()
        {
            foreach (var list in Map.Values)
            {
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
            }
            
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
        internal static Coroutine StartCoroutine(object owner, IEnumerator enumerator)
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
                if (Map.TryGetValue(owner, out var coroutines))
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
                if (Map.TryGetValue(owner, out var coroutines))
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