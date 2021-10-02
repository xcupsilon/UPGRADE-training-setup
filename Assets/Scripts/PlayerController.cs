using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool _fPressed;
    //private bool escapePressed;

    private float rayCastDistance = 100f;
    
    // Update is called once per frame

    void Update()
    {
        Debug.Log(Input.GetAxis("Interact"));
        
        if (Input.GetAxis("Interact") > 0)
        {
            _fPressed = true;
            Debug.Log("Raycasting");
        }
        else
        {
            _fPressed = false;
        }
        

        //if (Input.GetKeyDown(KeyCode.Escape)) EscapePressed = true; else EscapePressed = false;
    }

    private void FixedUpdate()
    {
        if (_fPressed)
            CheckForInteraction();
    }

    void CheckForInteraction()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right));

        if (hit.collider != null && hit.collider)
        {
            Interact(hit.collider.gameObject);
            Debug.Log("NPC Detected");
        }
        
        Input.ResetInputAxes();
    }

    void Interact(GameObject obj)
    {
        obj.GetComponent<IInteractable>()?.Interacted(this.gameObject);
    }
}
