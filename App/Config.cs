using Hybrid;

namespace App
{
    public class Config : Hybrid.Config
    {
        public override Hybrid.Game Game { get; set; } = new Game();
    }
}