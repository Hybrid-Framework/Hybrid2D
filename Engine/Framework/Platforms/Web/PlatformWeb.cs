using System;

namespace Hybrid
{
    public class PlatformWeb : Platform
    {
        public PlatformWeb(GameBehaviour gameBehaviour)
        {
            GameBehaviour = gameBehaviour;
        }
        
        internal override void Bootstrap()
        {
            SystemPlatform = SystemPlatform.Web;
        }
    }
}