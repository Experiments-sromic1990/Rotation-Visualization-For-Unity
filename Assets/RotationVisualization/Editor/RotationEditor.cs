using UnityEditor;
using UnityEngine;

namespace RotationVisualization.Editor
{
    [CustomEditor(typeof(Rotation))]
    [CanEditMultipleObjects]
    public class RotationEditor : UnityEditor.Editor
    {
        private void OnEnable()
        {
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            Rotation script = (Rotation)target;

            if (GUILayout.Button("Rotate X"))
            {
                script.RotateAroundX();   
            }
            
            if (GUILayout.Button("Rotate Y"))
            {
                script.RotateAroundY();
            }
            
            if (GUILayout.Button("Rotate Z"))
            {
                script.RotateAroundZ();
            }
            
            if (GUILayout.Button("Rotate X with Q"))
            {
                script.RotateAroundXByQ();
            }
            
            if (GUILayout.Button("Rotate Y with Q"))
            {
                script.RotateAroundYByQ();
            }
            
            if (GUILayout.Button("Rotate Z with Q"))
            {
                script.RotateAroundZByQ();
            }
            
            if (GUILayout.Button("Reset"))
            {
                script.ResetRotation();
            }

        }
    }
}