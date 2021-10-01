using System.Collections;   
using System.Collections.Generic;   
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [HideInInspector] public Vector2 moveVector;
    [HideInInspector] public bool jump;
    [HideInInspector] public bool longJump;
    [HideInInspector] public bool attack;
    [HideInInspector] public bool interact;
    [HideInInspector] public bool resetPlayer;
    [HideInInspector] public bool exitApplication;
    

    void Update()
    {
        moveVector.x = (Keyboard.current.aKey.isPressed ? -1f : 0f) + (Keyboard.current.dKey.isPressed ? 1f : 0f);
        moveVector.y = (Keyboard.current.sKey.isPressed ? -1f : 0f) + (Keyboard.current.wKey.isPressed ? 1f : 0f);

        jump = Keyboard.current.spaceKey.wasPressedThisFrame;
        longJump = Keyboard.current.spaceKey.isPressed;

        attack = Mouse.current.leftButton.wasPressedThisFrame;
        interact = Keyboard.current.fKey.wasPressedThisFrame;

        resetPlayer = Keyboard.current.enterKey.wasPressedThisFrame;

        exitApplication = Keyboard.current.escapeKey.wasPressedThisFrame;

        if (exitApplication)
        {
            Application.Quit();
        }
    }
}
