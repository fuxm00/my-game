using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameMng");
        _gameManagerScript = _gameManager.GetComponent<GameManager>();
        _nextSpawnTime = 0;
    }

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
