using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobManager : MonoBehaviour
{

    [SerializeField]
    private Transform[] tPatrolPath;
    [SerializeField]
    private bool bLoop;
    [SerializeField]
    private float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, tPatrolPath[].position) < 1f)
        {

        }
    }

    private void PatrolSystem()
    {
        transform.position = Vector2.MoveTowards(transform.position, tPatrolPath[].position, speed * Time.deltaTime);
    }
}
