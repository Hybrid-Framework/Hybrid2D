**Hybrid2D** is a simple, bring-your-own-tools C# framework designed for complete game development beginners. It’s **straightforward, cross-platform, and easy to pick up** — no fancy editors, no complex setup, just write simple code and run your game.  

**Write once, run everywhere.**

---

## Quick Example

```csharp
using Hybrid;

namespace App
{
    public class Game : Hybrid.App
    {
        public override void OnInitialize()
        {
            Window.SetTitle("My First Game");
        }

        public override void OnUpdate()
        {
            if(Input.GetKeyboardButtonDown(KeyboardButton.Space))
            {
                Debug.Log("Jump!");
            }
        }

        public override void OnRender()
        {
            Graphics.DrawBegin(Color.Black);
            
            Graphics.DrawFps(10, 10, Color.White);
            
            Graphics.DrawEnd();
        }
    }
}
```

Check out the [cheatsheet](Cheatsheet.md) to explore!