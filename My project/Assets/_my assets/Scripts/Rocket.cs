using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [Header("Characteristics")]
    public float rocketSpeed;
    public float rotationSpeed;
    public bool isHoming;

    [Header("Target")]
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
        Destroy(this.gameObject);
    }
}
