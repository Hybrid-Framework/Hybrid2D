using System;

namespace Hybrid
{
    // Config
    public class Config
    {
        public virtual Game Game { get; set; }
        
        public virtual string Icon { get; set; }
        public virtual string Title { get; set; }
        
        public virtual bool Fullscreen { get; set; }
        public virtual bool Resizable { get; set; }
        
        public virtual int Height { get; set; }
        public virtual int Width { get; set; }
    }
}