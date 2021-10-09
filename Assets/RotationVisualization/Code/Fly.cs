using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RotationVisualization
{
    public class Fly : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        private void RotateAroundX(float angle)
        {
            transform.Rotate(transform.right, angle, Space.World);
        }
        
        private void RotateAroundY(float angle)
        {
            transform.Rotate(transform.up, angle, Space.World);
        }
        
        private void RotateAroundZ(float angle)
        {
            transform.Rotate(transform.forward, angle, Space.World);
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow))
            {
                RotateAroundZ(1);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow))
            {
                RotateAroundZ(-1);
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                RotateAroundX(1);
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                RotateAroundX(-1);
            }

            if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.Delete))
            {
                RotateAroundY(-1);
            }
            
            if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.PageDown))
            {
                RotateAroundY(1);
            }
        }
    }   
}
