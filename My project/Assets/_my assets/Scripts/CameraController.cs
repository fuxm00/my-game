using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject _player;

    // Update is called once per frame
    void Update()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        if (_player != null && _player.activeInHierarchy == true)
        {
            transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, transform.position.z);

        }
    }
}
