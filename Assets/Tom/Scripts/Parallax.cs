using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Parallax : MonoBehaviour
{
    [SerializeField] Camera m_cam;
    [SerializeField] float m_parallaxEffect;

    float lenght, startpos;

    private void Start()
    {
        startpos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        float temp = m_cam.transform.position.x * (1 - m_parallaxEffect);
        float distance = m_cam.transform.position.x * m_parallaxEffect;

        transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);

        if(temp > startpos + lenght)
        {
            startpos += lenght;
        }
        else if(temp < startpos - lenght)
        {
            startpos -= lenght;
        }
    }
}
