using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObjects;
    public float checkRadius; 

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    private bool isJumping = false; 
    private bool isGrounded; 

    //
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get user input
        ProcessInputs();

        // Animate
        Animate();
    }

    private void FixedUpdate()
    {
        //Check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
        // Move player
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if(isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
        } 
        isJumping = false;
    }

    private void Animate()
    {
        if (moveDirection > 0 && !facingRight)
        {
            flipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            flipCharacter();
        }
    }

    private void ProcessInputs()
    {
        moveDirection = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump") && isGrounded)
        { 
            isJumping = true;
        }
    }

    private void flipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

}
