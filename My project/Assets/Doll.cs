using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int randomNumber = Random.Range(0, 20);
        if (randomNumber < 1)
        {
            Debug.Log("flip");
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
    }
}
