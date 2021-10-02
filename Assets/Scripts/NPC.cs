using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    public bool Interacted(GameObject obj)
    {
        Debug.Log("NPC has been interacted with");
        
        return true;
    }
}
