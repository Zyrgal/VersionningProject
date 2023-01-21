using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobManager : MonoBehaviour
{
    [SerializeField]
    float m_killDistance = 1f;
    [SerializeField]
    private Transform[] tPatrolPath;
    [SerializeField]
    private bool bLoop;
    [SerializeField]
    private float speed = 3;
    private int iPathPoint;
    private bool bIncrease = true;
    private float fStartY;
    [SerializeField] List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();
    [SerializeField]
    PlayerLightingScript m_playerLightScript;

    void Start()
    {
        spriteRenderers.AddRange(GetComponentsInChildren<SpriteRenderer>());

        CheckForOrientation();

        iPathPoint = 0;
        fStartY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (MenuManager.instance.isPause)
        {
            return;
        }

        PointDistanceCheck();

        PatrolSystem();

        CheckPlayerDistance();
    }

    void CheckForOrientation()
    {
        if (transform.position.x - tPatrolPath[iPathPoint].position.x < 0)
        {
            foreach (var item in spriteRenderers)
            {
                item.flipX = true;
            }
        }
        else
        {
            foreach (var item in spriteRenderers)
            {
                item.flipX = false;
            }
        }
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
            CheckForOrientation();
        }
    }

    void CheckPlayerDistance()
    {
        if (!m_playerLightScript.LightIsActive)
        {
            return;
        }

        Vector3 playerPos = m_playerLightScript.gameObject.transform.position;
        float distance = Vector3.Distance(playerPos, transform.position);

        if (distance <= m_killDistance)
        {
            MenuManager.instance.OpenLoseMenu();
        }
    }

}
