using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Update()
    {
        if (Time.time < _timeToExplode)
        {
            return;
        }
        
        Explode();
    }

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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Platform" || 
            col.gameObject.tag == "Obstacle" || 
            col.gameObject.tag == "Player")
        {
            Explode();
        }
    }

    private void Explode()
    {
        Instantiate(_explosionEffect, transform.position, transform.rotation);
        Collider2D[] nearbyObjects = Physics2D.OverlapCircleAll(transform.position, _blastRadius);

        foreach (Collider2D nearbyObject in nearbyObjects)
        {
            Rigidbody2D rb = nearbyObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 direction = nearbyObject.transform.position - transform.position;
                rb.AddForce(direction.normalized * _explodeForce);
            }
        }

        foreach (Collider2D nearbyObject in nearbyObjects)
        {
            PlayerHealth health = nearbyObject.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.DamagePlayer(1);
                break;
            }
        }

        Destroy(gameObject);
    }
}
