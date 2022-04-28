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

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameMng");
        _gameManagerScript = _gameManager.GetComponent<GameManager>();
        _nextSpawnTime = 0;
    }

    // Update is called once per frame
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

        if (Vector3.Distance(_player.transform.position, transform.position) > _playerDistanceToSpawnObject)
        {
            return;
        }

        _nextSpawnTime = Time.time + _respawnTime;
        Instantiate(_objectToSpawn, transform);
    }
}
