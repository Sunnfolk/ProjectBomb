using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using EZCameraShake;

public class HitDetection : MonoBehaviour
{
    private PlayerInput m_Input;
    private EnemyAnimations m_EnemyAnimations;
    

    private bool canhit;
    [HideInInspector] public bool enemyHit;

    [HideInInspector] public bool enteredSafeArea;

    [SerializeField] private float startEnemyHealth = 3f;
    [SerializeField] private float currentEnemyHealth;


    void Start()
    {
        m_Input = GetComponent<PlayerInput>();
        m_EnemyAnimations = GetComponent<EnemyAnimations>();

        canhit = false;
        enemyHit = false;
        enteredSafeArea = false;

        currentEnemyHealth = startEnemyHealth;
    }

    private void Update()
    {
        if (canhit && m_Input.attack)
        {
            enemyHit = true;
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            canhit = true;
        }

        if (other.gameObject.tag == "TPsafeArea")
        {
            enteredSafeArea = true;
            print("you are safe");
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
            CameraShaker.Instance.ShakeOnce(4f, 2f, 0.1f, 0.1f);
            enemyHit = false;
        }

        if (other.gameObject.CompareTag("Enemy") && currentEnemyHealth == 0)
        {
            other.gameObject.GetComponent<EnemyAnimations>().PlayDeath();
            currentEnemyHealth = startEnemyHealth; // This might cause a but as it only resets when an enemy is destroyed, which might be a problem when hitting two enemies at the same time 
        }

        
        
        
    }

}

