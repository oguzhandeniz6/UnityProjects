using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;
    Animator animator;
    [SerializeField]
    CapsuleCollider2D feet;

    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float jumpSpeed = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        feet = GetComponent<CapsuleCollider2D>();
    }

    void FixedUpdate() 
    {
        Move();
    }


    void Update()
    {
        Animation();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

        bool playerMoving = Mathf.Abs(moveInput.x) > Mathf.Epsilon;
        animator.SetBool("isRunning", playerMoving);
    }

    void OnJump(InputValue value)
    {
        if (!feet.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }

        if(value.isPressed)
        {
            rb.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void OnChangeGravity(InputValue value)
    {
        if(value.isPressed)
        {
            rb.gravityScale = rb.gravityScale == 0f ? 1f : 0f;
        }
    }

    void Move()
    {
        if(feet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
            rb.velocity = playerVelocity;
        }
        
        FlipSprite();
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
    }

    void Animation()
    {
        if (!feet.IsTouchingLayers(LayerMask.GetMask("Ground"))) 
        { 
            animator.SetBool("didJump", true);
            
        }
        if (feet.IsTouchingLayers(LayerMask.GetMask("Ground"))) 
        { 
            animator.SetBool("didJump", false);
        }
    }
}
