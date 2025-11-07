using System;

namespace Hybrid
{
    // Scene Management
    public partial class SceneManagement : Module
    {
        public static Scene ActiveScene { get; private set; }

        internal SceneManagement(Config config)
        {
            Load(config.Scene);
        }

        
        internal override void Dispose()
        {
            Console.WriteLine("Scene Management Disposed");

            if (ActiveScene != null)
            {
                Close(ActiveScene);
            }
        }
    }

    // Scene Management API
    public partial class SceneManagement
    {
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
            
            foreach (var obj in scene.GetSceneObjects())
            {
                Object.Destroy(obj);
            }
            
            Console.WriteLine($"Scene '{scene}' closed");
            scene.OnClosed();
        }
    }
}