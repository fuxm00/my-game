using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float rocketSpeed;
    public float rotationSpeed;
    public bool isHoming;
    public Transform target;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                target = GameObject.FindGameObjectWithTag("Player").transform;
            }
            
        }

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {
            if (isHoming == true)
            {
                Vector2 desiredDirection = target.position - gameObject.transform.position;
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
        Destroy(this.gameObject);
    }
}
