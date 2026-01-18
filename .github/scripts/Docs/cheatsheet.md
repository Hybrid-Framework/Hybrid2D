# Cheatsheet
This cheatsheet is designed for quick reference.

---
### Audio.cs
```csharp
        void SetAudioVolume(float volume) // Set master audio volume
        float GetAudioVolume() // Get master audio volume
        void SetAudioPitch(float pitch) // Set master audio pitch
        float GetAudioPitch() // Get master audio pitch
        void PauseAudio() // Pause master audio
        void ResumeAudio() // Resume master audio
        void StopAudio() // Stop master audio
        void StopAudio(long ms) // Stop master audio with fade in ms
```

---
### Music.cs
```csharp
        Music CreateMusic(string path) // Create new music instance
        void DestroyMusic(Music music) // Destroy existing music instance
        void SetPlaybackPosition(Music music, long ms) // Set music playback position
        long GetPlaybackPosition(Music music) // Get music playback position
        long GetRemaining(Music music) // Get music remaining time in ms 
        long GetDuration(Music music) // Get music duration time in ms
        void SetVolume(Music music, float volume) // Set music volume
        float GetVolume(Music music) // Get music volume
        void SetPitch(Music music, float pitch) // Set music pitch
        float GetPitch(Music music) // Get music pitch
        void SetPan(Music music, float pan) // Set music pan position (0 left, 0.5 center, 1 right)
        float GetPan(Music music) // Get music pan position
        void Play(Music music) // Play music
        void Pause(Music music) // Pause music
        void Resume(Music music) // Resume music
        void Stop(Music music) // Stop music
        void Stop(Music music, long ms) // Stop music with fade in ms
        void SetLoop(Music music, bool loop) // Set music looping
        bool GetLoop(Music music) // Get music looping
        bool IsPlaying(Music music) // Is music playing
```

---
### Sound.cs
```csharp
        Sound CreateSound(string path) // Create new sound instance
        void DestroySound(Sound sound) // Destroy existing sound instance
        void SetPlaybackPosition(Sound sound, long ms) // Set sound playback position
        long GetPlaybackPosition(Sound sound) // Get sound playback position
        long GetRemaining(Sound sound) // Get sound remaining time in ms 
        long GetDuration(Sound sound) // Get sound duration time in ms
        void SetVolume(Sound sound, float volume) // Set sound volume
        float GetVolume(Sound sound) // Get sound volume
        void SetPitch(Sound sound, float pitch) // Set sound pitch
        float GetPitch(Sound sound) // Get sound pitch
        void SetPan(Sound sound, float pan) // Set sound pan position (0 left, 0.5 center, 1 right)
        float GetPan(Sound sound) // Get sound pan position
        void Play(Sound sound) // Play sound
        void Pause(Sound sound) // Pause sound
        void Resume(Sound sound) // Resume sound
        void Stop(Sound sound) // Stop sound
        void Stop(Sound sound, long ms) // Stop sound with fade in ms
        void SetLoop(Sound sound, bool loop) // Set sound looping
        bool GetLoop(Sound sound) // Get sound looping
        bool IsPlaying(Sound sound) // Is sound playing
```

---
### Wave.cs
```csharp
        Wave CreateWave(int hz, float amplitude, long ms) // Create new sine wave instance
        void DestroyWave(Wave wave) // Destroy existing sine wave instance
        void SetPlaybackPosition(Wave wave, long ms) // Set sine wave playback position
        long GetPlaybackPosition(Wave wave) // Get sine wave playback position
        long GetRemaining(Wave wave) // Get sine wave remaining time in ms
        long GetDuration(Wave wave) // Get sine wave duration time in ms
        void SetVolume(Wave wave, float volume) // Set sine wave volume
        float GetVolume(Wave wave) // Get sine wave volume
        void SetPitch(Wave wave, float pitch) // Set sine wave pitch
        float GetPitch(Wave wave) // Get sine wave pitch
        void SetPan(Wave wave, float pan) // Set sine wave pan position (0 left, 0.5 center, 1 right)
        float GetPan(Wave wave) // Get sine wave pan position
        void Play(Wave wave) // Play sine wave
        void Pause(Wave wave) // Pause sine wave
        void Resume(Wave wave) // Resume sine wave
        void Stop(Wave wave) // Stop sine wave
        void Stop(Wave wave, long ms) // Stop sine wave with fade in ms
        void SetLoop(Wave wave, bool loop) // Set sine wave looping
        bool GetLoop(Wave wave) // Get sine wave looping
        bool IsPlaying(Wave wave) // Is sine wave playing
```

