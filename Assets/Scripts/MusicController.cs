using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    private AudioSource _AudioSource;
    
    public AudioClip combatMusic;

    public Bomb bomb;
    private PlayerInput _Input;

    private bool combatMusicHasPlayed;
    private bool pastCombatMusic;


    void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
        _Input = GetComponent<PlayerInput>();

        combatMusicHasPlayed = false;
        pastCombatMusic = true;
    }

    
    void Update()
    {
        if (bomb.canInteract && _Input.interact)
        {
            combatMusicHasPlayed = true;
        }

        if (combatMusicHasPlayed && pastCombatMusic)
        {
            CombatMusic();
            pastCombatMusic = false;
        }
        
        
    }

    private void CombatMusic()
    {
        _AudioSource.PlayOneShot(combatMusic);
        combatMusicHasPlayed = false;
    }
    
    
    
    
}
