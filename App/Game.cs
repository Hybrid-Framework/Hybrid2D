using System;
using Hybrid;
using Object = Hybrid.Object;

namespace App
{
    public class Game : Scene
    {
        private void CallOnOrientation() => Console.WriteLine("OnOrientation");
        private void CallOnFullscreen() => Console.WriteLine("OnFullscreen");
        private void CallOnMaximized() => Console.WriteLine("OnMaximized");
        private void CallOnMinimized() => Console.WriteLine("OnMinimized");
        private void CallOnResized() => Console.WriteLine("OnResized");
        private void CallOnUnfocus() => Console.WriteLine("OnUnfocus");
        private void CallOnFocus() => Console.WriteLine("OnFocus");
        private void CallOnHide() => Console.WriteLine("OnHide");
        private void CallOnShow() => Console.WriteLine("OnShow");
        private void CallOnMoved() => Console.WriteLine("OnMoved");
        private void CallOnRestore() => Console.WriteLine("OnRestore");
        private void CallOnRaise() => Console.WriteLine("OnRaise");
        private void CallOnEnter() => Console.WriteLine("OnEnter");
        private void CallOnExit() => Console.WriteLine("OnExit");
        
        public override void OnSceneOpen()
        {
            Window.OnOrientation += CallOnOrientation;
            Window.OnFullscreen += CallOnFullscreen;
            Window.OnMaximized += CallOnMaximized;
            Window.OnMinimized += CallOnMinimized;
            Window.OnResized += CallOnResized;
            Window.OnUnfocus += CallOnUnfocus;
            Window.OnFocus += CallOnFocus;
            Window.OnHide += CallOnHide;
            Window.OnShow += CallOnShow;
            Window.OnMoved += CallOnMoved;
            Window.OnRestore += CallOnRestore;
            Window.OnRaise += CallOnRaise;
            Window.OnEnter += CallOnEnter;
            Window.OnExit += CallOnExit;
        }

        public override void OnSceneClose()
        {
            
        }
    }
}