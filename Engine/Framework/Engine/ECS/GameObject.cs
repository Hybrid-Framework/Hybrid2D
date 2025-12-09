using System;

namespace Hybrid
{
    public partial class GameObject : Behaviour
    {
        internal List<Component> Components { get; set; } = new List<Component>();
        private Scene Scene { get; set; }
        public string Layer { get; set; }
        public string Tag { get; set; }
        

        // Dispose
        internal override void OnDispose()
        {
            if (!IsDestroyed())
            {
                // Destroy All Children Of This GameObject
                foreach (var child in Transform.GetChildrenRecursive(true))
                {
                    Object.Destroy(child.GameObject);
                }
                
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
        // Constructor
        public GameObject(string name = null)
        {
            // Assign
            GameObject = this;
            Name = name ?? Name;

            // Create Transform
            Transform = AddComponentInternal(new Transform
            {
                GameObject = this,
                Name = Name
            });
            
            // Add To Scene
            Scene = Scenes.GetActiveScene();
            Scene.AddObject(this);
            
            // Activate
            Enabled = true;
        }

        public Scene GetScene()
        {
            return Scene;
        }
    }
}