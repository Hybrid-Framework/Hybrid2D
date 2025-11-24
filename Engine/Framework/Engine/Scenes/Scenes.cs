using System;

namespace Hybrid
{
    // Scenes
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