using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyMovement : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody;
    [SerializeField] private float moveVector = 1f;
    
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
        m_Rigidbody.velocity = new Vector2(moveVector, 0);
    }
    
    
}


