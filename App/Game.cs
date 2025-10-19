using Hybrid;

namespace App
{
    public class Game : GameBehaviour
    {
        public override void Init()
        {
            Console.WriteLine("Platform: " + Platform.Current.SystemPlatform);
        }

        public override void Update()
        {
            
        }

        public override void Draw()
        {
            
        }
    }
}