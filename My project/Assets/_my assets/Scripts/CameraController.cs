using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;

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
