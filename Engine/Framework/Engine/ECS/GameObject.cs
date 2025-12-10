using System;

namespace Hybrid
{
    public partial class GameObject : Behaviour
    {
        internal List<Component> Components { get; private set; } = new List<Component>();
        internal Scene Scene { get; private set; } = null;
        public string Layer { get; set; } = "Default";
        public string Tag { get; set; } = "Default";
        
        
        // Constructor
        public GameObject(string name = null)
        {
            // Assign
            Name = name ?? Name;
            GameObject = this;
            
            // Create Transform
            Transform = AddComponentInternal(new Transform
            {
                GameObject = this.GameObject,
                Transform = this.Transform,
                Name = this.Name
            });
            
            // Add To Scene
            Scene = Scenes.GetActiveScene();
            Scene.AddObject(this);
        }

        // Dispose
        internal override void OnDispose()
        {
            if (!IsDestroyed())
            {
                // For Each Component In GameObject
                foreach (var component in GetComponents())
                {
                    // Destroy Component
                    Object.Destroy(component);
                }
                
                // Remove From Scene
                Scene.RemoveObject(GameObject);
            }
            
            base.OnDispose();
        }
    }

    // GameObject
    public partial class GameObject
    {
        public void SetActive(bool enabled)
        {
            Enabled = enabled;
        }
        
        public Scene GetScene()
        {
            return Scene;
        }
    }
}