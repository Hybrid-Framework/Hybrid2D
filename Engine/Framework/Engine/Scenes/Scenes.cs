using System;

namespace Hybrid
{
    // Internal
    public partial class Scenes : Module<Scenes>
    {
        internal override void OnInitialize()
        {
            var scene = Platform.GetConfig().Scene;
            
            if (scene == null)
                throw new Exception("No valid scene in config file");
            
            Load(scene);
            
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
                throw new Exception($"Failed to load null scene");

            if (Active == scene)
                throw new Exception($"Scene '{scene.Name}' already loaded");

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
                throw new Exception("Failed to open null scene");
            
            Console.WriteLine($"Scene '{scene.Name}' opened");
            scene.OnSceneOpen();
        }

        private static void Close(Scene scene)
        {
            if (scene == null)
                throw new Exception("Failed to close null scene");

            foreach (GameObject gameObject in Active.GetSceneGameObjects())
            {
                Object.Destroy(gameObject);
            }
            
            Console.WriteLine($"Scene '{scene.Name}' closed");
            scene.OnSceneClose();
            Active = null;
        }
    }
}