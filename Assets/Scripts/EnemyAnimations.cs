using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    private HitDetection m_HitDetection;
    private Animator m_Animator;
    
    void Start()
    {
        m_HitDetection = GetComponent<HitDetection>();
        m_Animator = GetComponent<Animator>();
    }

    
    void Update()
    {
   
    }

    public void PlayDeath()
    {
        m_Animator.Play("EnemyDeath");
        //Destroy(gameObject, m_Animator.GetCurrentAnimatorClipInfo(0).Length);
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }



}
