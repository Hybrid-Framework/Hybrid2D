namespace Hybrid.Interfaces
{
    public interface IGraphicsResource : IDisposable
    {
        public bool Disposed { get; set; }
    }
}