using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{

    
    
    
    [HideInInspector] public Vector2 currentPosition;
    private Vector2 startPosition;
    private PlayerInput m_Input;
    private Rigidbody2D rb2d;
    public bool hasJustDied;
    
    private void Start()
    {
        m_Input = GetComponent<PlayerInput>();
        rb2d = GetComponent<Rigidbody2D>();
        
        startPosition = rb2d.position; //new Vector2(-72.57f, 48.5f)
        currentPosition = startPosition;
        hasJustDied = false;

        
    }

    private void Update()
    {
        if (m_Input.resetPlayer)
        {
            gameObject.transform.position = currentPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ResetBorder")
        {
            print("you have fallen");
            gameObject.transform.position = currentPosition;
            hasJustDied = true;
        }
        
        if (other.gameObject.tag == "CheckPoint")
        {
            print("checkpoint reached");
            currentPosition = gameObject.transform.position;
            hasJustDied = false;
        }
        
        if (other.gameObject.tag == "finish")
        {
            SceneManager.LoadScene("Level 2");
        }
        
        if (other.gameObject.tag == "finish1")
        {
            SceneManager.LoadScene("GardTestScene");
        }
        
        if (other.gameObject.tag == "finish2")
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    
    
    
    
    
    
}
    