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
    
    
    void Start()
    {
        _input = GetComponent<PlayerInput>();
        plantTextdone = false;
        defendTextdone = false;
        countdowndone = false;
    }

    
    void Update()
    {
        if (_input.interact && _Bomb.canInteract)
        {
            plantText.GetComponent<SpriteRenderer>().enabled = false;
            plantTextdone = true;
        }

        if (plantTextdone && _Bomb.enemiesCanSpawn)
        {
            defendText.GetComponent<SpriteRenderer>().enabled = true;
            plantTextdone = false;
            defendTextdone = true;
            
        }

        if (defendTextdone && _input.interact && _Bomb.hasInteractedWithBomb)
        {
            defendText.GetComponent<SpriteRenderer>().enabled = false;
            startCountdown.GetComponent<SpriteRenderer>().enabled = true;
            defendTextdone = false;
            countdowndone = true;
        }

        if (countdowndone)
        {
            startCountdown.GetComponent<SpriteRenderer>().enabled = false;
            escape.GetComponent<SpriteRenderer>().enabled = true;
        }
        
    }
}
