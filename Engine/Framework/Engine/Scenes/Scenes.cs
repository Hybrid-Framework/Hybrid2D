using System;

namespace Hybrid
{
    // Scenes Manager
    public class Scenes : Module
    {
        private static Scene Active { get; set; }
        
        internal Scenes(Config config)
        {
            Load(config.Scene);
        }
        
        public static Scene GetActiveScene()
        {
            return Active;
        }
        
        public static void Load(Scene scene)
        {
            if (scene == null) throw new Exception("Invalid Scene");

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
            if (scene == null) throw new Exception("Invalid Scene");
            
            Console.WriteLine($"Scene {scene.Name} opened");
            scene.OnSceneOpen();
        }

        private static void Close(Scene scene)
        {
            if (scene == null) throw new Exception("Invalid Scene");
            
            foreach (var obj in scene.GetSceneObjects())
            {
                Object.Destroy(obj);
            }
            
            Console.WriteLine($"Scene {scene.Name} closed");
            scene.OnSceneClose();
        }

        internal override void OnDestroy()
        {
            Console.WriteLine("Scenes Disposed");
            
            if (Active != null)
            {
                Close(Active);
            }
        }
    }
}