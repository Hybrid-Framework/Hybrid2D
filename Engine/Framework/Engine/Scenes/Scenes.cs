using System;

namespace Hybrid
{
    // Internal
    public partial class Scenes : Module<Scenes>
    {
        private Scenes() { }

        // Create
        internal override void OnCreate()
        {
            Console.WriteLine("Scenes Created");

            var config = Platform.GetConfig();
            
            Load(config.Scene);
        }
        
        // Destroy
        internal override void OnDestroy()
        {
            Console.WriteLine("Scenes Destroyed");
            
            if (Active != null)
            {
                Close(Active);
            }
        }
    }
    
    // Scenes API
    public partial class Scenes
    {
        private static Scene Active { get; set; }
        
        
        public static Scene GetActiveScene()
        {
            return Active;
        }
        
        public static void Load(Scene scene)
        {
            // Invalid Scene
            if (scene == null)
                throw new Exception("Invalid Scene");

            if (Active != null)
            {
                Close(Active);
                Active = null;
            }

            Active = scene;
            Open(scene);
        }

        private static void Open(Scene scene)
        {
            // Invalid Scene
            if (scene == null)
                throw new Exception("Invalid Scene");
            
            Console.WriteLine($"Scene '{scene.Name}' opened");
            scene.OnSceneOpen();
        }

        private static void Close(Scene scene)
        {
            // Invalid Scene
            if (scene == null)
                throw new Exception("Invalid Scene");
            
            foreach (var obj in scene.GetSceneObjects())
            {
                Object.Destroy(obj);
            }
            
            Console.WriteLine($"Scene '{scene.Name}' closed");
            scene.OnSceneClose();
        }
    }
}