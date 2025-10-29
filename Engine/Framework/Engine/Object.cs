using System;

namespace Hybrid
{
    // Object
    public partial class Object : IEquatable<Object>
    {
        public Object(string name = null)
        {
            Scene = SceneManager.ActiveScene;
            Name = name ?? "Object";
            Guid = Guid.NewGuid();
        }
        
        public void Destroy()
        {
            Validate(this);
            
            IsDestroyed = true;
        }
        
        public int GetInstanceID()
        {
            Validate(this);

            return Guid.GetHashCode();
        }
        
        public static void Destroy(Object obj)
        {
            Validate(obj);
            
            obj.Destroy();
        }
        
        public static Object Instantiate(Object obj)
        {
            Validate(obj);

            return new Object()
            {
                Name = obj.Name,
                Scene = obj.Scene
            };
        }
        
        // Before we access any properties
        // Call Validate which check if destroyed or not
        // If destroyed then throw null reference exception
        private static void Validate(Object obj)
        {
            if (obj.IsDestroyed)
            {
                throw new NullReferenceException();
            }
        }
    }
    
    // Properties
    public partial class Object
    {
        public bool IsDestroyed
        {
            private set;
            get; 
        }
        
        private Guid _guid;
        private Guid Guid
        {
            get
            {
                Validate(this);
                
                return _guid;
            }
            set
            {
                Validate(this);
                
                _guid = value;
            }
        }
        
        private string _name;
        public string Name
        {
            get
            {
                Validate(this);

                return _name;
            }
            set
            {
                Validate(this);

                _name = value;
            }
        }

        private Scene _scene;
        public Scene Scene
        {
            get
            {
                Validate(this);

                return _scene;
            }
            private set
            {
                Validate(this);

                _scene = value;
            }
        }
    }

    // Operators
    public partial class Object
    {
        public static implicit operator bool(Object obj)
        {
            return obj is not null && !obj.IsDestroyed;
        }
        
        public static bool operator != (Object a, Object b)
        {
            return !(a == b);
        }
        
        public static bool operator == (Object a, Object b)
        {
            if (ReferenceEquals(a, b)) return true;

            if (a is null) return b?.IsDestroyed ?? true;
            if (b is null) return a?.IsDestroyed ?? true;
            
            return a.IsDestroyed && b.IsDestroyed;
        }
        
        public bool Equals(Object obj)
        {
            if (ReferenceEquals(this, obj)) return true;

            if (obj is null) return IsDestroyed;

            return IsDestroyed && obj.IsDestroyed;
        }
        
        public override bool Equals(object obj)
        {
            if (obj is not Object other)
            {
                return false;
            }
            
            return Equals(other);
        }

        public override int GetHashCode()
        {
            Validate(this);

            return GetInstanceID();
        }

        public override string ToString()
        {
            Validate(this);

            return Name;
        }
    }
}