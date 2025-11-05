using System;

namespace Hybrid
{
    // Scene Management
    public static class SceneManagement
    {
        public static Scene ActiveScene { get; private set; }
        
        
        // Load Scene
        public static void Load(Scene scene)
        {
            if (scene == null)
            {
                throw new ArgumentNullException(nameof(scene), "Can't load a null scene.");
            }

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
            if (scene == null)
            {
                throw new ArgumentNullException(nameof(scene), "Can't open a null scene.");
            }
            
            Console.WriteLine($"Scene '{scene}' opened");
            scene.OnOpened();
        }
        
        // Close Scene
        private static void Close(Scene scene)
        {
            if (scene == null)
            {
                throw new ArgumentNullException(nameof(scene), "Can't load a null scene.");
            }
            
            // For Each GameObject In Scene
            foreach (var obj in scene.SceneGameObjects.ToArray())
            {
                Object.Destroy(obj);
            }
            
            Console.WriteLine($"Scene '{scene}' closed");
            scene.OnClosed();
        }

        internal static void Dispose()
        {
            if (ActiveScene != null)
            {
                Close(ActiveScene);
            }
        }
    }
}