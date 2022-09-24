using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using CodeMonkey.Utils;

public class DrawMeshScript : MonoBehaviour
{
    private Mesh mesh;
    private Vector3 lastMousePosition;

    [SerializeField] private Transform debugVisual1;
    [SerializeField] private Transform debugVisual2;

    private void Awake()
    {

    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)) // Mouse's Left button pressed
        {
            // Creating a quad (A mesh is made by vertices, uv's and triangles)
            mesh = new Mesh(); 

            Vector3[] vertices = new Vector3[4];
            Vector2[] uv = new Vector2[4];
            int[] triangles = new int[6];
            
            vertices[0] = /*UtilsClass.*/GetMouseWorldPosition();
            vertices[1] = /*UtilsClass.*/GetMouseWorldPosition();
            vertices[2] = /*UtilsClass.*/GetMouseWorldPosition();
            vertices[3] = /*UtilsClass.*/GetMouseWorldPosition();

            // Adding a solid color
            uv[0]= Vector2.zero; 
            uv[1]= Vector2.zero;
            uv[2]= Vector2.zero;
            uv[3]= Vector2.zero;
            // First triangle
            triangles[0] = 0; 
            triangles[1] = 3;
            triangles[2] = 1;
            // Second triangle
            triangles[3] = 1; 
            triangles[4] = 3;
            triangles[5] = 2;

            // Adding data to the mesh
            mesh.vertices = vertices;
            mesh.uv = uv;
            mesh.triangles = triangles; 
            mesh.MarkDynamic(); // Make the mesh more performant for real-time modifications
            GetComponent<MeshFilter>().mesh = mesh; // To visuallize the mesh
            lastMousePosition = /*UtilClass.*/GetMouseWorldPosition();
        }

        if(Input.GetMouseButton(0)) //Mouse's Left button held
        {
            float minDistance = .1f;
            if(Vector3.Distance(/*UtilsClass.*/GetMouseWorldPosition(), lastMousePosition) > minDistance)
            {
                // Recreate the array for drawing the mesh
                Vector3[] vertices = new Vector3[mesh.vertices.Length + 2];
                Vector2[] uv = new Vector2[mesh.uv.Length + 2];
                int[] triangles = new int[mesh.triangles.Length + 6];
                
                //Instantiate the mesh drawing
                mesh.vertices.CopyTo(vertices, 0);
                mesh.uv.CopyTo(uv, 0);
                mesh.triangles.CopyTo(triangles, 0);
                
                //Calculate Vertex Indexes
                int vIndex = vertices.Length-4;
                int vIndex0 = vIndex + 0; // Two previous vertices
                int vIndex1 = vIndex + 1;
                int vIndex2 = vIndex + 2; // Two new vertices
                int vIndex3 = vIndex + 3;

                // Stores the last mouse positioning to calculate the vector
                Vector3 mouseForwardVector = /*UtilClass.*/GetMouseWorldPosition() - lastMousePosition.normalized;            
                // Apply 90º into the vector
                Vector3 normal2D = new Vector3(0, 0, -1f);
                float lineThickness = 1f;
                Vector3 newVertexUp = /*UtilClass.*/GetMouseWorldPosition() + Vector3.Cross(mouseForwardVector, normal2D) * lineThickness; // Upward triangle
                Vector3 newVertexDown = /*UtilClass.*/GetMouseWorldPosition() + Vector3.Cross(mouseForwardVector, normal2D * -1f) * lineThickness; // Downward triangle

                /*debugVisual1.position = newVertexUp;
                debugVisual2.position = newVertexDown; */ //Just for testing

                // Connect the vertex to the previous quad

                //update the vertices
                vertices[vIndex2] = newVertexUp;
                vertices[vIndex3] = newVertexDown;
                //update the uv's
                uv[vIndex2] = Vector2.zero;
                uv[vIndex3] = Vector2.zero;
                //update the triangles
                int tIndex = triangles.Length - 6;
                triangles[tIndex + 0] = vIndex0;
                triangles[tIndex + 1] = vIndex2;
                triangles[tIndex + 2] = vIndex1;

                triangles[tIndex + 3] = vIndex1;
                triangles[tIndex + 4] = vIndex2;
                triangles[tIndex + 5] = vIndex3;

                //Update the mesh with these values
                mesh.vertices = vertices;
                mesh.uv = uv;
                mesh.triangles = triangles;

                //Update the Last Mouse Position
                lastMousePosition = /*UtilsClass.*/GetMouseWorldPosition();
            }
        }
        // ?? transform.position = UtilsClass.GetMouseWorldPosition(); // Updates the mesh to the mouse positioning;
    }

    private Vector3 GetMouseWorldPosition()
    {
        throw new NotImplementedException();
    }
}