---
### Font.cs
```csharp
        Font CreateFont(string fontPath) // Create new font instance
        void DestroyFont(Font font) // Destroy existing font instance
        void SetFontSpacing(Font font, int spacing) // Set font character spacing
        int GetFontSpacing(Font font) // Get font character spacing
        int GetFontAscent(Font font) // Get font ascent
        int GetFontDescent(Font font) // Get font descent
        int GetFontHeight(Font font) // Get font height
        Point GetTextSize(Font font, string text, float size) // Measure text size using font and size
        float GetTextWidth(Font font, string text, float size) // Measure text width using font and size
        float GetTextHeight(Font font, string text, float size) // Measure text height using font and size
```

---
### Graphics.cs
```csharp
        void DrawRect(Rectangle rectangle, Color color) // Draw single rectangle with color
        void DrawRects(Rectangle[] rects, Color[] colors) // Draw multiple rectangles with colors
        void DrawLine(Line line, Color color) // Draw single line with color
        void DrawLines(Line[] lines, Color[] colors) // Draw multiple lines with colors
        void DrawPoint(Point point, Color color) // Draw single pixel with color
        void DrawPoints(Point[] points, Color[] colors) // Draw multiple pixels with colors
        void DrawCircle(Circle circle, Color color) // Draw single circle with color
        void DrawCircles(Circle[] circles, Color[] colors) // Draw multiple circles with colors
        void DrawEllipse(Ellipse ellipse, Color color) // Draw single ellipse with color
        void DrawEllipses(Ellipse[] ellipses, Color[] colors) // Draw multiple ellipses with colors
        void DrawTriangle(Triangle triangle, Color color) // Draw single triangle with color
        void DrawTriangles(Triangle[] triangles, Color[] colors) // Draw multiple triangles with colors
        void DrawGeometry(Texture texture, float[] positions, Color[] colors, float[] uvs, int[] indices) // Draw custom geometry with texture
        void DrawGeometry(float[] positions, Color[] colors, int[] indices) // Draw custom geometry without texture
        void DrawTexture(Texture texture, Rectangle? uv, Rectangle? position) // Draw section of texture at position
        void DrawTexture(Texture texture, Rectangle? position) // Draw full texture at position
        void DrawBegin(Color color) // Draw begin (draw after this call)
        void DrawEnd() // Draw end (stop drawing after this call)
        void DrawText(Font font, string text, int x, int y, float size, Color color) // Draw text with a font, position, size and color
        void DrawFps(int x, int y, Color color) // Draw the frame rate
```

---
### Texture.cs
```csharp
        Texture CreateTexture(string path) // Create new texture instance
        void DestroyTexture(Texture texture) // Destroy existing font instance
        void SetPixel(Texture texture, int x, int y, Color color) // Set texture pixel color
        Color GetPixel(Texture texture, int x, int y) // Get texture pixel color
        void SetPixels(Texture texture, Color[] pixels) // Set all texture pixel colors
        Color[] GetPixels(Texture texture) // Get all texture pixel colors
        void Apply(Texture texture, Rectangle? rect = null) // Update all texture pixels
        string GetFormat(Texture texture) // Get texture format (Ex: RGBA32)
        Point GetSize(Texture texture) // Get texture size
        int GetWidth(Texture texture) // Get texture width
        int GetHeight(Texture texture) // Get texture height
```

---
### Gamepad.cs
```csharp
        void Rumble(int index, float strength, float ms) // Rumble gamepad for ms
        bool GetButton(int index, Button button) // Get gamepad button pressed
        bool GetButtonUp(int index, Button button) // Get gamepad button released
        bool GetButtonDown(int index, Button button) // Get gamepad button down (single frame)
        float GetAxis(int index, Axis axis) // Get gamepad axis
        void SetDeadZone(int index, float deadZone) // Set gamepad dead zone
        float GetDeadZone(int index) // Get gamepad dead zone
```

