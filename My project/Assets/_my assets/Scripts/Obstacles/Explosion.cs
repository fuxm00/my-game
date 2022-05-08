using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class plays explosion sound effect and destroys self in 2 seconds.
/// </summary>
public class Explosion : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Explosion");
        StartCoroutine(DestroySelf());
    }
    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
