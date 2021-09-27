using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this will automatically add the playerinput script if i add player movement to a game object
//[RequireComponent(typeof(PlayerInput))] 

public class TestPlayerMovement : MonoBehaviour

{
   [SerializeField] private float moveSpeed;
   [SerializeField] private float jumpForce;
   [SerializeField] private LayerMask whatIsGround; // this adds a selector in the inspector to  be able to specify which layer which will be detected
   [SerializeField] private float maxVelocity = -24f;
   
   private PlayerInput _Input;
   private Rigidbody2D _Rigidbody2D;

   private bool isJumping = false;
   private float jumpTimeCounter;
   private float jumpTime = 0.25f;

   [SerializeField] private float coyoteTime;
   private float coyoteTimeCounter;
   [HideInInspector] public bool canCoyote;
   
   private void Start()
   {
      // must be on the same object for it to be able to access the player input script and the rigidbody2d components
      _Input = GetComponent<PlayerInput>();
      _Rigidbody2D = GetComponent<Rigidbody2D>();
   }

   private void Update()
   {
      LongJump();
      SetMaxVelocity();


      if (IsGrounded())
      {
         canCoyote = true;
         coyoteTimeCounter = coyoteTime;
      }
      
      else if (!IsGrounded() && _Rigidbody2D.velocity.y <= 0 ) // && canCoyote
      {
         coyoteTimeCounter -= Time.deltaTime;
      }
      
      else
      {
         canCoyote = false;
      }

      if (coyoteTimeCounter < 0 ) // ||  = or , can try to add 0 < +infinity
      {
         canCoyote = false;   
      }
      
      if (_Input.jump) // accesses the jump function in our player input script
      {
         if (!canCoyote) return;

         isJumping = true;
         jumpTimeCounter = jumpTime;
         _Rigidbody2D.velocity = new Vector2(_Rigidbody2D.velocity.x, jumpForce);
         canCoyote = false;
      }
      
   }
   
   private void FixedUpdate()
   {
      _Rigidbody2D.velocity = new Vector2(_Input.moveVector.x * moveSpeed, _Rigidbody2D.velocity.y);
   }

   private void LongJump()
   {
      if (_Input.longJump && isJumping)
      {
         if (jumpTimeCounter > 0)
         {
            _Rigidbody2D.velocity = Vector2.up * jumpForce;
            jumpTimeCounter -= Time.deltaTime;
         }
         else
         {
            isJumping = false;
         }
      }

      if (!_Input.longJump)
      {
         isJumping = false;
      }
   }

   private void SetMaxVelocity()
   {
      if (IsGrounded())
      {
         return; // this stops the method from going any further
      }

      if (_Rigidbody2D.velocity.y < maxVelocity)
      {
         _Rigidbody2D.velocity = new Vector2(_Rigidbody2D.velocity.y, maxVelocity);
      }
   }

   public bool IsGrounded()
   {
      Debug.DrawRay(transform.position, Vector2.down, new Color(1f, 0f, 1f));
      RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.3f, whatIsGround); //Will only collide with object that is on  the whatIsGrounded

      return hit.collider != null;
   }
   
   
}
