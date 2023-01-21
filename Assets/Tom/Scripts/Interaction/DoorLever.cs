using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLever : MonoBehaviour, IInteractable
{
    [SerializeField] Door m_linkedDoor;

    bool _doorIsOpen = false;

    public void Interact(string tag)
    {
        if (!_doorIsOpen)
        {
            m_linkedDoor.Open();
            _doorIsOpen = true;
        }
    }

    public void Interactable(bool isInteractable)
    {
       
    }
}
