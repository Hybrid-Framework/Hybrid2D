# Sample.Test.2

<iframe src=/Samples/sample.test.2/wwwroot/index.html width=610 height=410></iframe>


```csharp
﻿using Hybrid;

public class Game : App
{
    public override void OnInitialize()
    {
        
    }

    public override void OnUpdate()
    {
        
    }

    public override void OnRender()
    {
        Graphics.DrawBegin(Color.White);
        Graphics.DrawFps(10, 10, Color.Black);
        Graphics.DrawEnd();
    }
}
```

