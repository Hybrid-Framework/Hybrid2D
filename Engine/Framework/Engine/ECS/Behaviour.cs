using System.Reflection;
using System;

namespace Hybrid
{
    // Behaviour
    public abstract partial class Behaviour : Object
    {
        private GameObject _GameObject { get; set; }
        public GameObject GameObject
        {
            internal set => _GameObject = value;
            get
            {
                if (IsDestroyed(_GameObject))
                {
                    Debug.LogError($"Trying to access ({typeof(GameObject)}) but it has been destroyed");
                }
                
                return _GameObject;
            }
        }

        private Transform _Transform { get; set; }
        public Transform Transform
        {
            internal set => _Transform = value;
            get
            {
                if (IsDestroyed(_Transform))
                {
                    Debug.LogError($"Trying to access ({typeof(Transform)}) but it has been destroyed");
                }
                
                return _Transform;
            }
        }
        
        private string _Name { get; set; }
        public string Name
        {
            get
            {
                if (IsDestroyed(this))
                {
                    return _Name + " (Destroyed)";
                }
                
                return _Name;
            }
            set
            {
                if (GameObject != null)
                {
                    GameObject._Name = value;

                    foreach (var component in GameObject.Components)
                    {
                        component._Name = value;
                    }
                }
                
                _Name = value;
            }
        }

        internal Behaviour()
        {
            Name = GetType().Name;
        }
    }
    
    // Broadcast Message
    public partial class Behaviour
    {
        public void BroadcastMessage(string name, object value, SendMessageOptions options)
        {
            BroadcastMessageInternal(name, value, options);
        }
        
        public void BroadcastMessage(string name, SendMessageOptions options)
        {
            BroadcastMessageInternal(name, null, options);
        }

        internal void BroadcastMessageInternal(string name, object value, SendMessageOptions options)
        {
            bool invoked = false;

            if (!Object.IsDestroyed(GameObject))
            {
                foreach (var component in GameObject.GetComponentsInChildren(true))
                {
                    var method = component.GetType().GetMethod(name, 
                        BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                    if (method != null)
                    {
                        var parameters = method.GetParameters().Length > 0 ? new[] { value } : null;
                        method.Invoke(component, parameters);
                        invoked = true;
                    }
                }
            }

            if (options == SendMessageOptions.RequireReceiver)
            {
                if (!invoked)
                {
                    Debug.LogError($"Broadcast Message: No receiver found for method '{name}'");
                }
            }
        }
    }
    
    // Send Message
    public partial class Behaviour
    {
        public void SendMessage(string name, object value, SendMessageOptions options)
        {
            SendMessageInternal(name, value, options);
        }

        public void SendMessage(string name, SendMessageOptions options)
        {
            SendMessageInternal(name, null, options);
        }

        internal void SendMessageInternal(string name, object value, SendMessageOptions options)
        {
            bool invoked = false;

            if (!Object.IsDestroyed(GameObject))
            {
                foreach (var component in GameObject.Components)
                {
                    var method = component.GetType().GetMethod(name,
                        BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                    if (method != null)
                    {
                        var parameters = method.GetParameters().Length > 0 ? new[] { value } : null;
                        method.Invoke(component, parameters);
                        invoked = true;
                    }
                }
            }

            if (options == SendMessageOptions.RequireReceiver)
            {
                if (!invoked)
                {
                    Debug.LogError($"Send Message: No receiver found for method '{name}'");
                }
            }
        }
    }
    
    // Send Message Upwards
    public partial class Behaviour
    {
        public void SendMessageUpwards(string name, object value, SendMessageOptions options)
        {
            SendMessageUpwardsInternal(name, value, options);
        }

        public void SendMessageUpwards(string name, SendMessageOptions options)
        {
            SendMessageUpwardsInternal(name, null, options);
        }

