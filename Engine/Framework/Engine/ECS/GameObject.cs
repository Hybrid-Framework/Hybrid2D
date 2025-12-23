using System.Collections.Generic;
using System.Collections;
using System;

namespace Hybrid
{
    // GameObject
    public sealed partial class GameObject : Behaviour
    {
        internal List<Component> Components { get; private set; } = new List<Component>();

        private Scene _Scene { get; set; } = null;
        public Scene Scene
        {
            get
            {
                if (IsDestroyed(this))
                {
                    return null;
                }

                return _Scene;
            }
            internal set
            {
                if (!IsDestroyed(this))
                {
                    _Scene = value;
                }
            }
        }
        
        private string _Layer { get; set; } = "Default";
        public string Layer
        {
            get
            {
                if (IsDestroyed(this))
                {
                    return "Null";
                }

                return _Layer;
            }
            set
            {
                if (!IsDestroyed(this))
                {
                    _Layer = value;
                }
            }
        }
        
        private Tag _Tag { get; set; } = Tags.Untagged;
        public Tag Tag
        {
            get
            {
                if (IsDestroyed(this))
                {
                    return new Tag("Destroyed");
                }

                return _Tag;
            }
            set
            {
                if (!IsDestroyed(this))
                {
                    _Tag = value;
                }
            }
        }
        
        private bool _Static { get; set; } = false;
        public bool Static
        {
            get
            {
                if (IsDestroyed(this))
                {
                    return false;
                }

                return _Static;
            }
            set
            {
                if (!IsDestroyed(this))
                {
                    _Static = value;
                }
            }
        }
        
        private bool _Active { get; set; } = true;
        public bool Active
        {
            get
            {
                if (IsDestroyed(this))
                {
                    return false;
                }

                return _Active;
            }
            set
            {
                if (!IsDestroyed(this))
                {
                    _Active = value;
                }
            }
        }
        
        public GameObject(string name = null)
        {
            // Invalid Scene
            if (Scenes.GetActiveScene() == null)
            {
                throw new Exception("Can't create GameObject's with no scene loaded\n" + "You should only create GameObject's in 'OnSceneOpen' or after the scene has loaded");
            }
            
            // GameObject
            GameObject = this;
            
            // Transform
            Transform = AddComponent<Transform>();
            Transform.GameObject = GameObject;
            Transform.Transform = Transform;
            
            // Name
            Name = name ?? Name;
            
            // Scene
            Scenes.AddObject(this, Scenes.GetActiveScene());
        }

        // Dispose
        internal override void OnDispose()
        {
            if (!IsDestroyed(this))
            {
                // For Each Child In GameObject
                foreach (var child in Transform.GetChildrenRecursive())
                {
                    // Destroy Child GameObject
                    DestroyImmediate(child.GameObject);
                }
            
                // For Each Component In GameObject
                foreach (var component in GetComponents())
                {
                    // Destroy Component
                    DestroyImmediate(component);
                }
            
                // Remove From Scene
                Scenes.RemoveObject(this);
            }
        }
    }
    
    // Find By Types
    public partial class GameObject
    {
        public static GameObject[] FindGameObjectsByName(string name, bool activeOnly = false)
        {
            var results = new List<GameObject>();

            // For Each Active Scene
            foreach(var scene in Scenes.GetActiveScenes())
            {
                // For Each Root GameObject In Scene
                foreach (var gameObject in scene.GetRootGameObjects())
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
                            results.Add(child.GameObject);
                        }
                    }
                }
            }

            return results.ToArray();
        }
        
        public static GameObject FindGameObjectByName(string name, bool activeOnly = false)
        {
            // For Each Active Scene
            foreach(var scene in Scenes.GetActiveScenes())
            {
                // For Each Root GameObject In Scene
                foreach (var gameObject in scene.GetRootGameObjects())
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

            // For Each Active Scene
            foreach(var scene in Scenes.GetActiveScenes())
            {
                // For Each Root GameObject In Scene
                foreach (var gameObject in scene.GetRootGameObjects())
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
            // For Each Active Scene
            foreach(var scene in Scenes.GetActiveScenes())
            {
                // For Each Root GameObject In Scene
                foreach (var gameObject in scene.GetRootGameObjects())
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
        
        public static GameObject[] FindGameObjectsByTag(Tag tag, bool activeOnly = false)
        {
            var results = new List<GameObject>();

            // For Each Active Scene
            foreach(var scene in Scenes.GetActiveScenes())
            {
                // For Each Root GameObject In Scene
                foreach (var gameObject in scene.GetRootGameObjects())
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
        
        public static GameObject FindGameObjectByTag(Tag tag, bool activeOnly = false)
        {
            // For Each Active Scene
            foreach(var scene in Scenes.GetActiveScenes())
            {
                // For Each Root GameObject In Scene
                foreach (var gameObject in scene.GetRootGameObjects())
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
    }

    // GameObject
    public partial class GameObject
    {
        public void SetActive(bool active)
        {
            Active = active;
        }

        public GameObject Find(string name)
        {
            foreach (Transform child in Transform.GetChildrenRecursive(true))
            {
                if (child.Name == name)
                {
                    return child.GameObject;
                }
            }

            return null;
        }
    }
}