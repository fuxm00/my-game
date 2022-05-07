using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class moves by camera according to player's position if there is any.
/// </summary>
public class CameraController : MonoBehaviour
{
    private GameObject _player;

    void Update()
    {
        if (_player == null)
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        if (_player != null && _player.activeInHierarchy == true)
        {
            float x = _player.transform.position.x;
            float y = _player.transform.position.y;
            float z = transform.position.z;

            transform.position = new Vector3(x, y, z);
        }
    }
}
