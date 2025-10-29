using System;

namespace Hybrid
{
    public class Config
    {
        public virtual Scene Scene { get; set; }
        
        public virtual string Icon { get; set; }
        public virtual string Title { get; set; }
        
        public virtual bool Fullscreen { get; set; }
        public virtual bool Resizable { get; set; }
        public virtual bool VSync { get; set; }
        
        public virtual int Height { get; set; }
        public virtual int Width { get; set; }
        public virtual int Fps { get; set; }
        
        
        protected Config()
        {
            
        }
    }
}