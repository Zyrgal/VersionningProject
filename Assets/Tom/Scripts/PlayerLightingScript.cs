using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerLightingScript : MonoBehaviour
{
    [SerializeField] Vector3 offset = Vector3.zero;
    [SerializeField] int rayCount = 200;
    [SerializeField] float size = 10f;
    [SerializeField] private LayerMask blocksLightMask;

    private Mesh mesh;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    private void Update()
    {      
        float angle = 0f;
        float angleIncrease = 360f / rayCount;

        Vector3[] verticices = new Vector3[rayCount + 2];
        Vector2[] uv = new Vector2[verticices.Length];
        int[] triangles = new int[rayCount * 3];

        verticices[0] = offset;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            float angleRad = angle * (Mathf.PI / 180f);
            Vector3 angleVector = new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position + offset, angleVector, size, blocksLightMask);
            if (raycastHit2D.collider == null)
            {
                vertex = offset + angleVector * size;
            }
            else
            {
                vertex = raycastHit2D.point - (Vector2)transform.position;
            }
            verticices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }

        mesh.vertices = verticices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

}