---
### Keyboard.cs
```csharp
        bool GetButton(Key button) // Get keyboard button pressed
        bool GetButtonUp(Key button) // Get keyboard button released
        bool GetButtonDown(Key button) // Get keyboard button down (single frame)
```

---
### Mouse.cs
```csharp
        bool GetButton(int index) // Get mouse button pressed
        bool GetButtonUp(int index) // Get mouse button released
        bool GetButtonDown(int index) // Get mouse button down (single frame)
        Point GetPositonDelta() // Get mouse positon delta
        Point GetScrollDelta() // Get mouse scroll delta
        Point GetPositon() // Get mouse positon
        void Show() // Show mouse
        void Hide() // Hide mouse
```

---
### Touch.cs
```csharp
        bool GetTouch(int index) // Get touch pressed
        bool GetTouchUp(int index) // Get touch released
        bool GetTouchDown(int index) // Get touch down (single frame)
        Point GetTouchPositionDelta(int index) // Get touch position delta
        Point GetTouchPosition(int index) // Get touch position
        float GetTouchPressure(int index) // Get touch pressure
        int GetTouchCount() // Get touch count
```

---
### TouchKeyboard.cs
```csharp
        void Open() // Open screen keyboard
        void Close() // Close screen keyboard
        bool Visible() // Is screen keyboard visible
        bool Supported() // Is screen keyboard supported
        void Clear() // Clear screen keyboard text
        string Text() // Get screen keyboard text
```

---
### FileSystem.cs
```csharp
        string GetCurrentDirectory() // Get current directory
        bool SetCurrentDirectory(string path) // Set current directory
        string GetBaseDirectory() // Get base directory
        bool FileExists(string path) // Does file exist at path
        bool FileWrite(string path, byte[] bytes) // Write bytes to a file
        byte[] FileRead(string path) // Read bytes from a file
        bool FileCreate(string path) // Create file
        bool FileDelete(string path) // Delete file
        bool FileCopy(string source, string destination, bool overwrite = false) // Copy file
        bool FileMove(string source, string destination, bool overwrite = false) // Move file
        bool FolderExists(string path) // Does folder exist
        bool FolderCreate(string path) // Create folder
        bool FolderDelete(string path) // Delete folder (empty folders only)
        string[] GetFiles(string path) // Get all file paths in directory
```

---
### Device.cs
```csharp
        string GetPlatform() // Get the current platform (Ex: Windows, Android, etc)
        string GetOSVersion() // Get operating system version
        int GetProcessorCount() // Get processor count
        bool GetProcessor64Bit() // Is the processor 64 bit
        string GetDate() // Get full date
        string GetTime() // Get full time
        int GetMonth() // Get month
        int GetYear() // Get year
        int GetDay() // Get day
```

---
### Debug.cs
```csharp
        void Log(object message, bool trace = false) // Log a message
        void Warning(object message, bool trace = false) // Log a warning
        void Error(object message, bool trace = false) // Log an error
        void Assert(bool condition, object message) // Throw exception if condition is false
        void Exception(object message) // Throw exception
```

