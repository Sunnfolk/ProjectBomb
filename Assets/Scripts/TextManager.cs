using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{

    public Bomb _Bomb; // By making this public, i create a field in the inspector where i can drag in the bomb object as it needs the spesific game object for script to work
    private PlayerInput _input;

    public GameObject plantText;
    public GameObject defendText;
    public GameObject startCountdown;
    public GameObject escape;

    private bool plantTextdone;
    private bool defendTextdone;
    private bool countdowndone;
    private bool delayStart;

    [SerializeField] private float delayTimerStart = 5f;
    private float delayTimerCurrent;
    
    
    void Start()
    {
        _input = GetComponent<PlayerInput>();
        plantTextdone = false;
        defendTextdone = false;
        countdowndone = false;
        delayStart = false;

        delayTimerCurrent = delayTimerStart;
    }

    
    void Update()
    {
        if (_input.interact && _Bomb.canInteract) // Plant bomb
        {
            plantText.GetComponent<SpriteRenderer>().enabled = false;
            plantTextdone = true;
        }

        if (plantTextdone && _Bomb.enemiesCanSpawn) // Defend bomb
        {
            defendText.GetComponent<SpriteRenderer>().enabled = true;
            plantTextdone = false;
            defendTextdone = true;
            delayStart = true;

        }

        if (defendTextdone && _Bomb.enemiesCanSpawn == false && delayTimerCurrent <= 0f) // press f to start countdown
        {
            defendText.GetComponent<SpriteRenderer>().enabled = false;
            startCountdown.GetComponent<SpriteRenderer>().enabled = true;
            defendTextdone = false;
            countdowndone = true;
        }

        if (countdowndone && _Bomb.hasInteractedWithBomb) // Escape before it explodes
        {
            startCountdown.GetComponent<SpriteRenderer>().enabled = false;
            escape.GetComponent<SpriteRenderer>().enabled = true;
        }
        
        DelayCounter();
        
    }

    private void DelayCounter()
    {
        if (delayStart)
        {
            delayTimerCurrent -= Time.deltaTime;
        }
    }
    
}
