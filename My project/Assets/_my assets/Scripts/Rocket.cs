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

    private Transform targetTransform;
    private Rigidbody2D rb;
    private float _timeToExplode;

    // Start is called before the first frame update
    void Start()
    {
        if (targetTransform == null)
        {
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
            }
            
        }

        rb = GetComponent<Rigidbody2D>();

        _timeToExplode = Time.time + _timeDelayToExplode;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.time < _timeToExplode)
        {
            return;
        }
        
        Explode();
    }

    void FixedUpdate()
    {
        if (targetTransform != null)
        {
            if (_isHoming == true)
            {
                Vector2 desiredDirection = targetTransform.position - gameObject.transform.position;
                Vector2 currentDirection = gameObject.transform.up;

                desiredDirection.Normalize();

                float rotateAmount = Vector3.Cross(desiredDirection, currentDirection).z;

                rb.angularVelocity = rotateAmount * _rotationSpeed * -1;
            }
        }

        rb.velocity = transform.up * _rocketSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Player")
        {
            Explode();
        }
    }

    private void Explode()
    {
        Instantiate(_explosionEffect, transform.position, transform.rotation);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _blastRadius);

        foreach (Collider2D nearbyObject in colliders)
        {
            Rigidbody2D rb = nearbyObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 direction = nearbyObject.transform.position - transform.position;
                rb.AddForce(direction * _explodeForce);
            }

            PlayerHealth health = nearbyObject.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.DamagePlayer(1);
            }
        }

        Destroy(gameObject);
    }
}
