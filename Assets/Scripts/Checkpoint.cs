using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{

    [HideInInspector] public Vector2 currentPosition;
    private Vector2 startPosition;
    public bool hasJustDied;
    
    private void Start()
    {
        startPosition = new Vector2(0, 0);
        currentPosition = startPosition;
        hasJustDied = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ResetBorder")
        {
            print("you have fallen");
            gameObject.transform.position = currentPosition;
            hasJustDied = true;
        }
        
        if (other.gameObject.tag == "CheckPoint_1")
        {
            currentPosition = gameObject.transform.position;
            hasJustDied = false;
        }
        
        if (other.gameObject.tag == "finish")
        {
            print("Congratulations, you won!");
            gameObject.transform.position = startPosition;
        }
    }
    
}
    