        internal void SendMessageUpwardsInternal(string name, object value, SendMessageOptions options)
        {
            bool invoked = false;

            if (!Object.IsDestroyed(GameObject))
            {
                foreach (var component in GameObject.GetComponentsInParent(true))
                {
                    var method = component.GetType().GetMethod(name,
                        BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                    if (method != null)
                    {
                        var parameters = method.GetParameters().Length > 0 ? new[] { value } : null;
                        method.Invoke(component, parameters);
                        invoked = true;
                    }
                }
            }

            if (options == SendMessageOptions.RequireReceiver)
            {
                if (!invoked)
                {
                    Debug.LogError($"Send Message Upwards: No receiver found for method '{name}'");
                }
            }
        }
    }
    
    // Find By Types
    public partial class Behaviour
    {
        public static GameObject[] FindGameObjectsByName(string name, bool activeOnly = false)
        {
            var results = new List<GameObject>();

            if (Scenes.GetActiveScene() != null)
            {
                // For Each Root GameObject In Scene
                foreach (var gameObject in Scenes.GetActiveScene().RootGameObjects)
                {
                    // If Active Only And Disabled
                    if(gameObject == null) continue;
                    if(activeOnly && !gameObject.Active) continue;
                
                    // For Each Child Of GameObject (Including Parent)
                    foreach (var child in gameObject.Transform.GetChildrenRecursive(true))
                    {
                        // If Active Only And Disabled
                        if(child == null) continue;
                        if(activeOnly && !child.Enabled) continue;
                    
                        if (child.GameObject.Name == name)
                        {
                            results.Add(child.GameObject);
                        }
                    }
                }
            }

            return results.ToArray();
        }
        
        public static GameObject FindGameObjectByName(string name, bool activeOnly = false)
        {
            if (Scenes.GetActiveScene() != null)
            {
                // For Each Root GameObject In Scene
                foreach (var gameObject in Scenes.GetActiveScene().RootGameObjects)
                {
                    // If Active Only And Disabled
                    if (gameObject == null) continue;
                    if (activeOnly && !gameObject.Active) continue;

                    // For Each Child Of GameObject (Including Parent)
                    foreach (var child in gameObject.Transform.GetChildrenRecursive(true))
                    {
                        // If Active Only And Disabled
                        if (child == null) continue;
                        if (activeOnly && !child.Enabled) continue;

                        if (child.GameObject.Name == name)
                        {
                            return child.GameObject;
                        }
                    }
                }
            }

            return null;
        }

        public static GameObject[] FindGameObjectsByLayer(string layer, bool activeOnly = false)
        {
            var results = new List<GameObject>();

            if (Scenes.GetActiveScene() != null)
            {
                // For Each Root GameObject In Scene
                foreach (var gameObject in Scenes.GetActiveScene().RootGameObjects)
                {
                    // If Active Only And Disabled
                    if (gameObject == null) continue;
                    if (activeOnly && !gameObject.Active) continue;

                    // For Each Child Of GameObject (Including Parent)
                    foreach (var child in gameObject.Transform.GetChildrenRecursive(true))
                    {
                        // If Active Only And Disabled
                        if (child == null) continue;
                        if (activeOnly && !child.Enabled) continue;

                        if (child.GameObject.Layer == layer)
                        {
                            results.Add(child.GameObject);
                        }
                    }
                }
            }

            return results.ToArray();
        }
        
        public static GameObject FindGameObjectByLayer(string layer, bool activeOnly = false)
        {
            if (Scenes.GetActiveScene() != null)
            {
                // For Each Root GameObject In Scene
                foreach (var gameObject in Scenes.GetActiveScene().RootGameObjects)
                {
                    // If Active Only And Disabled
                    if (gameObject == null) continue;
                    if (activeOnly && !gameObject.Active) continue;

                    // For Each Child Of GameObject (Including Parent)
                    foreach (var child in gameObject.Transform.GetChildrenRecursive(true))
                    {
                        // If Active Only And Disabled
                        if (child == null) continue;
                        if (activeOnly && !child.Enabled) continue;

                        if (child.GameObject.Layer == layer)
                        {
                            return child.GameObject;
                        }
                    }
                }
            }

            return null;
        }
        
