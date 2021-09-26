using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private IInteractable interactable;

    [SerializeField] private float rayCastDist = 10f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 10f);

            if (hit.collider != null && hit.collider.tag == "NPC")
            {
                hit.collider.GetComponent<NPC>().Interact();
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 10f);

            if (hit.collider != null && hit.collider.tag == "NPC")
            {
                hit.collider.GetComponent<NPC>().StopInteract();
            }
        }
    }
}
