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
    private bool bIncrease = true;
    private float fStartY;

    void Start()
    {
        iPathPoint = 0;
        fStartY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        PointDistanceCheck();

        PatrolSystem();
    }

    private void PatrolSystem()
    {
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, fStartY), new Vector2(tPatrolPath[iPathPoint].position.x, fStartY), speed * Time.deltaTime);
    }

    private void PointDistanceCheck()
    {
        if (-0.5f <= (transform.position.x - tPatrolPath[iPathPoint].position.x) && (transform.position.x - tPatrolPath[iPathPoint].position.x) <= 0.5f)
        {
            if (bLoop)
            {
                ++iPathPoint;
                Debug.Log(iPathPoint);
                if (iPathPoint >= tPatrolPath.Length)
                    iPathPoint = 0;
            }
            else
            {
                if (bIncrease)
                {
                    ++iPathPoint;
                    if (iPathPoint >= tPatrolPath.Length)
                    {
                        iPathPoint = tPatrolPath.Length - 1;
                        bIncrease = false;
                    }
                }
                else
                {
                    --iPathPoint;
                    if (iPathPoint < 0)
                    {
                        iPathPoint = 0;
                        bIncrease = true;
                    }
                }
            }

        }
    }

}
