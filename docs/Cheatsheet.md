This cheatsheet is designed for quick reference.

# Window.cs

``` text
void SetIcon(string path)               // Set the window icon
void SetTitle(string title)             // Set window title
void SetFullscreen(bool fullscreen)     // Set window fullscreen
void SetResizable(bool resizable)       // Set window resizable
void SetBorderless(bool borderless)     // Set window borderless
void SetMaximized(bool maximized)       // Set window maximized
void SetMinimized(bool minimized)       // Set window minimized
void SetPosition(Point position)        // Set window position
void SetSize(Point size)                // Set window size
void SetWidth(int width)                // Set window width
void SetHeight(int height)              // Set window height
void SetMaximumSize(Point size)         // Set window maximum size
void SetMinimumSize(Point size)         // Set window minimum size
void SetAspectRatio(Point ratio)        // Set window aspect ratio
void SetVSync(bool vsync)               // Set window vsync

string GetTitle()                       // Get window title
bool GetFullscreen()                    // Get window fullscreen
bool GetResizable()                     // Get window resizable
bool GetBorderless()                    // Get window borderless
bool GetMaximized()                     // Get window maximized
bool GetMinimized()                     // Get window minimized
Point GetWindowPosition()               // Get window position
Point GetSize()                         // Get window size
int GetWidth()                          // Get window width
int GetHeight()                         // Get window height
Point GetMaximumSize()                  // Get window maximum size
Point GetMinimumSize()                  // Get window minimum size
Point GetAspectRatio()                  // Get window aspect ratio
bool GetVSync()                         // Get window vsync

uint[] GetDisplays()                    // Get all display ids
uint GetCurrentDisplay()                // Get current display id
string GetCurrentDisplayName()          // Get current display name
Point GetCurrentDisplaySize()           // Get current display size
string GetDisplayName(uint displayID)   // Get a specific display name
Point GetDisplaySize(uint displayID)    // Get a specific display name

void Show()                             // Show window
void Hide()                             // Hide window
void Raise()                            // Raise window
void Restore()                          // Restore window
void Maximize()                         // Maximize window
void Minimize()                         // Minimize window
```


# Graphics.cs
```text
void DrawRect(Rectangle rectangle, Color color)                                                             // Draw coloured rectangle
void DrawRects(Rectangle[] rects, Color[] colors)                                                           // Draw multiple coloured rectangles
void DrawLine(Line line, Color color)                                                                       // Draw coloured line with thickness
void DrawLines(Line[] lines, Color[] colors)                                                                // Draw multiple coloured lines with thickness
void DrawPoint(Point point, Color color)                                                                    // Draw single coloured pixel
void DrawPoints(Point[] points, Color[] colors)                                                             // Draw multiple coloured pixels
void DrawCircle(Circle circle, Color color)                                                                 // Draw coloured circle
void DrawCircles(Circle[] circles, Color[] colors)                                                          // Draw multiple coloured circles
void DrawEllipse(Ellipse ellipse, Color color)                                                              // Draw coloured ellipse
void DrawEllipses(Ellipse[] ellipses, Color[] colors)                                                       // Draw multiple coloured ellipses
void DrawTriangle(Triangle triangle, Color color)                                                           // Draw coloured triangle
void DrawTriangles(Triangle[] triangles, Color[] colors)                                                    // Draw multiple coloured triangles
void DrawGeometry(float[] positions, Color[] colors, int[] indices)                                         // Draw custom geometry without a texture
void DrawGeometry(Texture texture, float[] positions, Color[] colors, float[] uvs, int[] indices)           // Draw custom geometry with a texture
void DrawTexture(Texture texture, Rectangle? position)                                                      // Draw full texture at position
void DrawTexture(Texture texture, Rectangle? uv, Rectangle? position)                                       // Draw section of a texture at position
void DrawText(Font font, string text, int x, int y, float size, Color color)                                // Draw text on the screen
void DrawFps(int x, int y, Color color)                                                                     // Draw frame rate on the screen
void DrawBegin(Color color)                                                                                 // Start drawing
void DrawEnd()                                                                                              // Stop drawing
```