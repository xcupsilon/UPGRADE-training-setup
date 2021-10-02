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

    [SerializeField] private float rayCastDistance = 3f;

    public LayerMask layerMask;
    
    void Update()
    {
        if (Input.GetAxis("Interact") > 0)
        {
            _fPressed = true;
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
