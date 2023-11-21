using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Transform))]
public class PreventOverlapEditor : Editor
{
    public bool preventOverlapEnabled = false;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        preventOverlapEnabled = EditorGUILayout.Toggle("Prevent Overlap", preventOverlapEnabled);
    }
}
