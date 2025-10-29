namespace App
{
    public class Config : Hybrid.Config
    {
        public override Hybrid.Game Game { get; set; } = new Game();

        public override string Icon { get; set; } = "Hybrid.png";
        public override string Title { get; set; } = "Hybrid";

        public override bool Fullscreen { get; set; } = false;
        public override bool Resizable { get; set; } = false;
        public override bool VSync { get; set; } = true;

        public override int Height { get; set; } = 600;
        public override int Width { get; set; } = 800;
        public override int Fps { get; set; } = 60;
    }
}