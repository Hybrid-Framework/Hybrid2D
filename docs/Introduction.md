# Getting Started

Before you can start developing with Hybrid, there are a few things you need to set up.

---

## Development Environment

First, download and install your preferred IDE:

* [Visual Studio Code](https://code.visualstudio.com/download) – lightweight and cross-platform  
* [Visual Studio](https://visualstudio.microsoft.com/downloads) – full-featured Windows IDE  
* [Rider](https://www.jetbrains.com/rider/download) – cross-platform IDE by JetBrains  

---

## Installing .NET

Hybrid requires **.NET 8 or above**.  

- Download the latest version from the official [.NET website](https://dotnet.microsoft.com/en-us/download).  
- Use the command below to check which workloads you may need:

```bash
dotnet workload search
dotnet workload install packagename
```

> Tip: If you’re unsure which workloads to install, it’s safe to install all recommended workloads.

---

## Creating A New Project

1. Create a **new console application**.  
2. Add the required NuGet packages for Hybrid2D.  
3. (Optional) If you want a **cross-platform template**, it’s available [here](#).  

---

## How It Works

Hybrid handles the **game loop** for you. Each platform has its own implementation of the main loop, which can get complex. We abstracts this so you can focus on your game logic.  

To use Hybrid, **inherit from the `App` class** and override three methods:

### OnInitialize
- Called once at the **start** of the application.  
- Load your resources, set up your window, and perform any initialization here.

### OnUpdate
- Called once **per frame `OnInitialize`**.
- Implement input handling, game logic, and updates here.

### OnRender
- Called once **per frame after `OnUpdate`**.  
- All rendering code goes here.

---

## Example Game

```csharp
using Hybrid;

namespace MyGame
{
    public class Game : App
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

## Next Steps

For more detailed usage, check out the [cheatsheet](Cheatsheet.md) to explore!
