using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Parts")]
    [SerializeField] Transform _levelPart_Start;
    [SerializeField] List<Transform> _levelParts;
    [SerializeField] float _playerDistanceToSpawnPart;
    [SerializeField] float _playerDistanceToDestroyPart;

    [Header("Player")]
    [SerializeField] GameObject _player;

    [Header("Game Manager")]
    [SerializeField] GameObject _gameManager;

    [Header("Characteristics")]
    [Range(1, 50)]
    [SerializeField] int _levelPartsToPrepare;

    private GameManager _gameManagerScript;
    private Vector3 _lastEndposition;
    private GameObject[] _currentLevelParts;
    private int _currentLevelPartNumber;
    private int _nextLevelPartNumber;

    // Start is called before the first frame update
    void Start()
    {
        _gameManagerScript = _gameManager.GetComponent<GameManager>();

        SetStartPosition();   
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameManagerScript.GameIsRunning)
        {
            if (Vector3.Distance(_player.transform.position, _lastEndposition) < _playerDistanceToSpawnPart)
            {
                SpawnNextLevelPart();
            }

            DestroyDistantLevelParts();
        }
    }

    private void SpawnFirstLevelPart()
    {
        _currentLevelPartNumber = Random.Range(0, _levelParts.Count);

        SpawnLevelPart(_currentLevelPartNumber);
    }

    private void SpawnNextLevelPart()
    {
        _nextLevelPartNumber = Random.Range(0, _levelParts.Count);

        while (_currentLevelPartNumber == _nextLevelPartNumber)
        {
            _nextLevelPartNumber = Random.Range(0, _levelParts.Count);
        }

        SpawnLevelPart(_nextLevelPartNumber);

        _currentLevelPartNumber = _nextLevelPartNumber;
    }

    private void SpawnLevelPart (int spawnNumber)
    {
        Transform chosenLevelPart = _levelParts[spawnNumber];
        Transform lastLevelPartTransform = Instantiate(chosenLevelPart, _lastEndposition, Quaternion.identity);
        _lastEndposition = lastLevelPartTransform.Find("End Position").position;
    }

    public void ResetLevelParts()
    {
        _currentLevelParts = GameObject.FindGameObjectsWithTag("LevelPart");

        foreach (GameObject levelPart in _currentLevelParts)
        {
            Destroy(levelPart);
        }

        SetStartPosition();

        InitLevelParts();
    }

    private void DestroyDistantLevelParts()
    {
        _currentLevelParts = GameObject.FindGameObjectsWithTag("LevelPart");

        foreach (GameObject levelPart in _currentLevelParts)
        {
            if (Vector3.Distance(_player.transform.position, levelPart.transform.position) > _playerDistanceToDestroyPart)
            {
                Destroy(levelPart);
            }
        }
    }

    private void InitLevelParts()
    {
        SpawnFirstLevelPart();

        for (int i = 0; i < _levelPartsToPrepare - 1; i++)
        {
            SpawnNextLevelPart();
        }
    }

    private void SetStartPosition()
    {
        _lastEndposition = _levelPart_Start.Find("End Position").position;
    }
}
