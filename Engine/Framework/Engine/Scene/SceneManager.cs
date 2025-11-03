using System;

namespace Hybrid
{
    public static class SceneManager
    {
        public static Scene ActiveScene { get; private set; }
        
        
        // Load Scene
        public static void Load(Scene scene)
        {
            if (scene == null) throw new Exception("Can not load null scene");

            if (ActiveScene != null)
            {
                Close(ActiveScene);
            }

            ActiveScene = scene;
            Open(ActiveScene);
        }
        
        // Open Scene
        private static void Open(Scene scene)
        {
            if (scene == null) throw new Exception("Can not open null scene");
            
            Console.WriteLine($"Scene '{scene}' opened");
            scene.OnOpened();
        }
        
        // Close Scene
        private static void Close(Scene scene)
        {
            if (scene == null) throw new Exception("Can not null null scene");
            
            Console.WriteLine($"Scene '{scene}' closed");

            foreach (var obj in scene.GetSceneObjects())
            {
                obj.Destroy();
            }
            
            scene.OnClosed();
        }
    }
}