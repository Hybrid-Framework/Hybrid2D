# Getting Started

Before you can start developing with Hybrid, there are a few things you need to set up.

---

## Development IDE

First, download and install your preferred IDE:

* [Visual Studio Code](https://code.visualstudio.com/download) – Lightweight and cross-platform  
* [JetBrains Rider](https://www.jetbrains.com/rider/download) – Cross-platform IDE by JetBrains  
* [Visual Studio](https://visualstudio.microsoft.com/downloads) – Full-featured IDE

> Recommended: [JetBrains Rider](https://www.jetbrains.com/rider/download) for Windows, Mac, Linux development

---

## Installing .NET 10

Hybrid currently requires **.NET 10** only however support for earlier version may be available soon:

- Download the latest version from the official [.NET website](https://dotnet.microsoft.com/en-us/download).  
- Use the command below to check which workloads you may need:

```bash
dotnet workload search
```

> Recommended: 'dotnet workload install maui ios android wasm-tools'

---

## Create a project

* Clone the official template: git clone https://github.com/Hybrid2D/Template.git
* Open 'Template.sln' in your favourite IDE such as Rider or Visual Studio
* Develop in the 'App' project provided to you
* Build & launch your game

> This cross-platform template is designed for minimal setup

---

## How it works

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
            if(Keyboard.GetButtonDown(Key.Space))
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
