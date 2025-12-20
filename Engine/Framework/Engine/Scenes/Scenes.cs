using System.Reflection;
using System;

namespace Hybrid
{
    // Internal
    public sealed partial class Scenes : Module<Scenes>
    {
        private Scenes() {}
        
        internal static HashSet<Scene> AllScenes { get; set; } = new HashSet<Scene>();
        internal static Scene ActiveScene { get; set; }
        
        
        // Initialize
        internal override void OnInitialize()
        {
            // Get All Types With Attribute SceneAttribute
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()).Where(t => t.GetCustomAttribute<SceneAttribute>() != null).ToList();

            // For Each Type
            foreach (var type in types)
            {
                // Get Information From Attribute
                var attribute = type.GetCustomAttribute<SceneAttribute>()!;

                // Check duplicate name
                if (AllScenes.Any(s => s.Name == attribute.Name))
                {
                    throw new Exception($"Duplicate scene name '{attribute.Name}' found please ensure each scene is unique");
                }

                // Check duplicate index
                if (AllScenes.Any(s => s.Index == attribute.Index))
                {
                    throw new Exception($"Duplicate scene index '{attribute.Index}' found please ensure each scene is unique");
                }

                // Create Instance
                var scene = (Scene)Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, null, null);
                scene?.Index = attribute.Index;
                scene?.Name = attribute.Name;
                scene?.Type = type;

                // Add Scene
                if (scene != null)
                {
                    AllScenes.Add(scene);
                }
            }
            
            // Invalid Scenes
            if(AllScenes.Count == 0)
            {
                throw new Exception("No valid scenes found");
            }
            
