using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RotationVisualization.View;
using UnityEngine;

namespace RotationVisualization
{
    public class Rotation : MonoBehaviour
    {
        [SerializeField] private float angleX = 45;
        [SerializeField] private float angleY = 45;
        [SerializeField] private float angleZ = 45;

        private Matrix4x4 _rotateX;
        private Matrix4x4 _rotateY;
        private Matrix4x4 _rotateZ;
        
        private List<AngleViewBase> _angleViews;

        private void Awake()
        {
            _angleViews = Resources.FindObjectsOfTypeAll<AngleViewBase>().ToList();
        }


        private void UpdateView(Vector3 startPosition, Vector3 position)
        {
            foreach (var angleView in _angleViews)
            {
                // angleView.OnAngleChanged?.Invoke(rotationAngle);
            }
        }
        

        public void ResetRotation()
        {
            this.transform.rotation = Quaternion.identity;
        }

        public void RotateAroundX()
        {
            float angle = Mathf.Deg2Rad * angleX;
            _rotateX = new Matrix4x4
            {
                m00 = 1,
                m01 = 0,
                m02 = 0,
                m03 = 0,
                m10 = 0,
                m11 = Mathf.Cos(angle),
                m12 = -Mathf.Sin(angle),
                m13 = 0,
                m20 = 0,
                m21 = Mathf.Sin(angle),
                m22 = Mathf.Cos(angle),
                m23 = 0,
                m30 = 0,
                m31 = 0,
                m32 = 0,
                m33 = 1
            };
            transform.forward = _rotateX.MultiplyVector(transform.forward);
        }

        public void RotateAroundY()
        {
            float angle = Mathf.Deg2Rad * angleY;
            _rotateY = new Matrix4x4
            {
                m00 = Mathf.Cos(angle),
                m01 = 0,
                m02 = Mathf.Sin(angle),
                m03 = 0,
                m10 = 0,
                m11 = 1,
                m12 = 0,
                m13 = 0,
                m20 = -Mathf.Sin(angle),
                m21 = 0,
                m22 = Mathf.Cos(angle),
                m23 = 0,
                m30 = 0,
                m31 = 0,
                m32 = 0,
                m33 = 1
            };
            transform.forward = _rotateY.MultiplyVector(transform.forward);
        }

        public void RotateAroundZ()
        {
            float angle = Mathf.Deg2Rad * angleZ;
            _rotateZ = new Matrix4x4
            {
                m00 = Mathf.Cos(angle),
                m01 = -Mathf.Sin(angle),
                m02 = 0,
                m03 = 0,
                m10 = Mathf.Sin(angle),
                m11 = Mathf.Cos(angle),
                m12 = 0,
                m13 = 0,
                m20 = 0,
                m21 = 0,
                m22 = 1,
                m23 = 0,
                m30 = 0,
                m31 = 0,
                m32 = 0,
                m33 = 1
            };
            transform.forward = _rotateZ.MultiplyVector(transform.forward);
        }
        
        public void RotateAroundXByQ()
        {
        }

        public void RotateAroundYByQ()
        {
        }

        public void RotateAroundZByQ()
        {
        }
    }
}