        public static GameObject[] FindGameObjectsByTag(string tag, bool activeOnly = false)
        {
            var results = new List<GameObject>();

            if (Scenes.GetActiveScene() != null)
            {
                // For Each Root GameObject In Scene
                foreach (var gameObject in Scenes.GetActiveScene().RootGameObjects)
                {
                    // If Active Only And Disabled
                    if (gameObject == null) continue;
                    if (activeOnly && !gameObject.Active) continue;

                    // For Each Child Of GameObject (Including Parent)
                    foreach (var child in gameObject.Transform.GetChildrenRecursive(true))
                    {
                        // If Active Only And Disabled
                        if (child == null) continue;
                        if (activeOnly && !child.Enabled) continue;

                        if (child.GameObject.Tag == tag)
                        {
                            results.Add(child.GameObject);
                        }
                    }
                }
            }

            return results.ToArray();
        }
        
        public static GameObject FindGameObjectByTag(string tag, bool activeOnly = false)
        {
            if (Scenes.GetActiveScene() != null)
            {
                // For Each Root GameObject In Scene
                foreach (var gameObject in Scenes.GetActiveScene().RootGameObjects)
                {
                    // If Active Only And Disabled
                    if (gameObject == null) continue;
                    if (activeOnly && !gameObject.Active) continue;

                    // For Each Child Of GameObject (Including Parent)
                    foreach (var child in gameObject.Transform.GetChildrenRecursive(true))
                    {
                        // If Active Only And Disabled
                        if (child == null) continue;
                        if (activeOnly && !child.Enabled) continue;

                        if (child.GameObject.Tag == tag)
                        {
                            return child.GameObject;
                        }
                    }
                }
            }

            return null;
        }

        public static T[] FindObjectsByType<T>(bool activeOnly = false) where T : Object
        {
            var results = new List<T>();

            if (Scenes.GetActiveScene() != null)
            {
                // For Each Root GameObject In Scene
                foreach (var gameObject in Scenes.GetActiveScene().RootGameObjects)
                {
                    // If Active Only And Disabled
                    if (gameObject == null) continue;
                    if (activeOnly && !gameObject.Active) continue;

                    if (typeof(T).IsAssignableFrom(gameObject.GetType()))
                    {
                        results.Add(gameObject as T);
                    }

                    // For Each Child Components Of GameObject (Including Parent)
                    foreach (var component in gameObject.GetComponentsInChildren<Component>(true))
                    {
                        // If Active Only And Disabled
                        if (component == null) continue;
                        if (activeOnly && !component.Enabled) continue;

                        if (typeof(T).IsAssignableFrom(component.GetType()))
                        {
                            results.Add(component as T);
                        }
                    }
                }
            }

            return results.ToArray();
        }
        
        public static T FindObjectByType<T>(bool activeOnly = false) where T : Object
        {
            if (Scenes.GetActiveScene() != null)
            {
                // For Each Root GameObject In Scene
                foreach (var gameObject in Scenes.GetActiveScene().RootGameObjects)
                {
                    // If Active Only And Disabled
                    if (gameObject == null) continue;
                    if (activeOnly && !gameObject.Active) continue;

                    if (typeof(T).IsAssignableFrom(gameObject.GetType()))
                    {
                        return gameObject as T;
                    }

                    // For Each Child Components Of GameObject (Including Parent)
                    foreach (var component in gameObject.GetComponentsInChildren<Component>(true))
                    {
                        // If Active Only And Disabled
                        if (component == null) continue;
                        if (activeOnly && !component.Enabled) continue;

                        if (typeof(T).IsAssignableFrom(component.GetType()))
                        {
                            return component as T;
                        }
                    }
                }
            }

            return null;
        }
    }
    
    // Add Component
    public partial class Behaviour
    {
        private readonly HashSet<Type> Processing = new();
        
        public Component AddComponent(Type type)
        {
            return AddComponentInternal
            (
                (Component)Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, null, null)
            );
        }
        
        public T AddComponent<T>() where T : Component
        {
            return AddComponentInternal
            (
                (T)Activator.CreateInstance(typeof(T), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, null, null)
            );
        }

