using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Transform))]
public class PreventOverlapEditor : Editor
{
    public bool preventOverlapEnabled = false;
    private Vector3 previousPosition;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        preventOverlapEnabled = EditorGUILayout.Toggle("Prevent Overlap", preventOverlapEnabled);
    }

    private void OnSceneGUI()
    {
        if (preventOverlapEnabled)
        {
            GameObject selectedGameObject = Selection.activeGameObject;

            if (selectedGameObject != null)
            {
                Vector3 newPosition = Handles.PositionHandle(selectedGameObject.transform.position, Quaternion.identity);

                if (newPosition != selectedGameObject.transform.position)
                {
                    selectedGameObject.transform.position = newPosition;
                }
            }
        }
    }

    private void OnSelectionChange()
    {
        GameObject selectedGameObject = Selection.activeGameObject;

        if (selectedGameObject != null && preventOverlapEnabled)
        {
            // Check for overlap when the object is selected or deselected
            foreach (GameObject go in FindObjectsOfType<GameObject>())
            {
                if (go != selectedGameObject)
                {
                    if (IsOverlapping(selectedGameObject.transform, go.transform))
                    {
                        // Reset the position to the previous position
                        selectedGameObject.transform.position = previousPosition;
                    }
                }
            }
        }
    }

    private bool IsOverlapping(Transform transform1, Transform transform2)
    {
        // Calculate the bounds of the two GameObjects
        Bounds bounds1 = CalculateBounds(transform1);
        Bounds bounds2 = CalculateBounds(transform2);

        // Check for overlap using bounds
        return bounds1.Intersects(bounds2);
    }

    private Bounds CalculateBounds(Transform transform)
    {
        Renderer renderer = transform.GetComponent<Renderer>();

        if (renderer != null)
        {
            return renderer.bounds;
        }
        else
        {
            // If the GameObject has no renderer, use a default bounds
            return new Bounds(transform.position, Vector3.one);
        }
    }
}
