using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool _fPressed;
    //private bool escapePressed;

    private float rayCastDistance = 3f;

    public LayerMask layerMask;
    
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, rayCastDistance, layerMask);
        Debug.DrawRay(transform.position, Vector2.right * rayCastDistance, Color.red);

        Debug.Log(hit.collider);
        
        if (hit.collider != null)
        {
            Interact(hit.collider.gameObject);
        }
        
        Input.ResetInputAxes();
    }

    void Interact(GameObject obj)
    {
        obj.GetComponent<IInteractable>()?.Interacted(this.gameObject);
    }
}
