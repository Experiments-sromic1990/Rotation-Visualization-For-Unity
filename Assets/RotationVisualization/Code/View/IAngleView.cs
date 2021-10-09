using System;

namespace RotationVisualization.View
{
    public interface IAngleView
    {
        Action<float> OnAngleChanged { get; }
        void Init();
        void ShowAngle(float value);
    }
}