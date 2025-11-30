using System;

namespace Hybrid
{
    // Internal
    public partial class Scenes : Module<Scenes>
    {
        private Scenes() { }

        // Initialize
        internal override void OnInitialize()
        {
            base.OnInitialize();
            
            Load(Platform.GetConfig().Scene);
        }
        
        // Dispose
        internal override void OnDispose()
        {
            base.OnDispose();
            
            if (Active != null)
            {
                Close(Active);
            }
        }

        // Update
        internal override void OnUpdate()
        {
            base.OnUpdate();
            
            if (GetActiveScene() != null)
            {
                // For Each GameObject
                foreach (var gameObject in GetActiveScene().GetSceneGameObjects())
                {
                    // Skip Disabled GameObject
                    if(!gameObject.Enabled) continue;
                    
                    // Get Components
                    foreach (var component in gameObject.GetComponents())
                    {
                        // Skip Disabled Component
                        if(!component.Enabled) continue;
                        
                        // Process Component
                        if (!component.ComponentInitialized)
                        {
                            component.ComponentInitialized = true;
                            component.OnAwake();
                            component.OnStart();
                        }
                        
                        component.OnUpdate();
                    }
                }
            }
        }
    }
    
    // Scenes API
    public partial class Scenes
    {
        private static Scene Active { get; set; }
        
        
        public static Scene GetActiveScene()
        {
            // Return Active Scene
            return Active;
        }
        
        public static void Load(Scene scene)
        {
            // Invalid Scene
            if (scene == null)
                throw new Exception("Invalid Scene");

            // Already Loaded
            if (Active != null && Active.Name == scene.Name)
                return;

            // Close
            if (Active != null)
            {
                Close(Active);
                Active = null;
            }

            // Open
            Active = scene;
            Open(scene);
        }

        private static void Open(Scene scene)
        {
            // Invalid Scene
            if (scene == null)
                throw new Exception("Invalid Scene");
            
            // On Scene Opened
            Console.WriteLine($"Scene '{scene.Name}' opened");
            scene.OnSceneOpen();
        }

        private static void Close(Scene scene)
        {
            // Invalid Scene
            if (scene == null)
                throw new Exception("Invalid Scene");
            
            // For Each GameObject In Scene
            foreach (var obj in scene.GetSceneGameObjects())
            {
                // Destroy
                Object.Destroy(obj);
            }
            
            // On Scene Closed
            Console.WriteLine($"Scene '{scene.Name}' closed");
            scene.OnSceneClose();
        }
    }
}