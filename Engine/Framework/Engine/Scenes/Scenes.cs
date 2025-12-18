using System.Reflection;
using System;

namespace Hybrid
{
    // Internal
    public sealed partial class Scenes : Module<Scenes>
    {
        private Scenes() {}
        
        internal static HashSet<SceneInformation> AllScenes { get; set; } = new HashSet<SceneInformation>();
        internal static HashSet<GameObject> SceneQueue { get; set; } = new HashSet<GameObject>();
        internal static Scene ActiveScene { get; set; }
        
        internal class SceneInformation
        {
            internal string SceneName;
            internal Type SceneType;
            internal int SceneIndex;

            internal SceneInformation(Type type, string name, int index)
            {
                this.SceneIndex = index;
                this.SceneType = type;
                this.SceneName = name;
            }
        }
        
        
        // Initialize
        internal override void OnInitialize()
        {
            var information = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()).Where(t => t.GetCustomAttribute<SceneAttribute>() != null).ToList();

            if (information.Count > 0)
            {
                foreach (var type in information)
                {
                    var attribute = type.GetCustomAttribute<SceneAttribute>()!;

                    // Check duplicate name
                    if (AllScenes.Any(s => s.SceneName == attribute.Name))
                    {
                        throw new Exception($"Duplicate scene name '{attribute.Name}' found please ensure each scene is unique");
                    }

                    // Check duplicate index
                    if (AllScenes.Any(s => s.SceneIndex == attribute.Index))
                    {
                        throw new Exception($"Duplicate scene index '{attribute.Index}' found please ensure each scene is unique");
                    }

                    AllScenes.Add(new SceneInformation(type, attribute.Name, attribute.Index));
                }
            }
            else
            {
                throw new Exception("No Scenes Found!");
            }
            
            // Load First Scene
            Load(AllScenes.Min(s => s.SceneIndex));
        }

        // Update
        internal override void OnUpdate()
        {
            // Scene
            if (ActiveScene != null)
            {
                // For Each Root GameObject In Scene
                foreach (var gameObject in ActiveScene.GetRootGameObjects())
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
            // Scene
            if (ActiveScene != null)
            {
                // For Each Root GameObject In Scene
                foreach (var gameObject in ActiveScene.GetRootGameObjects())
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
            // Scene
            if (ActiveScene != null)
            {
                // For Each Root GameObject In Scene
                foreach (var gameObject in ActiveScene.GetRootGameObjects())
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
            // Scene
            if (ActiveScene != null)
            {
                // For Each Root GameObject In Scene
                foreach (var gameObject in ActiveScene.GetRootGameObjects())
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
            // Get Active Scene
            if (ActiveScene != null)
            {
                // Close Scene
                Close(ActiveScene);
            }
        }
    }

    // Scene API
    public partial class Scenes
    {
        public static Scene GetActiveScene()
        {
            if (ActiveScene == null)
                throw new Exception("No valid scene loaded");
            
            return ActiveScene;
        }
        
        public static void Load(int index)
        {
            // Get Scene Information by Index
            var information = AllScenes.FirstOrDefault(s => s.SceneIndex == index);
            
            // Invalid Scene
            if (information != null)
            {
                // Close Scene
                if (ActiveScene != null)
                {
                    // Already Loaded
                    if (ActiveScene.Index == index)
                    {
                        Debug.Warning($"Scene '{index}' already loaded");
                        return;
                    }
                    
                    Close(ActiveScene);
                }

                // Create Scene
                var scene = (Scene)Activator.CreateInstance(information.SceneType, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, null, null);
                scene?.Index = information.SceneIndex;
                scene?.Name = information.SceneName;
                Open(scene);
            }
            else
            {
                throw new Exception($"Failed to load scene with index {index}");
            }
        }
        
        public static void Load(string name)
        {
            // Get Scene Information by Name
            var information = AllScenes.FirstOrDefault(s => s.SceneName == name);
            
            // Invalid Scene
            if (information != null)
            {
                // Close Scene
                if (ActiveScene != null)
                {
                    // Already Loaded
                    if (ActiveScene.Name == name)
                    {
                        Debug.Warning($"Scene '{name}' already loaded");
                        return;
                    }
                    
                    Close(ActiveScene);
                }

                // Open Scene
                var scene = (Scene)Activator.CreateInstance(information.SceneType, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, null, null);
                scene?.Index = information.SceneIndex;
                scene?.Name = information.SceneName;
                Open(scene);
            }
            else
            {
                throw new Exception($"Failed to load scene with name {name}");
            }
        }

        private static void Open(Scene scene)
        {
            // Invalid Scene
            if (scene != null)
            {
                try
                {
                    // Set Scene
                    ActiveScene = scene;
                    Debug.Log($"Scene '{scene.Name}' opened");

                    // For Each Object In Queue
                    foreach (var gameObject in SceneQueue.ToArray())
                    {
                        // Add To Scene
                        AddObject(gameObject);
                    }
                    
                    // Call
                    scene.OnSceneOpen();
                    SceneQueue.Clear();
                }
                catch (Exception ex)
                {
                    Exceptions.Throw(ex);
                }
            }
            else
            {
                throw new Exception($"Failed to open invalid scene");
            }
        }

        private static void Close(Scene scene)
        {
            if (scene != null)
            {
                try
                {
                    // Call
                    scene.OnSceneClose();
                    
                    // For Each GameObject In Scene
                    foreach (var gameObject in scene.GetRootGameObjects())
                    {
                        // Don't Destroy On Load but remove if destroyed or quitting application
                        if (Object.IsDontDestroyOnLoad(gameObject) && !Engine.Instance.IsQuit)
                        {
                            // Add To Queue For Next Scene
                            SceneQueue.Add(gameObject);
                            continue;
                        }

                        // Destroy GameObject
                        Object.Destroy(gameObject);
                    }
                    
                    Debug.Log($"Scene '{scene.Name}' closed");
                    ActiveScene = null;
                }
                catch (Exception ex)
                {
                    Exceptions.Throw(ex);
                }
            }
            else
            {
                throw new Exception($"Failed to close invalid scene");
            }
        }
        
        internal static void AddObject(GameObject gameObject)
        {
            if (!Object.IsDestroyed(gameObject))
            {
                if (ActiveScene != null)
                {
                    SceneQueue.Remove(gameObject);
                    
                    Debug.Log($"GameObject '{gameObject.Name}' added to Scene '{ActiveScene.Name}' root objects");
                    ActiveScene.RootGameObjects.Add(gameObject);
                    gameObject.Scene = ActiveScene;
                    return;
                }
                
                SceneQueue.Add(gameObject);
            }
        }
        
        internal static void RemoveObject(GameObject gameObject)
        {
            if (ActiveScene != null)
            {
                Debug.Log($"GameObject '{gameObject.Name}' removed from Scene '{ActiveScene.Name}' root objects");
                ActiveScene.RootGameObjects.Remove(gameObject);
                SceneQueue.Remove(gameObject);
            }
        }
    }
}