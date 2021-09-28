using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class Bomb : MonoBehaviour
{

    private bool canInteract;
    private bool hasInteracted;
    private bool bombWasPlanted;
    [HideInInspector] public bool enemiesCanSpawn;
    

    [SerializeField] private float bombStartTimer = 5f;
    [SerializeField] private float bombCurrentTimer;
    
    private PlayerInput m_Input;
    public SpriteRenderer spriteRenderer;
    
    
    void Start()
    {
        m_Input = GetComponent<PlayerInput>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();

        canInteract = false;
        hasInteracted = false;
        bombWasPlanted = false;
        enemiesCanSpawn = false;

        bombCurrentTimer = bombStartTimer;
    }

    
    void Update()
    {
        if (m_Input.interact)
        {
            hasInteracted = true;
        }
        else
        {
            hasInteracted = false;
        }
        
        PlantBomb();
        BombTimer();
        BombReady();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canInteract = true;
            print("Press F to plant the bomb");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canInteract = false;
        }
    }

    private void PlantBomb()
    {
        if (canInteract && hasInteracted)
        {
            print("you planted the bomb");
            this.spriteRenderer.enabled = true;
            bombWasPlanted = true;
        }
    }

    private void BombTimer()
    {
        if (bombWasPlanted)
        {
            enemiesCanSpawn = true;
            bombCurrentTimer -= Time.deltaTime;
            
        }
    }

    private void BombReady()
    {
        if (bombCurrentTimer <= 0)
        {
           print("bomb ready");
           enemiesCanSpawn = false;
        }
    }
    


}
