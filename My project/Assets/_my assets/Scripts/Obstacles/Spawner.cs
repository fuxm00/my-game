using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class spawn objects in determined interval by _respawnTime.
/// It spawns them according to player's distance.
/// </summary>
public class Spawner : MonoBehaviour
{
    [Header("Object to Spawn")]
    [SerializeField] GameObject _objectToSpawn;

    [Header("Characteristics")]
    [SerializeField] float _respawnTime;
    [SerializeField] float _playerDistanceToSpawnObject;

    private GameObject _player;
    private GameObject _gameManager;
    private GameManager _gameManagerScript;
    private float _nextSpawnTime;

    /// <summary>
    /// Gets access to certain components on start.
    /// </summary>
    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameMng");
        _gameManagerScript = _gameManager.GetComponent<GameManager>();
        _nextSpawnTime = 0;
    }

    /// <summary>
    /// Spawns certain objects according to players distance
    /// nd spawning frequency on update.
    /// </summary>
    void Update()
    {
        if (_player == null)
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        if (!_gameManagerScript.GameIsRunning)
        {
            return;
        }

        if (Time.time < _nextSpawnTime)
        {
            return;
        }

        Vector2 playerDistance = _player.transform.position;

        if (Vector2.Distance(playerDistance, transform.position) > _playerDistanceToSpawnObject)
        {
            return;
        }

        _nextSpawnTime = Time.time + _respawnTime;
        Instantiate(_objectToSpawn, transform);
    }
}
