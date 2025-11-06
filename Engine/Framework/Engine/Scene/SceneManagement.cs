using System;

namespace Hybrid
{
    // Scene Management
    public class SceneManagement : Module
    {
        // Properties
        public static Scene ActiveScene { get; private set; }

        
        // Constructor
        internal SceneManagement(Config config)
        {
            Load(config.Scene);
        }
        
        
        // Methods
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
        
        private static void Open(Scene scene)
        {
            if (scene == null)
            {
                throw new ArgumentNullException(nameof(scene), "Can't open a null scene.");
            }
            
            Console.WriteLine($"Scene '{scene}' opened");
            scene.OnOpened();
        }
        
        private static void Close(Scene scene)
        {
            if (scene == null)
            {
                throw new ArgumentNullException(nameof(scene), "Can't load a null scene.");
            }
            
            foreach (var obj in scene.SceneGameObjects.ToArray())
            {
                Object.Destroy(obj);
            }
            
            Console.WriteLine($"Scene '{scene}' closed");
            scene.OnClosed();
        }
        

        // Dispose
        internal override void Dispose()
        {
            Console.WriteLine("Scene Management Disposed");
            
            if (ActiveScene != null)
            {
                Close(ActiveScene);
            }
        }
    }
}