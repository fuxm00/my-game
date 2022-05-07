using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class represents barells.
/// Barells explode after certain ammount of time 
/// which is determined by values in _minSeconds and _maxSeconds.
/// Each has blast radius to affect nearby objects and explode force to be apllied to them.
/// Their rotation can by randomized by a bool _isRandomized;
/// </summary>
public class Barell : MonoBehaviour
{
    [Header("Characteristics")]
    [SerializeField] float _blastRadius;
    [SerializeField] float _explodeForce;
    [SerializeField] bool _isRandomized;
    [SerializeField] int _minSeconds = 2;
    [SerializeField] int _maxSeconds = 5;

    [Header("Effect")]
    [SerializeField] GameObject _explosionEffect;

    void Start()
    {
        if(_isRandomized)
        {
            float randomRotation = Random.Range(-90, 90);
            transform.Rotate(0, 0, randomRotation);
        }

        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        float randomSeconds = Random.Range(_minSeconds, _maxSeconds);
        yield return new WaitForSeconds(randomSeconds);

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
