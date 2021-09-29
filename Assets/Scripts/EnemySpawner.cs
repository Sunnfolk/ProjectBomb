using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemySpawner : MonoBehaviour
{
    private Bomb m_bomb;

    public GameObject EnemyLeft;
    public GameObject EnemyRight;

    public float randomTimeRight;
    public float randomTimeLeft;
    
    
    void Start()
    {
        m_bomb = GetComponent<Bomb>();
        randomTimeRight = 0f;
        randomTimeLeft = 0f;

        //InvokeRepeating("randomizedSpawn", 1f, 1f);
    }
    
    void Update()
    {
        enemySpawner();
    }


    private void enemySpawner()
    {
        if (m_bomb.enemiesCanSpawn)
        {
            if (randomTimeLeft >= 0)
            {
                randomTimeLeft -= 1 * Time.deltaTime;
            }
            else
            { 
               spawnerLeft();
               randomizedSpawnLeft();
            }
            
            if (randomTimeRight >= 0)
            {
                randomTimeRight -= 1 * Time.deltaTime;
            }
            else
            {
                spawnerRight();
                randomizedSpawnRight();
            }
            
        }
    }

    private void randomizedSpawnLeft()
    {
        randomTimeLeft = Random.Range(1f, 5f);
    }

    private void randomizedSpawnRight()
    {
        randomTimeRight = Random.Range(1f, 5f);
    }
    
    private void spawnerRight()
    {
        Instantiate(EnemyRight, new Vector2(40.3f, 2.41f), Quaternion.identity);
    }

    private void spawnerLeft()
    {
        Instantiate(EnemyLeft, new Vector2(-38.6f, 2.41f), Quaternion.identity);  
    }
}
