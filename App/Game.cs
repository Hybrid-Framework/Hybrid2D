using Hybrid;

namespace App
{
    public class Game : Behaviour
    {
        public override void Init()
        {
            if(!SDL.Init(SDL.InitFlags.Everything))
            {
                throw new Exception();
            }
        }
        
        public override void Update()
        {
            
        }
        
        public override void Render()
        {
            
        }
    }
}