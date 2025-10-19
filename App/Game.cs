using Hybrid;

namespace App
{
    public class Game : GameBehaviour
    {
        public override void Init()
        {
            Console.WriteLine("Init");
        }

        public override void Update()
        {
            Console.WriteLine("Update");
        }

        public override void Draw()
        {
            Console.WriteLine("Draw");
        }
    }
}