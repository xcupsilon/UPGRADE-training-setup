using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Yarn.Unity;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueRunner runner;

    public bool Interacted(GameObject obj)
    {
        Debug.Log("NPC has been interacted by " + obj.name);

        runner.StartDialogue();
        
        return true;
    }
}
