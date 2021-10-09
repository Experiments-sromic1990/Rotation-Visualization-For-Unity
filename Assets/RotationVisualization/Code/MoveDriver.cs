using UnityEngine;

namespace RotationVisualization
{
    public class MoveDriver : MonoBehaviour
    {
        public float speed = 10.0f;
        public float rotationSpeed = 100.0f;
        
        private void Update()
        {
            float translation = Input.GetAxis("Vertical") * speed;
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;
            
            transform.Translate(0, 0, translation);
            transform.Rotate(0, rotation, 0);
        }
    }   
}
