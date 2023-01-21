using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] float m_interactionRange = 0.5f;
    [SerializeField]LayerMask m_interactionMask;

    [SerializeField]PlayerLightingScript m_playerLightScript;

    Collider2D _curInteractCollider = null;

    void Update()
    {
        if (!m_playerLightScript.LightIsActive)
        {
            return;
        }

        #region Interact
        Collider2D[] interactableColliders = new Collider2D[3];
        int foundObjects = Physics2D.OverlapCircleNonAlloc (transform.position, m_interactionRange, interactableColliders, m_interactionMask);
        if (foundObjects > 0)
        {
            float shortestDistance = Mathf.Infinity;
            int shortestIndex = 0;
            for (int index = 0; index < interactableColliders.Length; index++)
            {
                if (interactableColliders[index] == null)
                {
                    break;
                }

                float distance = Vector3.Distance(transform.position, interactableColliders[index].transform.position);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    shortestIndex = index;
                }
            }

            if (_curInteractCollider != null && _curInteractCollider != interactableColliders[shortestIndex])
            {
                var curInteractable = _curInteractCollider.GetComponent<IInteractable>();
                curInteractable.Interactable(false);
            }
            _curInteractCollider = interactableColliders[shortestIndex];

            var interactable = interactableColliders[shortestIndex].GetComponent<IInteractable>();

            if (interactable != null)
            {
                interactable.Interactable(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact("Default");
                }
            }
        }
        else
        {
            if (_curInteractCollider != null)
            {
                var curInteractable = _curInteractCollider.GetComponent<IInteractable>();
                curInteractable.Interactable(false);
                _curInteractCollider = null;
            }
        }
        #endregion
    }

    private void OnDrawGizmos()
    {
        //Interaction Range
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere (transform.position, m_interactionRange);
    }
}
