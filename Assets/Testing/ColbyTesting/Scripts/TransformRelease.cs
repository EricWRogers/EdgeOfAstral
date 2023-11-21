using System.Collections.Generic;
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

        Vector3 direction = Vector3.Normalize(selectedObject.transform.position - initialPosition);

        while (CheckForOverlaps(selectedObject))
        {
            selectedObject.transform.position = Vector3.MoveTowards(selectedObject.transform.position, initialPosition, 0.0001f);

            // If the object is not moving towards the initial position anymore, don't move the object
            if (Vector3.Dot(direction, selectedObject.transform.position - initialPosition) <= 0)
            {
                break;
            }
        }
    }

    private static bool CheckForOverlaps(GameObject gameObject)
    {
        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();

        if (meshRenderer == null)
        {
            return false;
        }

        Bounds boundsToCheck = meshRenderer.bounds;

        // Loop over other objects
        foreach (Collider collider in Physics.OverlapBox(boundsToCheck.center, boundsToCheck.extents))
        {
            GameObject otherObject = collider.gameObject;

            if (otherObject != gameObject)
            {
                MeshCollider otherMeshCollider = otherObject.GetComponent<MeshCollider>() ?? otherObject.AddComponent<MeshCollider>();
                Ray ray = new(boundsToCheck.center, (otherObject.transform.position - boundsToCheck.center).normalized);
                if (RayIntersectsMesh(ray, otherMeshCollider, out _))
                {
                    return true; // Overlap detected
                }
            }
        }

        return false; // No overlap detected
    }

    private static bool RayIntersectsMesh(Ray ray, MeshCollider meshCollider, out RaycastHit hit)
    {
        hit = new RaycastHit();

        if (meshCollider == null)
        {
            return false;
        }

        Mesh mesh = meshCollider.sharedMesh;

        if (mesh == null)
        {
            return false;
        }

        int[] triangles = mesh.triangles;
        Vector3[] vertices = mesh.vertices;

        for (int i = 0; i < triangles.Length; i += 3)
        {
            Vector3 vertex0 = vertices[triangles[i]];
            Vector3 vertex1 = vertices[triangles[i + 1]];
            Vector3 vertex2 = vertices[triangles[i + 2]];

            if (RayIntersectsTriangle(ray, vertex0, vertex1, vertex2, out float distance))
            {
                if (hit.collider == null || distance < hit.distance)
                {
                    if (Physics.Raycast(ray, out RaycastHit meshHit, distance))
                    {
                        hit = meshHit;
                        return true;
                    }
                }
            }
        }

        return false;
    }

    private static bool RayIntersectsTriangle(Ray ray, Vector3 vertex0, Vector3 vertex1, Vector3 vertex2, out float distance)
    {
        distance = 0f;

        Vector3 edge1 = vertex1 - vertex0;
        Vector3 edge2 = vertex2 - vertex0;

        Vector3 h = Vector3.Cross(ray.direction, edge2);
        float a = Vector3.Dot(edge1, h);

        if (a > -float.Epsilon && a < float.Epsilon)
        {
            return false; // The ray is parallel to the triangle
        }

        float f = 1.0f / a;
        Vector3 s = ray.origin - vertex0;
        float u = f * Vector3.Dot(s, h);

        if (u < 0.0f || u > 1.0f)
        {
            return false;
        }

        Vector3 q = Vector3.Cross(s, edge1);
        float v = f * Vector3.Dot(ray.direction, q);

        if (v < 0.0f || u + v > 1.0f)
        {
            return false;
        }

        distance = f * Vector3.Dot(edge2, q);

        return distance > float.Epsilon;
    }
}