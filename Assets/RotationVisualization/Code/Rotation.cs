using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RotationVisualization.View;
using UnityEngine;

namespace RotationVisualization
{
    public class Rotation : MonoBehaviour
    {
        [SerializeField] private float rotationAngle = 45;
        [SerializeField] private Axis rotationAxis = Axis.Y;
        
        private List<AngleViewBase> _angleViews;

        private void Awake()
        {
            _angleViews = Resources.FindObjectsOfTypeAll<AngleViewBase>().ToList();
        }
        
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(1f);
            transform.position = Rotate(rotationAngle, rotationAxis);
        }

        private Vector3 Rotate(float angle, Axis axis)
        {
            Vector3 initialPos = transform.position;
            Vector3 position = RotateAccordingToAxis(initialPos, angle, axis);
            UpdateView(initialPos, position);
            return position;
        }

        private Vector3 RotateAccordingToAxis(Vector3 initialPos, float angle, Axis axis)
        {
            Vector3 position = initialPos;
            float posX = position.x;
            float posY = position.y;
            float posZ = position.z;
            
            switch (axis)
            {
                case Axis.X:
                    posX = initialPos.x;
                    posY = initialPos.y * Mathf.Cos(angle * Mathf.Rad2Deg) + initialPos.z * -Mathf.Sin(angle * Mathf.Rad2Deg);
                    posZ = initialPos.y * Mathf.Sin(angle * Mathf.Rad2Deg) + initialPos.z * Mathf.Cos(angle * Mathf.Rad2Deg);
                    break;
                case Axis.Y:
                    posX = initialPos.x * Mathf.Cos(angle * Mathf.Rad2Deg) + initialPos.z * Mathf.Sin(angle * Mathf.Rad2Deg);
                    posY = initialPos.y;
                    posZ = initialPos.x * -Mathf.Sin(angle * Mathf.Rad2Deg) + initialPos.z * Mathf.Cos(angle * Mathf.Rad2Deg);
                    break;
                case Axis.Z:
                    posX = initialPos.x * Mathf.Cos(angle * Mathf.Rad2Deg) + initialPos.y * -Mathf.Sin(angle * Mathf.Rad2Deg);
                    posY = initialPos.x * Mathf.Sin(angle * Mathf.Rad2Deg) + initialPos.y * Mathf.Cos(angle * Mathf.Rad2Deg);
                    posZ = initialPos.z;
                    break;
            }
            
            position = new Vector3(posX, posY, posZ);
            return position;
        }

        private void UpdateView(Vector3 startPosition, Vector3 position)
        {
            foreach (var angleView in _angleViews)
            {
                angleView.OnAngleChanged?.Invoke(rotationAngle);
            }
        }

        private void Update()
        {
        
        }
    }

    public enum Axis
    {
        X,
        Y,
        Z
    }
}
