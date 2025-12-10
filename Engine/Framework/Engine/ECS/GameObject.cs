using System;

namespace Hybrid
{
    public partial class GameObject : Behaviour
    {
        internal List<Component> Components { get; set; } = new List<Component>();
        public string Layer { get; set; } = "Default";
        public string Tag { get; set; } = "Default";
        private Scene Scene { get; }
        
        
        // Constructor
        public GameObject(string name)
        {
            // Assign
            Name = name ?? Name;
            GameObject = this;
            
            // Create Transform
            Transform = AddComponentInternal(new Transform(this));
            
            // Add To Scene
            Scene = Scenes.GetActiveScene();
            Scene.AddObject(this);
            
            // Activate
            Enabled = true;
        }
        

        // Dispose
        internal override void OnDispose()
        {
            if (!IsDestroyed())
            {
                // Destroy All Components For This GameObject
                foreach (var component in GetComponents())
                {
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