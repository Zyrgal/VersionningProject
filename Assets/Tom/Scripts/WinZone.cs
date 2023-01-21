using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Movement>(out _) == true) 
        {
            MenuManager.instance.OpenWinMenu();
        }
    }
}
