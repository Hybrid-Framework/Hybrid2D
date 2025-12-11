using System;

namespace Hybrid
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Transform))]
    public sealed partial class Transform : Component
    {
        internal List<Transform> Children { get; private set; } = new List<Transform>();
        internal Transform Parent { get; private set; }
        
        public Vector2 Position;
        public float Rotation;
        public Vector2 Scale;
    }

    // Parent
    public sealed partial class Transform
    {
        public void SetParent(Transform parent)
        {
            // Clear Existing Parent
            if (Parent != null) Parent.RemoveChild(this);

            // Assign Parent
            if (parent != null)
            {
                // Clear Parent From This
                if (parent.IsChildOf(this))
                {
                    parent.SetParent(null);
                }
                
                // Set Parent
                parent.AddChild(this);
            }
        }

        public Transform GetParent()
        {
            return Parent;
        }
    }

    // Child
    public sealed partial class Transform
    {
        public Transform[] GetChildrenRecursive(bool includeParent = false)
        {
            List<Transform> result = new List<Transform>();

            if (includeParent)
            {
                result.Add(this);
            }

            void Collect(Transform current)
            {
                foreach (var child in current.Children)
                {
                    result.Add(child);
                    Collect(child);
                }
            }

            Collect(this);
            return result.ToArray();
        }
        
        public Transform[] GetChildren()
        {
            return Children.ToArray();
        }

        public int ChildCount()
        {
            return Children.Count;
        }
        
        public Transform GetChild(int index)
        {
            if (ChildCount() > 0)
            {
                if (index >= 0 && index < ChildCount())
                {
                    return Children[index];
                }
            }

            return null;
        }
        
        public bool IsChildOf(Transform parent)
        {
            Transform current = Parent;

            while (current != null)
            {
                if (current == parent)
                {
                    return true;
                }

                current = current.Parent;
            }

            return false;
        }

        public int GetSiblingIndex()
        {
            // Invalid Parent
            if (Parent == null)
                return -1;
            
            // Get Position
            return Parent.Children.IndexOf(this);
        }

        public void SetSiblingIndex(int index)
        {
            // Invalid Parent
            if(Parent == null)
                return;
            
            // Invalid Parent
            if(Parent.ChildCount() <= 0)
                return;
            
            // Set Position
            index = Math.Clamp(index, 0, Parent.ChildCount() - 1);
            Parent.Children.RemoveAt(GetSiblingIndex());
            Parent.Children.Insert(index, this);
        }

        public void SetAsFirstSibling()
        {
            // Invalid Parent
            if(Parent == null)
                return;
            
            // Set First
            SetSiblingIndex(0);
        }

        public void SetAsLastSibling()
        {
            // Invalid Parent
            if(Parent == null)
                return;
            
            // Set Last
            SetSiblingIndex(Parent.ChildCount() - 1);
        }
        
        private void AddChild(Transform child)
        {
            // Invalid Child
            if(child == null || child == this)
                return;

            // Attach
            Children.Add(child);
            child.Parent = this;
            Scenes.GetActiveScene().RemoveObject(child.GameObject);
            Debug.Log($"Child '{child.Name}' added to parent '{Name}'");
        }

        private void RemoveChild(Transform child)
        {
            // Invalid Child
            if(child == null || child == this)
                return;

            // Detach
            child.Parent = null;
            Children.Remove(child);
            Scenes.GetActiveScene().AddObject(child.GameObject);
            Debug.Log($"Child '{child.Name}' removed from parent '{Name}'");
        }
    }
}