using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DashAbility : MonoBehaviour {
     
    public DashState dashState;
    public float dashTimer;
    public float coolDown = 5f;
    private Rigidbody2D _rigidBody2D;

    private TestPlayerMovement _move;
    private PlayerInput _input;
    public float DashSpeed = 3f;
    public Vector2 savedVelocity;


    private void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _move = GetComponent<TestPlayerMovement>();
        _input = GetComponent<PlayerInput>();
    }

    void Update ()
    {
       
        
        switch (dashState) 
        {
            case DashState.Ready:
                if (_input.moveVector.x == 0) return;
                var isDashKeyDown = Keyboard.current.leftShiftKey.wasPressedThisFrame;
                if(isDashKeyDown)
                {
                    savedVelocity = _rigidBody2D.velocity;
                    _rigidBody2D.velocity =  new Vector2(_rigidBody2D.velocity.x * DashSpeed, _rigidBody2D.velocity.y);
                    dashState = DashState.Dashing;
                }
                break;
            case DashState.Dashing:
                dashTimer += Time.deltaTime * 3;
                if(dashTimer >= coolDown)
                {
                    dashTimer = coolDown;
                    _rigidBody2D.velocity = savedVelocity;
                    dashState = DashState.Cooldown;
                }
                break;
            case DashState.Cooldown:
                dashTimer -= Time.deltaTime;
                if(dashTimer <= 0)
                {
                    dashTimer = 0;
                    dashState = DashState.Ready;
                }
                break;
        }

        if (_move.IsGrounded())
        {
            dashTimer = 0;
            dashState = DashState.Cooldown;
        }
    }
}
 
public enum DashState 
{
    Ready,
    Dashing,
    Cooldown
}
