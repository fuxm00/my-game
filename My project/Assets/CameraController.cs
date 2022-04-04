using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public GameObject TargetToFollow;
    public Vector3 TargetPosition;
    public bool hasTarget;

    // Start is called before the first frame update
    void Start()
    {
        hasTarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null && player.activeInHierarchy == true)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        }
    }
}
