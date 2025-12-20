using System;

namespace Hybrid
{
    // Objects
    internal sealed partial class Objects : Module<Objects>
    {
        // End Of Frame
        internal override void OnEndOfFrame()
        {
            DestroyObjectsRecursive();
        }

        // Dispose
        internal override void OnDispose()
        {
            DestroyObjectsRecursive();
        }
    }
    
    internal partial class Objects
    {
        private static readonly HashSet<Object> ObjectsMarkedForDestroying = new HashSet<Object>();


        internal static void DestroyObjectsRecursive()
        {
            // While There Is Objects To Be Destroyed
            while (ObjectsMarkedForDestroying.Count > 0)
            {
                // Destroy Objects
                DestroyObjects();
            }
        }

        internal static void DestroyObjects()
        {
            // For Each Object Marked For Destroying
            foreach (var obj in ObjectsMarkedForDestroying.ToArray())
            {
                // If Not Destroyed
                if (!Object.IsDestroyed(obj))
                {
                    // Destroy Immediately
                    Object.DestroyImmediate(obj);
                }
                
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