using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineDrawing), typeof(PolygonCollider2D))]
public class LineCollision : MonoBehaviour
{
    LineDrawing LineDrawingScript; // Reffers to the LineDrawing Script
    List<Vector2> colliderPoints = new List<Vector2>(); // Points do draw a collision shape between

    PolygonCollider2D polygonCollider;

    void Start()
    {
        LineDrawingScript = GetComponent<LineDrawing>();
        polygonCollider = GetComponent<PolygonCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        colliderPoints = CalculateColliderPoints();
        polygonCollider.SetPath(0, colliderPoints.ConvertAll(p => (Vector2)transform.InverseTransformPoint(p)));
        
    }

    private List<Vector2> CalculateColliderPoints() // Get all positions on the Line Renderer
    {
        Vector3[] positions = LineDrawingScript.GetPositions(); // Get all positions on Line Renderer
        
        // Get he width of the Line Renderer
        float width = LineDrawingScript.GetWidth();

        // m = *(y2 - y1) / (x2 - x1)
        float m = (positions[1].y - positions[0].y) / (positions[1].x - positions[0].x);
        float deltaX = (width / 2f) * (m / Mathf.Pow(m* m + 1, 0.5f));
        float deltaY = (width / 2f) * (1 / Mathf.Pow(1 + m * m, 0.5f));

        // Calculate the Offset from each point to the collision vertex
        Vector3[] offsets = new Vector3[2];
        offsets[0] = new Vector3(-deltaX, deltaY);
        offsets[1] = new Vector3(deltaX, -deltaY);

        // Generate the Colliders Vertices
        List<Vector2> colliderPositions = new List<Vector2>
         {
            positions[0] + offsets[0],
            positions[1] + offsets[0],
            positions[1] + offsets[1],
            positions[0] + offsets[1]
        };

        return colliderPositions;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        if (colliderPoints != null) colliderPoints.ForEach(p => Gizmos.DrawSphere(p, 0.1f));
    }
}