            // Load Scene
            LoadScene(AllScenes.Min(s => s.Index), SceneMode.Single);
        }
        
        // Update
        internal override void OnUpdate()
        {
            // For Each Active Scene
            foreach(var scene in GetActiveScenes())
            {
                // For Each Root GameObject In Scene
                foreach (var gameObject in scene.GetRootGameObjects())
                {
                    // Skip Invalid GameObject
                    if(gameObject == null || !gameObject.Active) continue;

                    // For Each Child In GameObject (Including Parent)
                    foreach (var child in gameObject.Transform.GetChildrenRecursive(true))
                    {
                        // Skip Invalid Child
                        if(child == null || !child.Enabled) continue;
                    
                        // For Each Component
                        foreach (var component in child.GameObject.Components)
                        {
                            // Skip Invalid Component
                            if (component == null || !component.Enabled) continue;
                            
                            try
                            {
                                // Awake
                                if (!component.DidAwake)
                                {
                                    component.DidAwake = true;
                                    component.OnComponentAwake();
                                }

                                // Start
                                if (!component.DidStart)
                                {
                                    component.DidStart = true;
                                    component.OnComponentStart();
                                }

                                // Update
                                if (component.DidAwake && component.DidStart)
                                {
                                    component.OnComponentUpdate();
                                }
                            }
                            catch (Exception ex)
                            {
                                Exceptions.Throw(ex);
                            }
                        }
                    }
                }
            }
        }
        
        // Late Update
        internal override void OnLateUpdate()
        {
            // For Each Active Scene
            foreach(var scene in GetActiveScenes())
            {
                // For Each Root GameObject In Scene
                foreach (var gameObject in scene.GetRootGameObjects())
                {
                    // Skip Invalid GameObject
                    if(gameObject == null || !gameObject.Active) continue;

                    // For Each Child In GameObject (Including Parent)
                    foreach (var child in gameObject.Transform.GetChildrenRecursive(true))
                    {
                        // Skip Invalid Child
                        if(child == null || !child.Enabled) continue;
                    
                        // For Each Component
                        foreach (var component in child.GameObject.Components)
                        {
                            // Skip Invalid Component
                            if (component == null || !component.Enabled) continue;
                            
                            try
                            {
                                // Late Update
                                if (component.DidAwake && component.DidStart)
                                {
                                    component.OnComponentLateUpdate();
                                }
                            }
                            catch(Exception ex)
                            {
                                Exceptions.Throw(ex);
                            }
                        }
                    }
                }
            }
        }
        
        // Fixed Update
        internal override void OnFixedUpdate()
        {
            // For Each Active Scene
            foreach(var scene in GetActiveScenes())
            {
                // For Each Root GameObject In Scene
                foreach (var gameObject in scene.GetRootGameObjects())
                {
                    // Skip Invalid GameObject
                    if(gameObject == null || !gameObject.Active) continue;

                    // For Each Child In GameObject (Including Parent)
                    foreach (var child in gameObject.Transform.GetChildrenRecursive(true))
                    {
                        // Skip Invalid Child
                        if(child == null || !child.Enabled) continue;
                    
                        // For Each Component
                        foreach (var component in child.GameObject.Components)
                        {
                            // Skip Invalid Component
                            if (component == null || !component.Enabled) continue;
                            
                            try
                            {
                                // Fixed Update
                                if (component.DidAwake && component.DidStart)
                                {
                                    component.OnComponentFixedUpdate();
                                }
                            }
                            catch(Exception ex)
                            {
                                Exceptions.Throw(ex);
                            }
                        }
                    }
                }
            }
        }
        
        // Render
        internal override void OnRender()
        {
            // For Each Active Scene
            foreach(var scene in GetActiveScenes())
            {
                // For Each Root GameObject In Scene
                foreach (var gameObject in scene.GetRootGameObjects())
                {
                    // Skip Invalid GameObject
                    if(gameObject == null || !gameObject.Active) continue;

                    // For Each Child In GameObject (Including Parent)
                    foreach (var child in gameObject.Transform.GetChildrenRecursive(true))
                    {
                        // Skip Invalid Child
                        if(child == null || !child.Enabled) continue;
                    
                        // For Each Component
                        foreach (var component in child.GameObject.Components)
                        {
                            // Skip Invalid Component
                            if (component == null || !component.Enabled) continue;
                            
                            try
                            {
                                // Render
                                if (component.DidAwake && component.DidStart)
                                {
                                    component.OnComponentRender();
                                }
                            }
                            catch(Exception ex)
                            {
                                Exceptions.Throw(ex);
                            }
                        }
                    }
                }
            }
        }

        // Dispose
        internal override void OnDispose()
        {
            // For Each Active Scene
            foreach (var scene in GetActiveScenes())
            {
                // Close Scene
                CloseScene(scene);
            }
        }
    }

    // Scene API
    public partial class Scenes
    {
        public static Scene GetActiveScene()
        {
            return ActiveScene;
        }

        public static void SetActiveScene(Scene scene)
        {
            if (scene == null || !scene.IsLoaded)
            {
                Debug.Warning($"Can only call '{nameof(SetActiveScene)}' on a valid loaded scene");
                return;
            }

            ActiveScene = scene;
        }
        
        public static Scene[] GetActiveScenes()
        {
            List<Scene> results = new List<Scene>();
            
            foreach (var scene in AllScenes)
            {
                if (scene.IsLoaded)
                {
                    results.Add(scene);
                }
            }

            return results.ToArray();
        }

        public static Scene GetSceneByName(string name)
        {
            foreach (var scene in AllScenes)
            {
                if (scene.Name == name)
                {
                    return scene;
                }
            }

            return null;
        }
        
        public static Scene GetSceneByIndex(int index)
        {
            foreach (var scene in AllScenes)
            {
                if (scene.Index == index)
                {
                    return scene;
                }
            }

            return null;
        }

        public static void LoadScene(int index, SceneMode mode)
        {
            // Get Scene Information by Index
            var scene = GetSceneByIndex(index);

            // Invalid Scene
            if (scene == null)
            {
                Debug.Warning($"Failed to load scene: '{index}'");
                return;
            }
            
            // Load Scene
            LoadScene(scene, mode);
        }

        public static void LoadScene(string name, SceneMode mode)
        {
            // Get Scene Information by Name
            var scene = GetSceneByName(name);

            // Invalid Scene
            if (scene == null)
            {
                Debug.Warning($"Failed to load scene: '{name}'");
                return;
            }
            
            // Load Scene
            LoadScene(scene, mode);
        }

        private static void LoadScene(Scene scene, SceneMode mode)
        {
            if (scene.IsLoaded)
            {
                // Scene Already Loaded
                Debug.Warning($"Scene '{scene.Name}' already loaded");
                return;
            }
            
            if (mode == SceneMode.Single)
            {
                // For Each Active Scene
                foreach (var active in GetActiveScenes())
                {
                    // Close Scene
                    CloseScene(active);
                }
            }
            
            // Open Scene
            OpenScene(scene);
        }

        private static void OpenScene(Scene scene)
        {
            if (scene == null)
            {
                Debug.Warning($"Failed to open invalid scene");
                return;
            }
            
            try
            {
                AddScene(scene);
                
                Debug.Log($"Scene '{scene.Name}' opened");
                scene.OnSceneOpen();
            }
            catch (Exception ex)
            {
                Exceptions.Throw(ex);
            }
        }

        private static void CloseScene(Scene scene)
        {
            if (scene == null)
            {
                Debug.Warning($"Failed to close invalid scene");
                return;
            }
            
            try
            {
                scene.OnSceneClose();
                
                // For Each GameObject In Scene
                foreach (var gameObject in scene.GetRootGameObjects())
                {
                    // Destroy
                    Object.Destroy(gameObject);
                }
                
                Debug.Log($"Scene '{scene.Name}' closed");
                RemoveScene(scene);
            }
            catch (Exception ex)
            {
                Exceptions.Throw(ex);
            }
        }
    }
    
    // Objects
    public partial class Scenes
    {
        private static void AddScene(Scene scene)
        {
            scene.IsLoaded = true;

            if (!scene.IsActiveScene)
            {
                ActiveScene = scene;
            }
        }

        private static void RemoveScene(Scene scene)
        {
            scene.IsLoaded = false;

            if (scene.IsActiveScene)
            {
                ActiveScene = null;
            }
        }
        
        internal static void AddObject(GameObject gameObject)
        {
            if (!Object.IsDestroyed(gameObject))
            {
                var scene = GetActiveScene();
                
                if (scene != null)
                {
                    Debug.Log($"GameObject '{gameObject.Name}' added to Scene '{scene.Name}' root objects");
                    scene.RootGameObjects.Add(gameObject);
                    gameObject.Scene = scene;
                }
            }
        }
        
        internal static void RemoveObject(GameObject gameObject)
        {
            var scene = gameObject.GetScene();
            
            if (scene != null)
            {
                Debug.Log($"GameObject '{gameObject.Name}' removed from Scene '{scene.Name}' root objects");
                scene.RootGameObjects.Remove(gameObject);
            }
        }
    }
}