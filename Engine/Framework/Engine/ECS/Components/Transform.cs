using System;

namespace Hybrid
{
    [DisallowDestroyComponent]
    [DisallowMultipleComponent]
    public sealed partial class Transform : Component
    {
        private List<Transform> Children { get; set; } = new List<Transform>();
        private Transform Parent { get; set; }
        
        public Transform()
        {
            Transform = this;
        }
    }
    
    // Parent
    public sealed partial class Transform
    {
        public Transform GetParent()
        {
            return Parent;
        }

        public void SetParent(Transform parent)
        {
            // Clear Existing Parent
            if (Parent != null) Parent.RemoveChild(this);

            // Set Parent
            if (parent != null)
            {
                // Remove Parent
                if (parent.IsChildOf(this))
                {
                    parent.SetParent(null);
                }
                
                // Set Parent
                parent.AddChild(this);
            }
        }
    }
    
    // Children
    public sealed partial class Transform
    {
        internal void AddChild(Transform child)
        {
            // Invalid Child
            if(child == null || child == this) return;

            var parent = this;
            Children.Add(child);
            child.Parent = parent;
            
            Scenes.GetActiveScene().RemoveObject(child.GameObject);
            Console.WriteLine($"Child '{child.Name}' added to parent '{parent.Name}'");
        }

        internal void RemoveChild(Transform child)
        {
            // Invalid Child
            if(child == null || child.Parent == null || child == this) return;

            var parent = child.Parent;
            Children.Remove(child);
            child.Parent = null;
            
            Scenes.GetActiveScene().AddObject(child.GameObject);
            Console.WriteLine($"Child '{child.Name}' removed from parent '{parent.Name}'");
        }
        
        public Transform[] GetChildrenRecursive()
        {
            List<Transform> result = new List<Transform>();
            Stack<Transform> stack = new Stack<Transform>();

            foreach (var child in Children)
            {
                stack.Push(child);
            }

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                result.Add(current);

                for (int i = current.ChildCount() - 1; i >= 0; i--)
                {
                    stack.Push(current.Children[i]);
                }
            }

            return result.ToArray();
        }
        
        public Transform[] GetChildren()
        {
            return Children.ToArray();
        }

        public Transform GetChild(int index)
        {
            if (index >= 0 && index < ChildCount())
            {
                return Children[index];
            }

            return null;
        }
        
        public bool IsChildOf(Transform parent)
        {
            // Invalid Parent
            if (parent == null) return false;
            
            foreach (var child in parent.GetChildrenRecursive())
            {
                if (child == this)
                {
                    return true;
                }
            }

            return false;
        }

        public int GetSiblingIndex()
        {
            // Invalid parent
            if (Parent == null) return 0;
            
            return Parent.Children.IndexOf(this);
        }

        public void SetSiblingIndex(int index)
        {
            // Invalid Parent
            if(Parent == null) return;

            var previous = GetSiblingIndex();
            index = Math.Clamp(index, 0, Parent.ChildCount() - 1);
            
            Parent.Children.RemoveAt(previous);
            Parent.Children.Insert(index, this);
        }

        public void SetAsFirstSibling()
        {
            // Invalid Parent
            if(Parent == null) return;
            
            SetSiblingIndex(0);
        }
        
        public void SetAsLastSibling()
        {
            // Invalid Parent
            if(Parent == null) return;
            
            SetSiblingIndex(Parent.ChildCount() - 1);
        }

        public int ChildCount()
        {
            return Children.Count;
        }
    }
}