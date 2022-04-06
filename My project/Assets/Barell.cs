using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barell : MonoBehaviour
{

    public GameObject explosionEffect;
    public float blastRadius;
    public float explodeForce;

    // Start is called before the first frame update
    void Start()
    {
        float randomRotation = Random.Range(-90, 90);
        transform.Rotate(0, 0, randomRotation);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Explode());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    IEnumerator Explode()
    {
        float randomSeconds = Random.Range(2, 4);
        yield return new WaitForSeconds(randomSeconds);

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
            if (health != null) {

                if (health.currentPlayerLives > 0)
                {
                    health.damagePlayer(1);
                }
                
            }
        }
        
        dealDamage();
        Destroy(gameObject);
    }

    private void dealDamage()
    {

    }
}
