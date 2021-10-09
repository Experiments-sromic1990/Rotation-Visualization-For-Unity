using System;
using UnityEngine;

namespace RotationVisualization.View
{
    public abstract class AngleViewBase : MonoBehaviour, IAngleView
    {
        public Action<float> OnAngleChanged { get; private set; }

        private void Awake()
        {
            Init();
        }

        public void Init()
        {
            ResetView();
            OnAngleChanged += ShowAngle;
        }

        protected abstract void ResetView();

        public abstract void ShowAngle(float value);
    }
}