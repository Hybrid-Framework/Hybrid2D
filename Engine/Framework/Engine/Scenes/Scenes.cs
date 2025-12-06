using System;

namespace Hybrid
{
    // Internal
    public partial class Scenes : Module<Scenes>
    {
        internal override void OnInitialize()
        {
            // Invalid Scene
            if (Platform.GetConfig().Scene == null)
                throw new Exception("No valid scene in config file");
            
            Load(Platform.GetConfig().Scene);
            
            base.OnInitialize();
        }

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
            
            Console.WriteLine($"Scene '{scene.Name}' opened");
            scene.OnSceneOpen();
        }

        private static void Close(Scene scene)
        {
            if (scene == null)
                throw new Exception("Failed to close invalid scene");

            foreach (var gameObject in GetActiveScene().GetSceneGameObjects())
            {
                Object.Destroy(gameObject);
            }
            
            Console.WriteLine($"Scene '{scene.Name}' closed");
            scene.OnSceneClose();
            Active = null;
        }
    }
}