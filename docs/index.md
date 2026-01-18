<div align="center">

<img width="256" src="Hybrid.png">

**Hybrid2D**

Created by Lloyd J Howarth

![Windows](https://custom-icon-badges.demolab.com/badge/Windows-7400ff?logo=windows11&logoColor=white)
![MacOS](https://img.shields.io/badge/MacOS-7400ff?logo=apple&logoColor=white)
![Linux](https://img.shields.io/badge/Linux-7400ff?logo=linux&logoColor=white)
![Android](https://img.shields.io/badge/Android-7400ff?logo=android&logoColor=white)
![iOS](https://img.shields.io/badge/iOS-7400ff?logo=apple&logoColor=white)
![Web](https://img.shields.io/badge/Web-7400ff?logo=googlechrome&logoColor=white)


**Hybrid2D** is a simple, bring-your-own-tools C# framework designed for complete game development beginners. It’s **straightforward, cross-platform, and easy to pick up** — no fancy editors, no complex setup, just write simple code and run your game.  

**Write once, run everywhere.**

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