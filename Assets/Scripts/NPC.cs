using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    public virtual void Interact()
    {
        Debug.Log("Interacting with Player");
    }

    public virtual void StopInteract()
    {
        Debug.Log("Stop Interacting with Player");
    }
}
