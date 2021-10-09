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
        
        private List<AngleViewBase> _angleViews;

        private void Awake()
        {
            _angleViews = Resources.FindObjectsOfTypeAll<AngleViewBase>().ToList();
        }
        
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(1f);
            transform.position = Rotate(rotationAngle, Axis.Y);
        }

        private Vector3 Rotate(float angle, Axis axis)
        {
            var startPosition = transform.position;
            var position = transform.position;
            Vector3 initialPos = position;
            float posX = initialPos.x * Mathf.Cos(angle * Mathf.Rad2Deg) + initialPos.z * Mathf.Sin(angle * Mathf.Rad2Deg);
            float posZ = initialPos.x * -Mathf.Sin(angle * Mathf.Rad2Deg) + initialPos.z * Mathf.Cos(angle * Mathf.Rad2Deg);

            position = new Vector3(posX, position.y, posZ);
            UpdateView(startPosition, position);
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
