<div style="text-align:center;">

  <!-- Logo -->
  <div>
    <img width="256" src="assets/Hybrid.png" alt="Hybrid2D Logo">
  </div>
  <br>

  <!-- Title & Author -->
  <div>
    <strong>Hybrid2D</strong><br>
    Created by Lloyd J Howarth
  </div>
  <br>

  <!-- Badges -->
  <div>
    <img src="https://custom-icon-badges.demolab.com/badge/Windows-7400ff?logo=windows11&logoColor=white" alt="Windows">
    <img src="https://img.shields.io/badge/MacOS-7400ff?logo=apple&logoColor=white" alt="MacOS">
    <img src="https://img.shields.io/badge/Linux-7400ff?logo=linux&logoColor=white" alt="Linux">
    <img src="https://img.shields.io/badge/Android-7400ff?logo=android&logoColor=white" alt="Android">
    <img src="https://img.shields.io/badge/iOS-7400ff?logo=apple&logoColor=white" alt="iOS">
    <img src="https://img.shields.io/badge/Web-7400ff?logo=googlechrome&logoColor=white" alt="Web">
  </div>
  <br>

  <!-- Description -->
  <div>
    <strong>Hybrid2D</strong> is a simple, bring-your-own-tools C# framework designed for complete game development beginners. 
    It’s <strong>straightforward, cross-platform, and easy to pick up</strong> — no fancy editors, no complex setup, just write simple code and run your game.
  </div>
  <br>

  <!-- Tagline -->
  <div>
    <strong>Write once, run everywhere.</strong>
  </div>

</div>


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