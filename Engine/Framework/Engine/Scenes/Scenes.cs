using System;

namespace Hybrid
{
    // Internal
    public sealed partial class Scenes : Module<Scenes>
    {
        // Initialize
        internal override void OnInitialize()
        {
            // Invalid Scene
            if (Platform.GetConfig().Scene == null)
            {
                Debug.LogException("No valid scene in config file");
            }
            
            // Load Config Scene
            Load(Platform.GetConfig().Scene);
        }

        // Update
        internal override void OnUpdate()
        {
            if (GetActiveScene() != null)
            {
                // For Each Root GameObject In Scene
                foreach (var gameObject in GetActiveScene().RootGameObjects)
                {
                    // Skip Invalid GameObject
                    if (gameObject == null || !gameObject.Active) continue;

                    // For Each Child In GameObject (Including Parent)
                    foreach (var child in gameObject.Transform.GetChildrenRecursive(true))
                    {
                        // Skip Invalid Child
                        if (child == null || !child.Enabled) continue;

                        // For Each Component
                        foreach (var component in child.GameObject.Components)
                        {
                            // Skip Invalid Component
                            if (component == null || !component.Enabled) continue;

                            // Awake
                            if (!component.DidAwake)
                            {
                                component.DidAwake = true;
                                component.OnComponentAwake();
                            }

                            // Start
                            if (!component.DidStart)
                            {
                                component.DidStart = true;
                                component.OnComponentStart();
                            }

                            // Update
                            component.OnComponentUpdate();
                        }
                    }
                }
            }
        }
        
        // Fixed Update
        internal override void OnFixedUpdate()
        {
            if (GetActiveScene() != null)
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
                            component.OnComponentFixedUpdate();
                        }
                    }
                }
            }
        }

        // Dispose
        internal override void OnDispose()
        {
            // Get Active Scene
            if (GetActiveScene() != null)
            {
                // Close Scene
                Close(GetActiveScene());
            }
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
            {
                Debug.LogError($"No active scene loaded");
                return null;
            }
            
            return Active;
        }
        
        public static void Load(Scene scene)
        {
            // Invalid Scene
            if (scene == null)
            {
                Debug.LogError($"Failed to load invalid scene");
                return;
            }

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
            // Invalid Scene
            if (scene == null)
            {
                Debug.LogError("Failed to open invalid scene");
                return;
            }
            
            // Set Active
            Active = scene;
            Debug.Log($"Scene '{scene.Name}' opened");
            scene.OnSceneOpen();
        }

        private static void Close(Scene scene)
        {
            // Invalid Scene
            if (scene == null)
            {
                Debug.LogWarning("Failed to close invalid scene");
                return;
            }

            if (GetActiveScene() != null)
            {
                // For Each GameObject In Scene
                foreach (var gameObject in GetActiveScene().GetRootGameObjects())
                {
                    // Destroy GameObject
                    Object.Destroy(gameObject);
                }
            
                Debug.Log($"Scene '{scene.Name}' closed");
                scene.OnSceneClose();
                Active = null;
            }
        }
    }
}