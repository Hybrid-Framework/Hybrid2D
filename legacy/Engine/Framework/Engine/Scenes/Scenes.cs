using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.Linq;
using System;

namespace Hybrid
{
    // Internal
    public sealed partial class Scenes : Module<Scenes>
    {
        private Scenes() {}
        
        internal static HashSet<Scene> AllScenes { get; private set; } = new HashSet<Scene>();
        internal static Scene DontDestroyOnLoad { get; private set; }
        internal static Scene ActiveScene { get; private set; }
        
        
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
                    // Dont Destroy On Load Scene
                    if (scene.Type == typeof(DontDestroyOnLoad))
                    {
                        DontDestroyOnLoad = scene;
                        continue;
                    }
                    
                    AllScenes.Add(scene);
                }
            }
            
            // Invalid Scenes
            if(AllScenes.Count == 0)
            {
                throw new Exception("No valid scenes found");
            }
            
            // Load Scene
            LoadScene(DontDestroyOnLoad, LoadSceneMode.Single);
            LoadScene(AllScenes.Min(s => s.Index), LoadSceneMode.Single);
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
                Close(scene);
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
        
        internal static Scene[] GetActiveScenes()
        {
            List<Scene> results = new List<Scene>() { DontDestroyOnLoad };
            
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
        
        public static void MoveGameObjectToScene(GameObject gameObject, Scene scene)
        {
            if (scene == null || !scene.IsLoaded || gameObject == null)
            {
                Debug.Warning("Can only move valid object to an active valid scene");
                return;
            }

            AddObject(gameObject, scene);
        }
        
        public static void MoveGameObjectsToScene(GameObject[] gameObjects, Scene scene)
        {
            if (scene == null || !scene.IsLoaded || gameObjects == null || gameObjects.Length == 0)
            {
                Debug.Warning("Can only move valid objects to an active valid scene");
                return;
            }

            foreach (var gameObject in gameObjects)
            {
                AddObject(gameObject, scene);
            }
        }

        public static void MergeScenes(Scene source, Scene destination)
        {
            if (source == null || !source.IsLoaded || destination == null || !destination.IsLoaded)
            {
                Debug.Warning("Can only merge scenes if both scenes are active valid scenes");
                return;
            }

            // Move All GameObjects To Destination Scene
            MoveGameObjectsToScene(source.GetRootGameObjects(), destination);
            
            // Close Source Scene
            Close(source);
        }
        
        public static void LoadScene(Scene scene, LoadSceneMode mode)
        {
            // Invalid Scene
            if (scene == null)
            {
                Debug.Warning($"Failed to load scene");
                return;
            }
            
            // Load Scene
            Load(scene, mode);
        }

        public static void LoadScene(int index, LoadSceneMode mode)
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
            Load(scene, mode);
        }

        public static void LoadScene(string name, LoadSceneMode mode)
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
            Load(scene, mode);
        }

        private static void Load(Scene scene, LoadSceneMode mode)
        {
            try
            {
                if (scene.IsLoaded)
                {
                    // Scene Already Loaded
                    Debug.Warning($"Scene '{scene.Name}' already loaded");
                    return;
                }

                if (mode == LoadSceneMode.Single)
                {
                    // For Each Active Scene
                    foreach (var active in AllScenes.ToArray())
                    {
                        if (active.IsLoaded)
                        {
                            // Close Scene
                            Close(active);
                        }
                    }
                }

                // Open Scene
                Open(scene);
            }
            catch (Exception ex)
            {
                Exceptions.Throw(ex, true);
            }
        }

        private static void Open(Scene scene)
        {
            if (scene != null)
            {
                if (scene != DontDestroyOnLoad)
                {
                    ActiveScene = scene;
                    Time.SceneWatch.Restart();
                    Debug.Log($"Scene '{scene.Name}' opened");
                }
                
                scene.IsLoaded = true;
                scene.OnSceneOpen();
            }
            else
            {
                Debug.Warning($"Failed to open invalid scene");
            }
        }

        private static void Close(Scene scene)
        {
            if (scene != null)
            {
                scene.OnSceneClose();
                scene.IsLoaded = false;
                
                // For Each GameObject In Scene
                foreach (var gameObject in scene.GetRootGameObjects())
                {
                    // Destroy Immediately
                    Object.DestroyImmediate(gameObject);
                }
                
                if (scene != DontDestroyOnLoad)
                {
                    Debug.Log($"Scene '{scene.Name}' closed");
                    ActiveScene = null;
                }
            }
            else
            {
                Debug.Warning($"Failed to close invalid scene");
            }
        }
    }
    
    // Objects
    public partial class Scenes
    {
        internal static void AddObject(GameObject gameObject, Scene scene)
        {
            RemoveObject(gameObject);
            
            if (!Object.IsDestroyed(gameObject) && scene != null)
            {
                // Debug.Log($"GameObject '{gameObject.Name}' added to Scene '{scene.Name}' root objects");
                scene.RootGameObjects.Add(gameObject);
                
                // Set Scene For All Children
                foreach (Transform child in gameObject.Transform.GetChildrenRecursive(true))
                {
                    child.GameObject.Scene = scene;
                }
            }
        }
        
        internal static void RemoveObject(GameObject gameObject)
        {
            var scene = gameObject.Scene;
            
            if (scene != null)
            {
                // Debug.Log($"GameObject '{gameObject.Name}' removed from Scene '{scene.Name}' root objects");
                scene.RootGameObjects.Remove(gameObject);
            }
            
            gameObject.Scene = null;
        }
    }
}