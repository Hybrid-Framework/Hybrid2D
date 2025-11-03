namespace Hybrid
{
    // Component
    public class Component : Object
    {
        public Entity Entity { get; internal set; }
        public Transform Transform { get; internal set; }

        internal override void Process()
        {
            Console.WriteLine($"Updating {Name} in {Entity.Name}");
        }
    }
}