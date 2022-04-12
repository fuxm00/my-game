using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Characteristics")]
    public float moveSpeed;
    public float jumpForce;

    [Header("Joystick")]
    public Joystick joystick;

    [Header("Player")]
    public GameObject player;

    private Rigidbody2D rb;

    private float moveInput;
    private float jumpInput;
    private bool facingRight = true;

    [Header("Ground check")]
    public Transform groundCheckObjectLeft;
    public Transform groundCheckObjectRight;
    public float groundDistanceToCheck;
    public LayerMask groundMask;
    private bool isGrounded;

    private bool hasJumped;

    private Vector3 startPostion;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        hasJumped = true;

        startPostion = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = joystick.Horizontal;
        jumpInput = joystick.Vertical;

        wrongFacingCheck();
    }

    private void FixedUpdate()
    {
        groundCheck();

        movePlayer(moveInput, 0);

        jumpCheck();
    }

    private void groundCheck()
    {
        if (Physics2D.OverlapCircle(groundCheckObjectLeft.position, groundDistanceToCheck, groundMask) || Physics2D.OverlapCircle(groundCheckObjectRight.position, groundDistanceToCheck, groundMask))
        {
            isGrounded = true;
        } else
        {
            isGrounded = false;
        }
        
        //isGrounded = Physics2D.OverlapCircle(groundCheckObject.position, groundDistanceToCheck, groundMask);
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

    public void resetPosition()
    {
        //player.transform.position = new Vector3(0, 2.76f, 0) ;
        player.transform.position = startPostion;
    }
}