        internal T AddComponentInternal<T>(T component) where T : Component
        {
            // Invalid Component
            if (component == null)
                return null;
            
            // Component Type
            var type = component.GetType();
            
            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");
            
            // Disallow Multiple Component
            if (Attribute.IsDefined(type, typeof(DisallowMultipleComponentAttribute)))
            {
                // Has Component
                if (HasComponent(type))
                {
                    throw new Exception($"Can't have multiple instances of '{type.Name}' on GameObject '{Name}'");
                }
            }
            
            // Require Component
            if (Attribute.IsDefined(type, typeof(RequireComponentAttribute)))
            {
                // Processing Component
                if (!Processing.Add(type))
                    return component;
                
                // For Each Required Component
                foreach (RequireComponentAttribute required in type.GetCustomAttributes(typeof(RequireComponentAttribute), true))
                {
                    // Find Component
                    if (!HasComponent(required.Type))
                    {
                        // Attach & Return
                        AddComponent(required.Type);
                    }
                }
                
                // Finished Processing
                Processing.Remove(type);
            }

            // Set Properties
            component.GameObject = this.GameObject;
            component.Transform = this.Transform;
            component.Name = this.Name;
            
            // Add To GameObject
            // Debug.Log($"Component '{component.GetType()}' added to GameObject '{Name}'");
            GameObject.Components.Add(component);
            return component;
        }
    }

    // Get Component
    public partial class Behaviour
    {
        public Component GetComponent(Type type)
        {
            return GetComponentInternal(type);
        }

        public T GetComponent<T>() where T : Component
        {
            return GetComponentInternal(typeof(T)) as T;
        }
        
        internal Component GetComponentInternal(Type type)
        {
            // Invalid Type
            if (type == null)
                return null;
            
            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");
            
            // For Each Component In GameObject
            foreach (var component in GameObject.Components)
            {
                if (type.IsAssignableFrom(component.GetType()))
                {
                    return component;
                }
            }

            return null;
        }
    }
    
    // Get Components
    public partial class Behaviour
    {
        public Component[] GetComponents()
        {
            return GetComponentsInternal(typeof(Component)).ToArray();
        }
        
        public Component[] GetComponents(Type type)
        {
            return GetComponentsInternal(type).ToArray();
        }

        public T[] GetComponents<T>() where T : Component
        {
            return GetComponentsInternal(typeof(T)).Cast<T>().ToArray();
        }
        
        internal Component[] GetComponentsInternal(Type type)
        {
            // Invalid Type
            if (type == null)
                return Array.Empty<Component>();
            
            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");

            // Create Results
            var results = new List<Component>();
            
            // For Each Component In GameObject
            foreach (var component in GameObject.Components)
            {
                if (type.IsAssignableFrom(component.GetType()))
                {
                    results.Add(component);
                }
            }

            return results.ToArray();
        }
    }
    
    // Get Component In Parent
    public partial class Behaviour
    {
        public Component GetComponentInParent(Type type, bool includeSelf = false)
        {
            return GetComponentInParentInternal(type, includeSelf);
        }

        public T GetComponentInParent<T>(bool includeSelf = false) where T : Component
        {
            return GetComponentInParentInternal(typeof(T), includeSelf) as T;
        }
        
        internal Component GetComponentInParentInternal(Type type, bool includeSelf = false)
        {
            // Invalid Type
            if (type == null)
                return null;
            
            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");
            
            // Find Component In Parent
            Transform current = includeSelf ? Transform : Transform.Parent;
            
            while (current != null)
            {
                foreach (var component in current.GameObject.Components)
                {
                    if (type.IsAssignableFrom(component.GetType()))
                    {
                        return component;
                    }
                }
                
                current = current.Parent;
            }

            return null;
        }
    }
    
    // Get Components In Parent
    public partial class Behaviour
    {
        public Component[] GetComponentsInParent(bool includeSelf = false)
        {
            return GetComponentsInParentInternal(typeof(Component), includeSelf).ToArray();
        }
        
        public Component[] GetComponentsInParent(Type type, bool includeSelf = false)
        {
            return GetComponentsInParentInternal(type, includeSelf).ToArray();
        }

