using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barell : MonoBehaviour
{

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
        //TODO efekt výbuchu
        StartCoroutine(Explode());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }

    IEnumerator Explode()
    {
        float randomSeconds = Random.Range(2, 4);
        yield return new WaitForSeconds(randomSeconds);
        dealDamage();
        Destroy(gameObject);
    }

    private void dealDamage()
    {

    }
}
