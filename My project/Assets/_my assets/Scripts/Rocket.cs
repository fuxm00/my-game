using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [Header("Characteristics")]
    [SerializeField] float rocketSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] bool isHoming;
    [SerializeField] float blastRadius;
    [SerializeField] float explodeForce;

    [Header("Effect")]
    [SerializeField] GameObject explosionEffect;

    private Transform targetTransform;
    private Rigidbody2D rb;

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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (targetTransform != null)
        {
            if (isHoming == true)
            {
                Vector2 desiredDirection = targetTransform.position - gameObject.transform.position;
                Vector2 currentDirection = gameObject.transform.up;

                desiredDirection.Normalize();

                float rotateAmount = Vector3.Cross(desiredDirection, currentDirection).z;

                rb.angularVelocity = rotateAmount * rotationSpeed * -1;
            }
        }

        rb.velocity = transform.up * rocketSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.IsTouchingLayers(7) || collision.gameObject.tag == "Player")
        {
            Explode();
        }
    }

    private void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, blastRadius);

        foreach (Collider2D nearbyObject in colliders)
        {
            Rigidbody2D rb = nearbyObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 direction = nearbyObject.transform.position - transform.position;
                rb.AddForce(direction * explodeForce);
            }

            PlayerHealth health = nearbyObject.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.damagePlayer(1);
            }
        }

        Destroy(gameObject);
    }
}
