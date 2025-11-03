using System;

namespace Hybrid
{
    // Object
    public partial class Object : IEquatable<Object>
    {
        public Scene Scene { get; private set; }
        public string Name { get; set; }
        private bool IsDestroyed;
        private Guid Guid;
        

        public Object(string name = null)
        {
            if (SceneManager.ActiveScene == null)
            {
                throw new Exception("Can't create object with no scene loaded");
            }
            
            Scene = SceneManager.ActiveScene;
            Name = name ?? "Object";
            Guid = Guid.NewGuid();
            Scene.Add(this);
        }

        public void Destroy()
        {
            if (!IsDestroyed)
            {
                IsDestroyed = true;
                Scene.Remove(this);
                Guid = Guid.Empty;
                Name = "null";
            }
        }

        public int GetInstanceID()
        {
            return Guid.GetHashCode();
        }

        internal virtual void Process()
        {
            Console.WriteLine("Processing: " + Name);
        }
    }
    
    // Operators
    public partial class Object
    {
        public static implicit operator bool(Object obj)
        {
            return obj != null;
        }
        
        public static bool operator !=(Object a, Object b)
        {
            return !(a == b);
        }

        public static bool operator ==(Object a, Object b)
        {
            if (a is null) return b?.IsDestroyed ?? false;
            if (b is null) return a?.IsDestroyed ?? false;
            
            return ReferenceEquals(a, b);
        }

        public bool Equals(Object other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            if (obj is not Object) return false;
            
            return Equals(obj);
        }

        public override int GetHashCode()
        {
            return GetInstanceID();
        }

        public override string ToString()
        {
            return IsDestroyed ? "null" : Name;
        }
    }
}