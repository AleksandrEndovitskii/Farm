using System;

namespace GameObjects.Utils
{
    public interface IProgressive
    {
        Action<float> ProgressChanged { get; set; }
        float Progress { get; }
        bool IsReady { get; }
    }
}
