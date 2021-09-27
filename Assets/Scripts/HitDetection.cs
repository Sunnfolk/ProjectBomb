using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    private PlayerInput m_Input;
    
    private bool canhit;
    private bool enemyHit;
    
    [SerializeField] private float startEnemyHealth = 3f;
    [SerializeField] private float currentEnemyHealth;
    
    
    void Start()
    {
        m_Input = GetComponent<PlayerInput>();
        
        canhit = false;
        enemyHit = false;
        
        currentEnemyHealth = startEnemyHealth;
    }

    private void Update()
    {
        if (canhit && m_Input.attack)
        {
            enemyHit = true;
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            canhit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            canhit = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && enemyHit)
        { 
            currentEnemyHealth = currentEnemyHealth - 1f;
            enemyHit = false;
        }

        if (other.gameObject.CompareTag("Enemy") && currentEnemyHealth == 0)
        {
            Destroy(other.gameObject); // add this function to the animation later when we have it
            currentEnemyHealth = startEnemyHealth; // This might cause a but as it only resets when an enemy is destroyed, which might be a problem when hitting two enemies at the same time 
        }
        
        
        
    }
}
