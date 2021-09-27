using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody;
    [SerializeField] private float moveVectorX = 1f;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        m_Rigidbody.velocity = new Vector2(moveVectorX, m_Rigidbody.velocity.y);
    }
    
    
}