---
### Maths.cs
```csharp
        float Pi() // PI value
        float TwoPi() // 2 PI value
        float HalfPi() // Half of PI value
        float Deg2Rad() // Degrees to radians value
        float Rad2Deg() // Radians to degrees value
        float Sin(float radians) // Sine of angle in radians
        float Cos(float radians) // Cosine of angle in radians
        float Tan(float radians) // Tangent of angle in radians
        float Asin(float value) // Arcsine (inverse sine) of value
        float Acos(float value) // Arccosine (inverse cosine) of value
        float Atan(float value) // Arctangent (inverse tangent) of value
        float Atan2(float y, float x) // Arctangent of y/x considering quadrant
        float Sqrt(float value) // Square root
        float Abs(float value) // Absolute value
        float Floor(float value) // Round down to nearest integer (float)
        int FloorToInt(float value) // Round down to nearest integer (int)
        float Ceil(float value) // Round up to nearest integer (float)
        int CeilToInt(float value) // Round up to nearest integer (int)
        float Round(float value) // Round to nearest integer (float)
        int RoundToInt(float value) // Round to nearest integer (int)
        float Min(float a, float b) // Return smaller of a and b
        float Max(float a, float b) // Return larger of a and b
        float Clamp01(float value) // Clamp value between 0 and 1
        float Clamp(float value, float min, float max) // Clamp value between min and max
        float Sign(float value) // Sign of value
        float Pow(float x, float y) // Raise x to power y
        float Exp(float x) // Exponential of x
        float Log(float x) // Natural logarithm (ln)
        float Log10(float x) // Base-10 logarithm
        bool IsPowerOfTwo(int value) // Is value is a power of 2
        float Repeat(float t, float length) // Loop value t between 0 and length
        float PingPong(float t, float min, float max) // Oscillates t between min and max
        float DegreesToRadians(float degrees) // Convert degrees to radians
        float RadiansToDegrees(float radians) // Convert radians to degrees
        float Lerp(float a, float b, float t) // Linear interpolation (clamped 0-1)
        float LerpUnclamped(float a, float b, float t) // Linear interpolation without clamping
        bool Approximately(float a, float b, float epsilon = 1e-5f) // Is a & b approximately the same using epsilon range
```

---
### Time.cs
```csharp
        int GetFrameCount() // Get frame count
        float GetFrameTime() // Get frame time in ms
        float GetDeltaTime() // Get delta time
        float GetTime() // Get time since startup
        void SetFps(int fps) // Set target frame rate
        float GetFps() // Get target frame rate
```

---
### Window.cs
```csharp
        void SetIcon(string path) // Set window icon
        void SetTitle(string title) // Set window title
        string GetTitle() // Get window fullscreen
        void SetFullscreen(bool fullscreen) // Set window fullscreen
        bool GetFullscreen() // Get window fullscreen
        void SetResizable(bool resizable) // Set window resizable
        bool GetResizable() // Get window resizable
        void SetBorderless(bool borderless) // Set window borderless
        bool GetBorderless() // Get window borderless
        void SetMaximized(bool maximized) // Set window maximized
        bool GetMaximized() // Get window maximized
        void SetMinimized(bool minimized) // Set window minimized
        bool GetMinimized() // Get window minimized
        void SetPosition(Point position) // Set window position
        Point GetWindowPosition() // Get window position
        void SetSize(Point size) // Set window size
        Point GetSize() // Get window size
        void SetWidth(int width) // Set window width
        int GetWidth() // Get window width
        void SetHeight(int height) // Set window height
        int GetHeight() // Get window height
        void SetMaximumSize(Point size) // Set window maximum size
        Point GetMaximumSize() // Get window maximum size
        void SetMinimumSize(Point size) // Set window minimum size
        Point GetMinimumSize() // Get window minimum size
        void SetAspectRatio(Point ratio) // Set window aspect ratio
        Point GetAspectRatio() // Get window aspect ratio
        void SetVSync(bool vsync) // Set window vsync
        bool GetVSync() // Get window vsync
        uint[] GetDisplays() // Get all display ids
        uint GetCurrentDisplay() // Get current display id
        string GetCurrentDisplayName() // Get current display name
        Point GetCurrentDisplaySize() // Get current display size
        string GetDisplayName(uint displayID) // Get specific display name
        Point GetDisplaySize(uint displayID) // Get specific display size
        void Show() // Show window
        void Hide() // Hide window
        void Raise() // Raise window
        void Restore() // Restore window
        void Maximize() // Maximize window
        void Minimize() // Minimize window
```

---
## Types

### Axis.cs
```csharp
Information
```

### Button.cs
```csharp
Information
```

### Circle.cs
```csharp
Information
```

### Color.cs
```csharp
Information
```

### Ellipse.cs
```csharp
Information
```

### Key.cs
```csharp
Information
```

### Line.cs
```csharp
Information
```

### Point.cs
```csharp
Information
```

### Rectangle.cs
```csharp
Information
```

### Triangle.cs
```csharp
Information
```

