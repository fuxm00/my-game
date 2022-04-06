using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Joystick joystick;

    private Rigidbody2D rb;

    private float moveInput;
    private float jumpInput;
    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheckObject;
    public float groundDistanceToCheck;
    public LayerMask groundMask;
    private bool hasJumped;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        hasJumped = true;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = joystick.Horizontal;
        jumpInput = joystick.Vertical;
    }

    private void FixedUpdate()
    {
        groundCheck();

        movePlayer(moveInput, 0);

        wrongFacingCheck();

        jumpCheck();
    }

    private void groundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckObject.position, groundDistanceToCheck, groundMask);
    }

    private void movePlayer(float horizontal, float vertical)
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private void wrongFacingCheck()
    {
        if (facingRight == false && moveInput > 0)
        {
            flipPlayer();
        }
        else if (facingRight == true && moveInput < 0)
        {
            flipPlayer();
        }
    }
    private void flipPlayer()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void jumpCheck()
    {
        if (isGrounded == true)
        {
            hasJumped = false;
        }

        if (jumpInput > 0.5 && !hasJumped && isGrounded)
        {
            jump();
            hasJumped = true;
        }
    }

    private void jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    public void resetMovement()
    {
        rb.velocity = Vector2.zero;
    }
}
