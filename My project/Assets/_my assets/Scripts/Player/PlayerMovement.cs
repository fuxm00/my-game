using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class manages player's movement. Check whether he is grounded in order to jump, 
/// his facing direction and velocity.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [Header("Characteristics")]
    [SerializeField] float _moveSpeed;
    [SerializeField] float _jumpForce;
    [SerializeField] float _velocityOfDeath;

    [Header("Joystick")]
    [SerializeField] Joystick _joystick;

    [Header("jump Button")]
    [SerializeField] GameObject _jumpButton;

    [Header("Player")]
    [SerializeField] GameObject _player;    

    [Header("Ground check")]
    [SerializeField] Transform _groundCheckLeft;
    [SerializeField] Transform _groundCheckRight;
    [SerializeField] float _distanceToCheck;
    [SerializeField] LayerMask _groundMask;

    private bool _isGrounded;
    private bool _hasJumped;
    private bool _facingRight = true;
    private float _moveInput;
    private Vector3 _startPostion;
    private PlayerHealth _playerhealth;
    private Rigidbody2D _rb;
    private JumpButton _jumpButtonScript;

    /// <summary>
    /// Gets access to certain components and prepares a field.
    /// </summary>
    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        _hasJumped = true;
        _startPostion = _player.transform.position;
        _playerhealth = _player.GetComponent<PlayerHealth>();
        _jumpButtonScript = _jumpButton.GetComponent<JumpButton>();
    }

    /// <summary>
    /// Gets input from joystick and checks player facing direction on update.
    /// </summary>
    void Update()
    {
        _moveInput = _joystick.Horizontal;
        WrongFacingCheck();
    }

    /// <summary>
    /// Moves player, checks whether the player is grounded ,
    /// whether he is able to jump and his falling speed.
    /// </summary>
    void FixedUpdate()
    {
        GroundCheck();
        MovePlayer();
        JumpCheck();
        VelocityCheck();
    }

    /// <summary>
    /// Resets player's position.
    /// </summary>
    public void ResetPosition()
    {
        _player.transform.position = _startPostion;
    }

    /// <summary>
    /// Checks whether the player is grounded or not.
    /// </summary>
    private void GroundCheck()
    {
        Vector3 leftPos = _groundCheckLeft.position;
        Vector3 rightPos = _groundCheckRight.position;

        if (Physics2D.OverlapCircle(leftPos, _distanceToCheck, _groundMask) || 
            Physics2D.OverlapCircle(rightPos, _distanceToCheck, _groundMask))
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
    }

    /// <summary>
    /// Moves by a player.
    /// </summary>
    private void MovePlayer()
    {
        _rb.velocity = new Vector2(_moveInput * _moveSpeed, _rb.velocity.y);
    }

    /// <summary>
    /// Checks facing diretion of a player.
    /// </summary>
    private void WrongFacingCheck()
    {
        if (_facingRight == false && _moveInput > 0)
        {
            FlipPlayer();
        }
        else if (_facingRight == true && _moveInput < 0)
        {
            FlipPlayer();
        }
    }

    /// <summary>
    /// Flips palyer.
    /// </summary>
    private void FlipPlayer()
    {
        _facingRight = !_facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    /// <summary>
    /// Checks whether the player can jump.
    /// </summary>
    private void JumpCheck()
    {
        if (_isGrounded == true)
        {
            _hasJumped = false;
        }

        if (_jumpButtonScript.IsPressed && !_hasJumped && _isGrounded)
        {
            Jump();
            _hasJumped = true;
        }
    }

    /// <summary>
    /// Jumps with a player.
    /// </summary>
    private void Jump()
    {
        _rb.velocity = Vector2.up * _jumpForce;
        FindObjectOfType<AudioManager>().Play("Jump");
    }

    /// <summary>
    /// Checks whether the player falls too fast.
    /// </summary>
    private void VelocityCheck()
    {
        if (_rb.velocity.y < _velocityOfDeath)
        {
            _playerhealth.Die();
        }
    }
}
