using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Parts")]
    [SerializeField] Transform _levelPart_Start;
    [SerializeField] List<Transform> _levelParts;
    [SerializeField] float _playerDistanceToSpawnPart;

    [Header("Player")]
    [SerializeField] GameObject _player;

    [Header("Game Manager")]
    [SerializeField] GameObject _gameManager;

    private GameManager _gameManagerScript;
    private Vector3 _lastEndposition;
    private GameObject[] _currentLevelParts;

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
                SpawnLevelPart();
            }
        }
    }

    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = _levelParts[Random.Range(0, _levelParts.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, _lastEndposition);
        _lastEndposition = lastLevelPartTransform.Find("End Position").position;
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform =  Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
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

    private void InitLevelParts()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnLevelPart();
        }
    }

    private void SetStartPosition()
    {
        _lastEndposition = _levelPart_Start.Find("End Position").position;
    }
}
