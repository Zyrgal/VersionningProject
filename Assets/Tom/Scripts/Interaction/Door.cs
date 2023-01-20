using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Sprite m_openDoorSprite;

    public void Open()
    {
        GetComponent<SpriteRenderer>().sprite = m_openDoorSprite;
        GetComponent<Collider2D>().enabled = false;
    }
}
