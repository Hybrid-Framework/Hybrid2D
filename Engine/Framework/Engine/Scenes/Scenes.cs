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
            if (GetActiveScene() != null)
            {
                foreach (var gameObject in GetActiveScene().GetSceneGameObjects())
                {
                    if(!gameObject.Enabled) continue;
                    
                    foreach (var component in gameObject.GetComponents())
                    {
                        if(!component.Enabled) continue;
                        
                        // OnAwake
                        if (!component.DidAwake)
                        {
                            component.DidAwake = true;
                            component.OnAwake();
                        }
                        
                        // OnStart
                        if (!component.DidStart)
                        {
                            component.DidStart = true;
                            component.OnStart();
                        }
                        
                        // OnUpdate
                        component.OnUpdate();
                    }
                }
            }
        }
        
        // Late Update
        internal override void OnLateUpdate()
        {
            if (GetActiveScene() != null)
            {
                foreach (var gameObject in GetActiveScene().GetSceneGameObjects())
                {
                    if(!gameObject.Enabled) continue;
                    
                    foreach (var component in gameObject.GetComponents())
                    {
                        if(!component.Enabled) continue;
                        
                        component.OnLateUpdate();
                    }
                }
            }
        }

        // Fixed Update
        internal override void OnFixedUpdate()
        {
            if (GetActiveScene() != null)
            {
                foreach (var gameObject in GetActiveScene().GetSceneGameObjects())
                {
                    if(!gameObject.Enabled) continue;
                    
                    foreach (var component in gameObject.GetComponents())
                    {
                        if(!component.Enabled) continue;
                        
                        component.OnFixedUpdate();
                    }
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
            
            Debug.Log($"Scene '{scene.Name}' opened");
            scene.OnSceneOpen();
        }

        private static void Close(Scene scene)
        {
            if (scene == null)
                throw new Exception("Failed to close invalid scene");

            // Destroy Every GameObject In Scene
            foreach (var gameObject in GetActiveScene().GetSceneGameObjects())
            {
                Object.Destroy(gameObject);
            }
            
            Debug.Log($"Scene '{scene.Name}' closed");
            scene.OnSceneClose();
            Active = null;
        }
    }
}