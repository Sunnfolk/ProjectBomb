using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticles : MonoBehaviour
{

    public static ParticleSystem DustParticles; // static makes it available across all scripts without needing to reference
    public GameObject _DustParticles;

    public static ParticleSystem DashParticles;
    public GameObject _DashParticles;

    public static ParticleSystem PunchParticles;
    public GameObject _PunchParticles;
    
    
    void Start()
    {
        DustParticles = _DustParticles.GetComponent<ParticleSystem>();
        DashParticles = _DashParticles.GetComponent<ParticleSystem>();
        PunchParticles = _PunchParticles.GetComponent<ParticleSystem>();
    }

    
    
    public static void CreateDust()
    {
        DustParticles.Play();
    }

    public static void CreateDash()
    {
        DashParticles.Play();
    }

    public static void CreatePunch()
    {
        PunchParticles.Play();
    }
    
}
