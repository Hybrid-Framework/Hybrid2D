namespace Hybrid
{
    public interface IGraphicsResource : IDisposable
    {
        public bool Disposed { get; set; }
    }
}