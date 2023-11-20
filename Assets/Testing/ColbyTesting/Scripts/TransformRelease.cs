using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class ObjectPositionTracker
{
    private static GameObject selectedObject;
    private static Vector3 initialPosition;

    static ObjectPositionTracker()
    {
        // Register to listen to selection events in the Unity Editor
        Selection.selectionChanged += OnSelectionChanged;
        SceneView.duringSceneGui += DuringSceneGUI;
    }

    private static void OnSelectionChanged()
    {
        // This method is called whenever the selection changes in the Unity Editor

        // Check if there is a selected GameObject
        if (Selection.activeGameObject != null)
        {
            // Access the selected GameObject
            selectedObject = Selection.activeGameObject;
        }
        else
        {
            // Clear the selected object when nothing is selected
            selectedObject = null;
        }
    }

    private static void DuringSceneGUI(SceneView sceneView)
    {
        if (selectedObject != null)
        {
            Event e = Event.current;

            if (e.type == EventType.MouseDown)
            {
                // MouseDown event indicates the start of dragging
                initialPosition = selectedObject.transform.position;
            }
            else if (e.type == EventType.MouseUp)
            {
                // MouseUp event indicates that the GameObject has been released
                HandleRelease();
            }
        }
    }

    private static void HandleRelease()
    {
        if (selectedObject == null)
            return;

        //Determines the direction the initial direction is in
        Vector3 direction = Vector3.Normalize(selectedObject.transform.position - initialPosition);

        while (CheckForOverlaps(selectedObject))
        {
            selectedObject.transform.position = Vector3.MoveTowards(selectedObject.transform.position, initialPosition, 0.0001f);
            //If the object has moved past its initial position (its direction is reversed), move it back to the start
            if (Vector3.Normalize(selectedObject.transform.position - initialPosition) == -direction)
            {
                selectedObject.transform.position = initialPosition;
                Debug.Log("GameObject still overlapping");
                return;
            }
        }
    }

    private static bool CheckForOverlaps(GameObject objToCheck)
    {
        // Check if the object has a renderer component
        Renderer renderer = objToCheck.GetComponent<Renderer>();
        //Mesh mesh = objToCheck.GetComponent<MeshFilter>();
        //  mesh goes below
        if (renderer == null)
        {
            // Skip objects without a renderer
            return false;
        }

        // Check if the object's bounds overlap with any other object's bounds
        Bounds boundsToCheck = renderer.bounds;

        foreach (var gameObject in Object.FindObjectsOfType<GameObject>())
        {
            if (gameObject != objToCheck)
            {
                // Check if the other object has a renderer component
                Renderer otherRenderer = gameObject.GetComponent<Renderer>();
                if (otherRenderer != null)
                {
                    Bounds otherBounds = otherRenderer.bounds;

                    if (boundsToCheck.Intersects(otherBounds))
                    {
                        return true; // Overlap detected
                    }
                }
            }
        }

        return false; // No overlap detected
    }
}