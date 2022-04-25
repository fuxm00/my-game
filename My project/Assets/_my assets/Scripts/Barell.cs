using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barell : MonoBehaviour
{
    [Header("Characteristics")]
    [SerializeField] float _blastRadius;
    [SerializeField] float _explodeForce;
    [SerializeField] bool _isRandomised;

    [Header("Effect")]
    [SerializeField] GameObject _explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        if(_isRandomised)
        {
            float randomRotation = Random.Range(-90, 90);
            transform.Rotate(0, 0, randomRotation);
        }

        StartCoroutine(Explode());

    }

    IEnumerator Explode()
    {
        float randomSeconds = Random.Range(2, 5);
        yield return new WaitForSeconds(randomSeconds);

        Instantiate(_explosionEffect, transform.position, transform.rotation);

        Collider2D[] nearbyObjects = Physics2D.OverlapCircleAll(transform.position, _blastRadius);

        foreach (Collider2D nearbyObject in nearbyObjects)
        {
            Rigidbody2D rb = nearbyObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 direction = nearbyObject.transform.position - transform.position;
                rb.AddForce(direction * _explodeForce);
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
