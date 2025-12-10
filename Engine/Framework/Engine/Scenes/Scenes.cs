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
            
            Load(Platform.GetConfig().Scene);
            base.OnInitialize();
        }

        // Update
        internal override void OnUpdate()
        {
            // For Each Object In Scene
            foreach (var gameObject in GetActiveScene().GetRootGameObjects())
            {
                // Skip Disabled GameObject
                if(!gameObject.Enabled) continue;
                
                // For Each Component In Children & Parent
                foreach (var component in gameObject.GetComponents())
                {
                    // Skip Disabled Component
                    if(!component.Enabled) continue;
                    
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
        
        // Late Update
        internal override void OnLateUpdate()
        {
            // For Each Object In Scene
            foreach (var gameObject in GetActiveScene().GetRootGameObjects())
            {
                // Skip Disabled GameObject
                if(!gameObject.Enabled) continue;
                
                // For Each Component In Children & Parent
                foreach (var component in gameObject.GetComponents())
                {
                    // Skip Disabled Component
                    if(!component.Enabled) continue;
                    
                    // Late Update
                    component.OnComponentLateUpdate();
                }
            }
        }

        // Fixed Update
        internal override void OnFixedUpdate()
        {
            // For Each Object In Scene
            foreach (var gameObject in GetActiveScene().GetRootGameObjects())
            {
                // Skip Disabled GameObject
                if(!gameObject.Enabled) continue;
                
                // For Each Component In Children & Parent
                foreach (var component in gameObject.GetComponents())
                {
                    // Skip Disabled Component
                    if(!component.Enabled) continue;
                    
                    // Fixed Update
                    component.OnComponentFixedUpdate();
                }
            }
        }

        // Dispose
        internal override void OnDispose()
        {
            if (Active != null)
            {
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
            if (Active == null)
                throw new Exception("No valid active scene loaded");
            
            return Active;
        }
        
        public static void Load(Scene scene)
        {
            if (scene == null)
                throw new Exception($"Failed to load invalid scene");

            if (Active != null)
            {
                Close(Active);
            }

            Open(scene);
        }

        private static void Open(Scene scene)
        {
            Active = scene;
            
            if (scene == null)
                throw new Exception("Failed to open invalid scene");
            
            // Debug.Log($"Scene '{scene.Name}' opened");
            scene.OnSceneOpen();
        }

        private static void Close(Scene scene)
        {
            if (scene == null)
                throw new Exception("Failed to close invalid scene");

            // Destroy Every GameObject In Scene
            foreach (var gameObject in GetActiveScene().GetRootGameObjects())
            {
                Object.Destroy(gameObject);
            }
            
            // Debug.Log($"Scene '{scene.Name}' closed");
            scene.OnSceneClose();
            Active = null;
        }
    }
}