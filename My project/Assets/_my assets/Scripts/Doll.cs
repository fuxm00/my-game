using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll : MonoBehaviour
{
    [Header("Characteristics")]
    public int delay = 5;

    private int currentDelay;

    // Start is called before the first frame update
    void Start()
    {
        currentDelay = delay;
    }

    // Update is called once per frame
    void Update()
    {
        currentDelay--;
        
        if (currentDelay <= 0)
        {
            int randomNumber = Random.Range(0, 20);

            if (randomNumber < 1)
            {
                currentDelay = delay;
                transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            }
        }
        
    }
}
