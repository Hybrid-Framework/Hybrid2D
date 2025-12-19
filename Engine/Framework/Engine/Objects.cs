using System;

namespace Hybrid
{
    // Objects
    internal sealed class Objects : Module<Objects>
    {
        private static readonly List<Object> ObjectsMarkedForDestroying = new List<Object>();
        
        
        internal override void OnEndOfFrame()
        {
            foreach (var obj in ObjectsMarkedForDestroying.ToArray())
            {
                UnMarkObjectForDestroying(obj);
                Object.DestroyImmediate(obj);
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