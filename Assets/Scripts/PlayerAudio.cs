using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerAudio : MonoBehaviour
{
    
    public AudioClip jump;
    public AudioClip land;
    public AudioClip walking;
    public AudioClip punch;
    public AudioClip Dash;
    public AudioClip interact;
    
    private bool canland;
    private bool interactSFX;
    
    private AudioSource audioSource;
    private PlayerInput Input;
    private TestPlayerMovement playerMovement;
    private DashAbility dashAbility;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Input = GetComponent<PlayerInput>();
        playerMovement = GetComponent<TestPlayerMovement>();
        dashAbility = GetComponent<DashAbility>();
        interactSFX = false;
    }

  
    void Update()
    {
        //JumpAudio();
        //LandingAudio();
        PunchAudio();
        InteractAudio();
    }

    private void WalkingAudio()
    {
        audioSource.pitch = Random.Range(0.5f, 1.5f);
        audioSource.PlayOneShot(walking);
        PlayerParticles.CreateDust();
    }

    private void LandingAudio()
    {
        if (playerMovement.IsGrounded() && canland)
        {
            audioSource.pitch = Random.Range(0.8f, 1.2f); // the random range gives you the possible to spesify a range like i did here
            audioSource.PlayOneShot(land);
            canland = false;
            PlayerParticles.CreateDust();
        }
        else if (!playerMovement.IsGrounded())
        {
            canland = true;
        }
    }
    private void JumpAudio()
    {
        if (Input.jump && playerMovement.canCoyote)
        {
            audioSource.pitch = Random.Range(0.5f, 1.5f);
            audioSource.PlayOneShot(jump);
        }
    }

    private void PunchAudio()
    {
        if (Input.attack)
        {
            audioSource.PlayOneShot(punch);
        }
    }

    private void DashAudio()
    {
        audioSource.PlayOneShot(Dash);
        PlayerParticles.CreateDash();
    }

    private void InteractAudio()
    {
        if (interactSFX && Input.interact)
        {
            audioSource.PlayOneShot(interact);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "TPbomb")
        {
            interactSFX = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "TPbomb")
        {
            interactSFX = false;
        }
    }
}
