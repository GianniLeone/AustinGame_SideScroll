using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;


    //
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get user input
        processInputs();

        // Animate
        animateCharacter();

        // Move player
        moveCharacter();
    }

    private void processInputs()
    {
        moveDirection = Input.GetAxis("Horizontal");
    }

    private void animateCharacter()
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

    private void moveCharacter()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
    }

    private void flipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

}
