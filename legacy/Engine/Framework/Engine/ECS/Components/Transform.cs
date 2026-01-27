using System.Collections.Generic;
using System.Collections;
using System;

namespace Hybrid
{
    // Transform
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Transform))]
    public sealed partial class Transform : Component
    {
        internal Transform() { }
        
        internal List<Transform> Children { get; private set; } = new List<Transform>();
        internal Transform Parent { get; private set; }
        
        public Vector2 Position;
        public float Rotation;
        public Vector2 Scale;


        internal override void OnComponentDestroy()
        {
            SetParent(null);
        }
    }

    // Transform
    public partial class Transform
    {
        public Transform Find(string name)
        {
            foreach (Transform child in Transform.GetChildrenRecursive(true))
            {
                if (child.Name == name)
                {
                    return child;
                }
            }

            return null;
        }
    }

    // Parent
    public partial class Transform
    {
        public void SetParent(Transform parent)
        {
            // Clear Existing Parent
            if (Transform.Parent != null)
            {
                Transform.Parent.RemoveChild(Transform);
            }

            // Assign Parent
            if (parent != null)
            {
                // Clear Parent From This
                if (parent.IsChildOf(Transform))
                {
                    parent.SetParent(null);
                }
                
                // Set Parent
                parent.AddChild(Transform);

                // Set Scene To Parent Scene
                foreach (var child in parent.GetChildrenRecursive(true))
                {
                    child.GameObject.Scene = parent.GameObject.Scene;
                }
            }
        }

        public Transform GetParent()
        {
            return Transform.Parent;
        }
        
        public Transform GetRootParent()
        {
            Transform current = Transform;

            while (current.Parent != null)
            {
                current = current.Parent;
            }

            return current;
        }
    }

    // Child
    public partial class Transform
    {
        internal Transform[] GetChildrenRecursive(bool includeSelf = false)
        {
            var result = new List<Transform>();

            if (includeSelf)
            {
                result.Add(Transform);
            }

            void Collect(Transform current)
            {
                foreach (var child in current.Transform.Children)
                {
                    result.Add(child);
                    Collect(child);
                }
            }

            if (Transform.Children.Count > 0)
            {
                Collect(Transform);
            }
            
            return result.ToArray();
        }
        
        public Transform[] GetChildren()
        {
            return Transform.Children.ToArray();
        }

        public int ChildCount()
        {
            return Transform.Children.Count;
        }
        
        public Transform GetChild(int index)
        {
            if (ChildCount() > 0)
            {
                if (index >= 0 && index < ChildCount())
                {
                    return Transform.Children[index];
                }
            }

            return null;
        }
        
        public bool IsChildOf(Transform parent)
        {
            Transform current = Transform.Parent;

            while (current != null)
            {
                if (current == parent)
                {
                    return true;
                }

                current = current.Transform.Parent;
            }

            return false;
        }

        public int GetSiblingIndex()
        {
            // Invalid Parent
            if (Transform.Parent == null)
                return -1;
            
            // Get Position
            return Transform.Parent.Children.IndexOf(this);
        }

        public void SetSiblingIndex(int index)
        {
            // Invalid Parent
            if(Transform.Parent == null)
                return;
            
            // Invalid Parent
            if(Transform.Parent.ChildCount() <= 0)
                return;
            
            // Set Position
            index = Math.Clamp(index, 0, Transform.Parent.ChildCount() - 1);
            Transform.Parent.Children.RemoveAt(GetSiblingIndex());
            Transform.Parent.Children.Insert(index, this);
        }

        public void SetAsFirstSibling()
        {
            // Invalid Parent
            if(Transform.Parent == null)
                return;
            
            // Set First
            SetSiblingIndex(0);
        }

        public void SetAsLastSibling()
        {
            // Invalid Parent
            if(Transform.Parent == null)
                return;
            
            // Set Last
            SetSiblingIndex(Transform.Parent.ChildCount() - 1);
        }

        public void DetachChildren()
        {
            // For Each Immediate Child
            foreach (var child in Transform.GetChildren())
            {
                // Remove
                RemoveChild(child);
            }
        }
        
        private void AddChild(Transform child)
        {
            // Invalid Child
            if(child == null || child == this)
                return;

            // Attach
            child.Parent = this;
            Transform.Children.Add(child);
            Scenes.RemoveObject(child.GameObject);
            // Debug.Log($"Child '{child.Name}' added to parent '{Name}' ");
        }

        private void RemoveChild(Transform child)
        {
            // Invalid Child
            if(child == null || child == this)
                return;

            // Detach
            child.Parent = null;
            Transform.Children.Remove(child);
            Scenes.AddObject(child.GameObject, child.GameObject.Scene);
            // Debug.Log($"Child '{child.Name}' removed from parent '{Name}' ");
        }
    }
}