        public T[] GetComponentsInParent<T>(bool includeSelf = false) where T : Component
        {
            return GetComponentsInParentInternal(typeof(T), includeSelf).Cast<T>().ToArray();
        }
        
        internal Component[] GetComponentsInParentInternal(Type type, bool includeSelf = false)
        {
            // Invalid Type
            if (type == null)
                return Array.Empty<Component>();
            
            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");

            // Find Component In Parent
            var results = new List<Component>();
            Transform current = includeSelf ? Transform : Transform.Parent;
            
            while (current != null)
            {
                foreach (var component in current.GameObject.Components)
                {
                    if (type.IsAssignableFrom(component.GetType()))
                    {
                        results.Add(component);
                    }
                }
                
                current = current.Parent;
            }

            return results.ToArray();
        }
    }
    
    // Get Component In Children
    public partial class Behaviour
    {
        public Component GetComponentInChildren(Type type, bool includeSelf = false)
        {
            return GetComponentInChildrenInternal(type, includeSelf);
        }

        public T GetComponentInChildren<T>(bool includeSelf = false) where T : Component
        {
            return GetComponentInChildrenInternal(typeof(T), includeSelf) as T;
        }
        
        internal Component GetComponentInChildrenInternal(Type type, bool includeSelf = false)
        {
            // Invalid Type
            if (type == null)
                return null;
            
            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");
            
            // For Each Child In GameObject
            foreach (var child in Transform.GetChildrenRecursive(includeSelf))
            {
                // For Each Component In Child
                foreach (var component in child.GameObject.Components)
                {
                    if (type.IsAssignableFrom(component.GetType()))
                    {
                        return component;
                    }
                }
            }

            return null;
        }
    }
    
    // Get Components
    public partial class Behaviour
    {
        public Component[] GetComponentsInChildren(bool includeSelf = false)
        {
            return GetComponentsInChildrenInternal(typeof(Component), includeSelf).ToArray();
        }
        
        public Component[] GetComponentsInChildren(Type type, bool includeSelf = false)
        {
            return GetComponentsInChildrenInternal(type, includeSelf).ToArray();
        }

        public T[] GetComponentsInChildren<T>(bool includeSelf = false) where T : Component
        {
            return GetComponentsInChildrenInternal(typeof(T), includeSelf).Cast<T>().ToArray();
        }
        
        internal Component[] GetComponentsInChildrenInternal(Type type, bool includeSelf = false)
        {
            // Invalid Type
            if (type == null)
                return Array.Empty<Component>();
            
            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");

            // Create Results
            var results = new List<Component>();
            
            // For Each Child In GameObject
            foreach (var child in Transform.GetChildrenRecursive(includeSelf))
            {
                // For Each Component In Child
                foreach (var component in child.GameObject.Components)
                {
                    if (type.IsAssignableFrom(component.GetType()))
                    {
                        results.Add(component);
                    }
                }
            }

            return results.ToArray();
        }
    }
    
    // Get Component Count
    public partial class Behaviour
    {
        public int GetComponentCount()
        {
            return GetComponentCountInternal(typeof(Component));
        }
        
        public int GetComponentCount(Type type)
        {
            return GetComponentCountInternal(type);
        }

        public int GetComponentCount<T>() where T : Component
        {
            return GetComponentCountInternal(typeof(T));
        }
        
        internal int GetComponentCountInternal(Type type)
        {
            // Invalid Type
            if (type == null)
                return 0;
            
            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");

            int result = 0;
            
            // For Each Component In GameObject
            foreach (var component in GameObject.Components)
            {
                if (type.IsAssignableFrom(component.GetType()))
                {
                    result += 1;
                }
            }

            return result;
        }
    }
    
    // Get Component Index
    public partial class Behaviour
    {
        public int GetComponentIndex(Type type)
        {
            return GetComponentIndexInternal(type);
        }

        public int GetComponentIndex<T>() where T : Component
        {
            return GetComponentIndexInternal(typeof(T));
        }
        
