using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    private bool canInteract;
    private PlayerInput m_Input;
    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        m_Input = GetComponent<PlayerInput>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();

        canInteract = false;
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canInteract = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) //&& m_Input.interact
        {
            print("you planted the bomb");
            this.spriteRenderer.enabled = true;
        }
    }
}
