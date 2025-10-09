using Hybrid;

namespace App
{
    public class Game : Behaviour
    {
        private SDL.FRect rect = new SDL.FRect()
        {
            x = 0, y = 0, w = 100, h = 100
        };
        
        public override void Init()
        {
            if (!SDL.Init(SDL.InitFlags.Audio | SDL.InitFlags.Video))
            {
                Console.WriteLine("SDL Failed Initialize");
            }
            
            SDL.CreateWindowAndRenderer("Hello World", 600, 400, SDL.WindowFlags.HighPixelDensity);
            
            Console.WriteLine("KEYBOARD: " + SDL.KeyboardSupport());
            
            if (SDL.KeyboardSupport())
            {
                foreach (var id in SDL.GetKeyboardDevices())
                {
                    Console.WriteLine("Keyboard:" + SDL.GetKeyboardNameFromID(id));
                }
            }
            
            Console.WriteLine("MOUSE: " + SDL.MouseSupport());
            
            if (SDL.MouseSupport())
            {
                foreach (var id in SDL.GetMouseDevices())
                {
                    Console.WriteLine("Mouse:" + SDL.GetMouseNameFromID(id));
                }
            }
            
            Console.WriteLine("GAMEPAD: " +SDL.GamepadSupport());
            
            if (SDL.GamepadSupport())
            {
                foreach (var id in SDL.GetGamepadDevices())
                {
                    Console.WriteLine("Gamepad:" + SDL.GetGamepadNameFromID(id));
                }
            }
            
            Console.WriteLine("TOUCH: " + SDL.TouchSupport());

            if (SDL.TouchSupport())
            {
                foreach (var id in SDL.GetTouchDevices())
                {
                    Console.WriteLine("Touch:" + SDL.GetTouchDeviceNameFromID(id));
                }
            }
        }
        
        public override void Update()
        {
            
        }
        
        public override void Render()
        {
            SDL.SetRenderDrawColor(255, 128, 128, 255);
            SDL.RenderClear();
            
            SDL.SetRenderDrawColor(0, 0, 0, 255);
            SDL.RenderDebugText(10, 10, "Hello World");
            
            SDL.SetRenderDrawColor(0, 255, 0, 255);
            SDL.RenderFillRect(rect);
            
            SDL.RenderPresent();
        }
    }
}