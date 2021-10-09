using UnityEngine;

namespace RotationVisualization
{
    public class LookAt : MonoBehaviour
    {
        private float _turnSpeed = 50f;
        private float _speed = 10f;
        
        private MoveDriver _mover;
        private void Start()
        {
            _mover = FindObjectOfType<MoveDriver>();
        }
        
        private void Update()
        {
            if(_mover == null)
                return;

            Vector3 direction = _mover.transform.position - transform.position;
            Quaternion to = Quaternion.LookRotation(direction, transform.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, to, _turnSpeed * Time.deltaTime);
            if (direction.magnitude > 3)
            {
                transform.Translate(0, 0, _speed * Time.deltaTime);
            }
        }
    }   
}
