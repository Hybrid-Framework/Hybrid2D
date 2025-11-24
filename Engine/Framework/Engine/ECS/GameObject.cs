using System;

namespace Hybrid
{
    public class GameObject : Behaviour
    {
        public Scene Scene { get; private set; }
        
        public GameObject(string name = null)
        {
            Name = name ?? Name;
            
            Scene = Scenes.GetActiveScene();
            Scene?.Add(this);
        }

        internal override void OnDestroy()
        {
            Scene?.Remove(this);
        }
    }
}