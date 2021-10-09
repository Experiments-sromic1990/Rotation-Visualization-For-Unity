using TMPro;
using UnityEngine;

namespace RotationVisualization.View
{
    public class AngleView : AngleViewBase
    {
        [SerializeField] private TextMeshProUGUI angleText;

        protected override void ResetView()
        {
            angleText.text = "";
        }

        public override void ShowAngle(float value)
        {
            angleText.text = $"Angle Rotation: {value}";
        }
    }
}