using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = Unity.Mathematics.Random;

public class Bomb : MonoBehaviour
{

    [HideInInspector] public bool canInteract;
    [HideInInspector] public bool hasInteractedWithBomb;
    public bool hasInteracted;
    private bool bombCanExplode;
    [HideInInspector] public bool bombWasPlanted;
    [HideInInspector] public bool enemiesCanSpawn;
    private bool hasPlayedExplosion;
    

    [SerializeField] private float bombStartTimer = 5f;
    [SerializeField] private float bombCurrentTimer;
    [SerializeField] private float explodeStartTimer = 10f;
    [SerializeField] public float explodeCurrentTimer;
    [SerializeField] private float bombStartHealth = 3f;
    [SerializeField] private float bombCurrentHealth;

    public AudioClip bombExplosion;
    
    private PlayerInput m_Input;
    public SpriteRenderer spriteRenderer;
    private HitDetection m_hitDetection;
    private AudioSource _AudioSource;
    
    void Start()
    {
        m_Input = GetComponent<PlayerInput>();
        m_hitDetection = GetComponent<HitDetection>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        _AudioSource = GetComponent<AudioSource>();

        canInteract = false;
        hasInteracted = false;
        bombWasPlanted = false;
        enemiesCanSpawn = false;
        bombCanExplode = false;
        hasPlayedExplosion = false;


        bombCurrentTimer = bombStartTimer;
        explodeCurrentTimer = explodeStartTimer;
        bombCurrentHealth = bombStartHealth;
        
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

        if (m_Input.interact && bombCanExplode)
        {
            hasInteractedWithBomb = true;
        }
        
        PlantBomb();
        BombTimer();
        BombReady();
        BombExplosion();
        BombHealth();
        DeathLoadLevel();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canInteract = true;
            print("Press F to plant the bomb");
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            print("The bombs take damage");
            bombCurrentHealth--;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);  
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
            CinemachineSwitcher.canZoom = true;
           print("Bomb is ready. Press F to initiate detonation");
           enemiesCanSpawn = false;
           bombCanExplode = true;
        }
    }

    private void BombExplosion()
    {
        if (hasInteractedWithBomb)
        {
            explodeCurrentTimer -= Time.deltaTime;
            print("its going to explode");
            CinemachineSwitcher.canZoom = false;
            LightController.canActivateLight = true;
        }

       
    }

    private void BombHealth()
    {
        if (bombCurrentHealth <= 0)
        {
            SceneManager.LoadScene("GameOverMenu");
        }
        
        if (explodeCurrentTimer <= 0 && !hasPlayedExplosion) 
        {
            _AudioSource.PlayOneShot(bombExplosion);
            PlayerParticles.CreateExplosion();
            hasPlayedExplosion = true;
        }

    }

    private void DeathLoadLevel()
    {
        if (explodeCurrentTimer < -1)
        { 
            SceneManager.LoadScene("GameOverMenu");
        }
        
    }
    
}