        internal int GetComponentIndexInternal(Type type)
        {
            // Invalid Type
            if (type == null)
                return -1;
            
            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");

            // For Each Component In GameObject
            for(int i=0; i<GameObject.Components.Count; i++)
            {
                if (type.IsAssignableFrom(GameObject.Components[i].GetType()))
                {
                    return i;
                }
            }

            return -1;
        }
    }
    
    // Get Component At Index
    public partial class Behaviour
    {
        public Component GetComponentAtIndex(int index)
        {
            return GetComponentAtIndexInternal(typeof(Component), index);
        }

        public T GetComponentAtIndex<T>(int index) where T : Component
        {
            return GetComponentAtIndexInternal(typeof(T), index) as T;
        }
        
        internal Component GetComponentAtIndexInternal(Type type, int index)
        {
            // Invalid Type
            if (type == null)
                return null;
            
            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");

            // Get Component
            if (index >= 0 && index < GameObject.Components.Count)
            {
                var result = GameObject.Components[index];

                if (type.IsAssignableFrom(result.GetType()))
                {
                    return result;
                }
            }

            return null;
        }
    }
    
    // Try & Get Component
    public partial class Behaviour
    {
        public bool TryGetComponent(Type type, out Component component)
        {
            return TryGetComponentInternal(type, out component);
        }

        public bool TryGetComponent<T>(out T component) where T : Component
        {
            if(TryGetComponentInternal(typeof(T), out var c))
            {
                component = c as T;
                return true;
            }

            component = null;
            return false;
        }
        
        internal bool TryGetComponentInternal(Type type, out Component component)
        {
            // Invalid
            component = null;
            
            // Invalid Type
            if (type == null)
                return false;

            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");
            
            // For Each Component In GameObject
            foreach (var c in GameObject.Components)
            {
                if (type.IsAssignableFrom(c.GetType()))
                {
                    component = c;
                    return true;
                }
            }

            return false;
        }
    }
    
    // Has Component
    public partial class Behaviour
    {
        public bool HasComponent(Component component)
        {
            return HasComponentInternal(component);
        }
        
        public bool HasComponent(Type type)
        {
            return HasComponentInternal(GetComponent(type));
        }
        
        public bool HasComponent<T>() where T : Component
        {
            return HasComponentInternal(GetComponent<T>());
        }

        internal bool HasComponentInternal<T>(T component) where T : Component
        {
            // Invalid Component
            if (component == null)
                return false;
            
            // Component Type
            var type = component.GetType();
            
            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");
            
            // For Each Component In GameObject
            foreach (var c in GameObject.Components)
            {
                if (c == component)
                {
                    return true;
                }
            }

            return false;
        }
    }

    // Destroy Component
    public partial class Behaviour
    {
        internal bool DestroyComponent(Component component)
        {
            return DestroyComponentInternal(component);
        }
        
        internal bool DestroyComponent(Type type)
        {
            return DestroyComponentInternal(GetComponent(type));
        }
        
        internal bool DestroyComponent<T>() where T : Component
        {
            return DestroyComponentInternal(GetComponent<T>());
        }

        internal bool DestroyComponentInternal<T>(T component) where T : Component
        {
            // Invalid Component
            if (component == null)
                return false;
            
            // Component Type
            var type = component.GetType();
            
            // Invalid Type
            if (!typeof(Component).IsAssignableFrom(type))
                throw new Exception($"Type '{type.Name}' does not inherit from Component");

            // Has Component
            if (HasComponent(component))
            {
                // Check Destroying
                if (!IsDestroying(this))
                {
                    // For Each Component
                    foreach (var checkComponent in GameObject.Components)
                    {
                        // For Each Required Component
                        foreach (RequireComponentAttribute required in checkComponent.GetType().GetCustomAttributes(typeof(RequireComponentAttribute), true))
                        {
                            if (required.Type == type)
                            {
                                throw new Exception($"Can't destroy Component '{type.Name}' on GameObject '{Name}' because Component '{checkComponent.GetType().Name}' requires it");
                            }
                        }
                    }
                }
                
                // Remove From GameObject
                // Debug.Log($"Component '{type.Name}' destroy on GameObject '{Name}'");
                GameObject.Components.Remove(component);
                return true;
            }

            return false;
        }
    }
}