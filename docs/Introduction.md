# Getting Started

Before you can start developing with Hybrid, there are a few things you need to set up.

---

## Development Environment

First, download and install your preferred IDE:

* [Visual Studio Code](https://code.visualstudio.com/download) – lightweight and cross-platform  
* [Visual Studio](https://visualstudio.microsoft.com/downloads) – full-featured Windows IDE  
* [Rider](https://www.jetbrains.com/rider/download) – cross-platform IDE by JetBrains  

> Tip: If you're wanting to work on multiple platforms we recommend using Rider!

---

## Installing .NET 10

Hybrid currently requires **.NET 10** only however support for earlier version may be available soon:

- Download the latest version from the official [.NET website](https://dotnet.microsoft.com/en-us/download).  
- Use the command below to check which workloads you may need:

```bash
dotnet workload search
dotnet workload install packagename
```

> Tip: If you’re unsure which workloads to install, it’s safe to install all recommended workloads.

---

## Creating A New Project

* Create a **new console application**.
* Add the required NuGet packages for Hybrid2D.
> Tip: If you want a premade **cross-platform template**, it’s available [here](#).

---

## How It Works

Simply **inherit from the `Hybrid.App` class** and override the three methods:

### OnInitialize 
- All initialize code goes here.

### OnUpdate
- All update code goes here.

### OnRender
- All rendering code goes here.

---

## Example

```csharp
using Hybrid;

namespace Application
{
    public class Game : Hybrid.App
    {
        public override void OnInitialize()
        {
            // Initialize code
            Window.SetTitle("My First Game");
        }

        public override void OnUpdate()
        {
            // Update code
            if(Input.GetKeyboardButtonDown(KeyboardButton.Space))
            {
                Debug.Log("You pressed space!");
            }
        }

        public override void OnRender()
        {
            // Render code
            Graphics.DrawBegin(Color.Black);
            Graphics.DrawFps(10, 10, Color.White);
            Graphics.DrawEnd();
        }
    }
}
```

---

## Documentation

For more detailed usage, check out the [documentation](https://hybrid2d.github.io/Hybrid/Documentation/) for quick reference.
