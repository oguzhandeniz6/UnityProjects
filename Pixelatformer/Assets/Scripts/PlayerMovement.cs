using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;
    Animator animator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;
    SpriteRenderer spriteRenderer;

    float startGravity;
    bool isAlive;
    Vector2 moveInput;
    Color firstColor = new Color(1f, 1f, 1f, 1f);
    Color deathColor = new Color(1f, 0f, 0f, 1f);

    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(10f, 10f);
    [SerializeField] GameObject arrowRight;
    [SerializeField] GameObject arrowLeft;
    [SerializeField] Transform bow;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        startGravity = rb.gravityScale;
        spriteRenderer.color = firstColor;
        isAlive = true;
    }

    void Update()
    {
        if (!isAlive) {return;}

        Run();
        FlipSprite();
        Climb();
        didHit();
    }

    void OnMove(InputValue value)
    {
        if (!isAlive) {return;}

        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (!isAlive) {return;}
        if(!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){return;}

        if(value.isPressed)
        {
            rb.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void OnFire(InputValue value)
    {
        if (!isAlive) {return;}

        if(rb.transform.localScale.x > 0)
        {
            Instantiate(arrowRight, bow.position, transform.rotation);
        }
        else
        {
            Instantiate(arrowLeft, bow.position, transform.rotation);
        }

        animator.SetTrigger("Shoot");
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        animator.SetBool("isRunning", playerHasHorizontalSpeed);
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
    }

    void Climb()
    {
        bool isClimbing = Mathf.Abs(rb.velocity.y) > Mathf.Epsilon && myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Ladder"));

        if(myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            rb.gravityScale = 0f;
            Vector2 climbVelocity = new Vector2(rb.velocity.x, moveInput.y * climbSpeed);
            rb.velocity = climbVelocity;
        }

        else
        {
            rb.gravityScale = startGravity;
        }
        
        animator.SetBool("isClimbing", isClimbing);
    }

    void didHit()
    {
        if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards", "Water")))
        {
            isAlive = false;
            animator.SetTrigger("Dying");
            spriteRenderer.color = deathColor;
            rb.velocity = deathKick;
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }
}
