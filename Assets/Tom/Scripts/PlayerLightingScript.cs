using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerLightingScript : MonoBehaviour
{
    [SerializeField] Vector3 m_offset = Vector3.zero;
    [SerializeField] int m_rayCount = 200;
    [SerializeField] float m_size = 1f;
    [SerializeField] private LayerMask m_blocksLightMask;

    public bool LightIsActive
    {
        get
        {
            return _lightIsActive;
        }
    }

    bool _lightIsActive = true;

    private Mesh _mesh;

    void Start()
    {
        _mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = _mesh;
    }

    private void Update()
    {

        if (_lightIsActive)
        {
            float angle = 0f;
            float angleIncrease = 360f / m_rayCount;

            Vector3[] verticices = new Vector3[m_rayCount + 2];
            Vector2[] uv = new Vector2[verticices.Length];
            int[] triangles = new int[m_rayCount * 3];

            verticices[0] = m_offset;

            int vertexIndex = 1;
            int triangleIndex = 0;
            for (int i = 0; i <= m_rayCount; i++)
            {
                float angleRad = angle * (Mathf.PI / 180f);
                Vector3 angleVector = new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
                Vector3 vertex;
                RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position + m_offset, angleVector, m_size, m_blocksLightMask);
                if (raycastHit2D.collider == null)
                {
                    vertex = m_offset + angleVector * m_size;
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

            _mesh.vertices = verticices;
            _mesh.uv = uv;
            _mesh.triangles = triangles;
        }

        if (MenuManager.instance.isPause)
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            _lightIsActive = !_lightIsActive;
            GetComponent<MeshRenderer>().enabled = _lightIsActive;
        }
    }
}
