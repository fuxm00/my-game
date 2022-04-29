using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private PlayerHealth _playerhealth;
    private bool _hasJumped;
    private Vector3 _startPostion;
    private Rigidbody2D _rb;
    private float _moveInput;
    private bool _facingRight = true;
    private JumpButton _jumpButtonScript;

    // Start is called before the first frame update
    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        _hasJumped = true;

        _startPostion = _player.transform.position;
        _playerhealth = _player.GetComponent<PlayerHealth>();
        _jumpButtonScript = _jumpButton.GetComponent<JumpButton>();
    }

    // Update is called once per frame
    void Update()
    {
        _moveInput = _joystick.Horizontal;
        WrongFacingCheck();
    }

    void FixedUpdate()
    {
        GroundCheck();
        MovePlayer(_moveInput, 0);
        JumpCheck();
        VelocityCheck();
    }

    private void GroundCheck()
    {
        if (Physics2D.OverlapCircle(_groundCheckLeft.position, _distanceToCheck, _groundMask) || 
            Physics2D.OverlapCircle(_groundCheckRight.position, _distanceToCheck, _groundMask))
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
    }

    private void MovePlayer(float horizontal, float vertical)
    {
        _rb.velocity = new Vector2(_moveInput * _moveSpeed, _rb.velocity.y);
    }

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
    private void FlipPlayer()
    {
        _facingRight = !_facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

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

    private void Jump()
    {
        _rb.velocity = Vector2.up * _jumpForce;
        FindObjectOfType<AudioManager>().Play("Jump");
    }

    public void ResetPosition()
    {
        _player.transform.position = _startPostion;
    }

    private void VelocityCheck()
    {
        if (_rb.velocity.y < _velocityOfDeath)
        {
            _playerhealth.Die();
        }
    }
}
