using System;

namespace Hybrid
{
    public abstract class Scene
    {
        internal HashSet<Entity> Entities = new HashSet<Entity>();
        
        public abstract void OnOpened();
        public abstract void OnClosed();
        

        internal void Add(Entity entity)
        {
            Entities.Add(entity);
        }

        internal void Remove(Entity entity)
        {
            Entities.Remove(entity);
        }

        public Entity[] GetAllEntities()
        {
            return Entities.ToArray();
        }
        
        public override string ToString()
        {
            return GetType().Name;
        }
    }
}