using System;

namespace Hybrid
{
    // Internal
    public partial class Scenes : Module<Scenes>
    {
        // Initialize
        internal override void OnInitialize()
        {
            // Invalid Scene
            if (Platform.GetConfig().Scene == null)
                throw new Exception("No valid scene in config file");
            
            // Load Config Scene
            Load(Platform.GetConfig().Scene);
            base.OnInitialize();
        }

        // Update
        internal override void OnUpdate()
        {
            // For Each Root GameObject In Scene
            foreach (var gameObject in GetActiveScene().RootGameObjects)
            {
                // Skip Invalid GameObject
                if(gameObject == null || !gameObject.Active) continue;

                // For Each Child In GameObject (Including Parent)
                foreach (var child in gameObject.Transform.GetChildrenRecursive(true))
                {
                    // Skip Invalid Child
                    if(child == null || !child.Enabled) continue;
                    
                    // For Each Component
                    foreach (var component in child.GameObject.Components)
                    {
                        // Skip Invalid Component
                        if(component == null || !component.Enabled) continue;
                    
                        // Awake
                        if (!component.DidAwake)
                        {
                            component.DidAwake = true;
                            component.OnAwake();
                        }
                    
                        // Start
                        if (!component.DidStart)
                        {
                            component.DidStart = true;
                            component.OnStart();
                        }
                    
                        // Update
                        component.OnUpdate();
                    }
                }
            }
        }
        
        // Fixed Update
        internal override void OnFixedUpdate()
        {
            // For Each Root GameObject In Scene
            foreach (var gameObject in GetActiveScene().RootGameObjects)
            {
                // Skip Invalid GameObject
                if(gameObject == null || !gameObject.Active) continue;

                // For Each Child In GameObject (Including Parent)
                foreach (var child in gameObject.Transform.GetChildrenRecursive(true))
                {
                    // Skip Invalid Child
                    if(child == null || !child.Enabled) continue;
                    
                    // For Each Component
                    foreach (var component in child.GameObject.Components)
                    {
                        // Skip Invalid Component
                        if (component == null || !component.Enabled) continue;

                        // Fixed Update
                        component.OnFixedUpdate();
                    }
                }
            }
        }

        // Dispose
        internal override void OnDispose()
        {
            // Get Active Scene
            if (Active != null)
            {
                // Close Scene
                Close(Active);
            }
            
            base.OnDispose();
        }
    }

    // Scene API
    public partial class Scenes
    {
        private static Scene Active
        {
            get; set;
        }

        public static Scene GetActiveScene()
        {
            // Invalid Scene
            if (Active == null)
                throw new Exception("No valid active scene loaded");
            
            return Active;
        }
        
        public static void Load(Scene scene)
        {
            // Invalid Scene
            if (scene == null)
                throw new Exception($"Failed to load invalid scene");

            if (Active != null)
            {
                // Close Scene
                Close(Active);
            }

            // Open Scene
            Open(scene);
        }

        private static void Open(Scene scene)
        {
            // Set Active
            Active = scene;
            
            // Invalid Scene
            if (scene == null)
                throw new Exception("Failed to open invalid scene");
            
            // Debug.Log($"Scene '{scene.Name}' opened");
            scene.OnSceneOpen();
        }

        private static void Close(Scene scene)
        {
            // Invalid Scene
            if (scene == null)
                throw new Exception("Failed to close invalid scene");

            // For Each GameObject In Scene
            foreach (var gameObject in GetActiveScene().GetRootGameObjects())
            {
                // Destroy GameObject
                Object.Destroy(gameObject);
            }
            
            // Debug.Log($"Scene '{scene.Name}' closed");
            scene.OnSceneClose();
            Active = null;
        }
    }
}