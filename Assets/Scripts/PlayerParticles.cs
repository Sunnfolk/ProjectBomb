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
    
    public static ParticleSystem ExlosionParticles;
    public GameObject _ExlosionParticles;
    
    public static ParticleSystem ExlosionParticles1;
    public GameObject _ExlosionParticles1;
    
    public static ParticleSystem ExlosionParticles2;
    public GameObject _ExlosionParticles2;
    
    void Start()
    {
        DustParticles = _DustParticles.GetComponent<ParticleSystem>();
        DashParticles = _DashParticles.GetComponent<ParticleSystem>();
        PunchParticles = _PunchParticles.GetComponent<ParticleSystem>();
        ExlosionParticles = _ExlosionParticles.GetComponent<ParticleSystem>();
        ExlosionParticles1 = _ExlosionParticles1.GetComponent<ParticleSystem>();
        ExlosionParticles2 = _ExlosionParticles2.GetComponent<ParticleSystem>();
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

    public static void CreateExplosion()
    {
        ExlosionParticles.Play();
        ExlosionParticles1.Play();
        ExlosionParticles2.Play();
    }
}
