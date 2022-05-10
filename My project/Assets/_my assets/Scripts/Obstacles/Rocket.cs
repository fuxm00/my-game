using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class represents rockets.
/// Barells explode on impact with certain objects 
/// which is determined by values in their tags.
/// Each has blast radius to affect nearby objects and explode force to be apllied to them.
/// Each has specific moving speed and rotationing speed 
/// and can follow certain object by a bool _isHoming.
/// </summary>
public class Rocket : MonoBehaviour
{
    [Header("Characteristics")]
    [SerializeField] float _rocketSpeed;
    [SerializeField] float _rotationSpeed;
    [SerializeField] bool _isHoming;
    [SerializeField] float _blastRadius;
    [SerializeField] float _explodeForce;
    [SerializeField] float _timeDelayToExplode;

    [Header("Effect")]
    [SerializeField] GameObject _explosionEffect;

    private Transform _targetTransform;
    private Rigidbody2D _rb;
    private float _timeToExplode;

    /// <summary>
    /// Finds target if needed, gets access to it's rigidbody and sets time to explode on start.
    /// </summary>
    void Start()
    {
        if (_targetTransform == null)
        {
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                _targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
            }
        }

        _rb = GetComponent<Rigidbody2D>();
        _timeToExplode = Time.time + _timeDelayToExplode;
    }

    /// <summary>
    /// If the explode time has come, explodes the rocket on update.
    /// </summary>
    void Update()
    {
        if (Time.time < _timeToExplode)
        {
            return;
        }
        
        Explode();
    }

    /// <summary>
    /// Rotates by a rocket when wanted.
    /// </summary>
    void FixedUpdate()
    {
        if (_targetTransform != null)
        {
            if (_isHoming == true)
            {
                Vector2 desiredDirection = _targetTransform.position - transform.position;
                Vector2 currentDirection = gameObject.transform.up;
                desiredDirection.Normalize();
                float rotateAmount = Vector3.Cross(desiredDirection, currentDirection).z;
                _rb.angularVelocity = rotateAmount * _rotationSpeed * -1;
            }
        }

        _rb.velocity = transform.up * _rocketSpeed;
    }

    /// <summary>
    /// Explodes when collision with certain objects.
    /// </summary>
    /// <param name="col">
    /// collider of a colliding object
    /// </param>
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Platform" || 
            col.gameObject.tag == "Obstacle" || 
            col.gameObject.tag == "Player")
        {
            Explode();
        }
    }

    /// <summary>
    /// Explodes the rocket, affects nearby objects and damage player.
    /// </summary>
    private void Explode()
    {
        Instantiate(_explosionEffect, transform.position, transform.rotation);
        Collider2D[] nearbyObjects = Physics2D.OverlapCircleAll(transform.position, _blastRadius);
        bool playerAlreadyFound = false;

        foreach (Collider2D nearbyObject in nearbyObjects)
        {
            Rigidbody2D rb = nearbyObject.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Vector2 direction = nearbyObject.transform.position - transform.position;
                rb.AddForce(direction.normalized * _explodeForce);
            }

            if (playerAlreadyFound)
            {
                continue;
            }

            PlayerHealth health = nearbyObject.GetComponent<PlayerHealth>();

            if (health != null)
            {
                health.DamagePlayer(1);
                playerAlreadyFound = true;
            }
        }

        Destroy(gameObject);
    }
}
