using System;

namespace Hybrid
{
    // Scenes
    public partial class Scenes : Module
    {
        private static Scene Active { get; set; }


        internal Scenes()
        {
            Load(Engine.Config.Scene);
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
    
    // Scenes API
    public partial class Scenes
    {
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
        
        public static Scene GetActiveScene()
        {
            return Active;
        }
    }
}