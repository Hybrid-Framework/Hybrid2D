using System;

namespace Hybrid
{
    internal class SceneData
    {
        internal string SceneName;
        internal Type SceneType;
        internal int SceneIndex;

        internal SceneData(Type type, string name, int index)
        {
            this.SceneIndex = index;
            this.SceneType = type;
            this.SceneName = name;
        }
    }
}