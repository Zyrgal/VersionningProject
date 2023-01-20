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
    private int iPathPoint;
    private bool bIncrease;

    void Start()
    {
        iPathPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PointDistanceCheck();

        PatrolSystem();
    }

    private void PatrolSystem()
    {
        transform.position = Vector2.MoveTowards(transform.position, tPatrolPath[iPathPoint].position, speed * Time.deltaTime);


    }

    private void PointDistanceCheck()
    {
        if (Vector2.Distance(transform.position, tPatrolPath[iPathPoint].position) < 0.5f)
        {
            if (!bLoop)
            {
                ++iPathPoint;
                if (iPathPoint >= tPatrolPath.Length)
                    iPathPoint = 0;
            }
            else
            {
                if (bIncrease)
                {
                    ++iPathPoint;
                    if (iPathPoint >= tPatrolPath.Length)
                        bIncrease = false;
                }
                else
                {
                    --iPathPoint;
                    if (iPathPoint < 0)
                        bIncrease = true;
                }
            }

        }
    }

}
