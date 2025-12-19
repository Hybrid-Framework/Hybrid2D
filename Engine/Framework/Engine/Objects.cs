using System;

namespace Hybrid
{
    // Objects
    internal sealed class Objects : Module<Objects>
    {
        private static readonly HashSet<Object> ObjectsMarkedForDestroying = new HashSet<Object>();
        
        
        internal override void OnEndOfFrame()
        {
            // For Each Object Marked For Destroying
            foreach (var obj in ObjectsMarkedForDestroying.ToArray())
            {
                // Destroy
                Object.DestroyImmediate(obj);
                
                // Remove Entry
                UnMarkObjectForDestroying(obj);
            }
        }

        internal static void MarkObjectForDestroying(Object obj)
        {
            if (!IsMarkedForDestroying(obj))
            {
                ObjectsMarkedForDestroying.Add(obj);
            }
        }

        internal static void UnMarkObjectForDestroying(Object obj)
        {
            if (IsMarkedForDestroying(obj))
            {
                ObjectsMarkedForDestroying.Remove(obj);
            }
        }

        internal static bool IsMarkedForDestroying(Object obj)
        {
            if (ObjectsMarkedForDestroying.Contains(obj))
            {
                return true;
            }

            return false;
        }
    }
}