namespace Hybrid
{
    public interface IContentResource : IDisposable
    {
        public bool disposed { get; set; }
    }
}