namespace Hybrid
{
    public class Object
    {
        public string Name { get; set; }

        protected Object()
        {
            Name = GetType().Name;
        }
        
        internal virtual void Dispose()
        {
            
        }
    }
}