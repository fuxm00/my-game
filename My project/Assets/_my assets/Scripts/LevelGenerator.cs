using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Parts")]
    [SerializeField] Transform levelPart_Start;
    [SerializeField] List<Transform> levelParts;
    [SerializeField] float playerDistanceToSpawnPart;

    [Header("Player")]
    [SerializeField] GameObject player;

    [Header("Game Manager")]
    [SerializeField] GameObject gameManager;

    private GameManager gameManagerScript;
    private Vector3 lastEndposition;
    private GameObject[] currentLevelParts;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManager>();

        setStartPosition();   
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.GameIsRunning)
        {
            if (Vector3.Distance(player.transform.position, lastEndposition) < playerDistanceToSpawnPart)
            {
                SpawnLevelPart();
            }
        }
    }

    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelParts[Random.Range(0, levelParts.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndposition);
        lastEndposition = lastLevelPartTransform.Find("End Position").position;
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform =  Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }

    public void resetLevelParts()
    {
        currentLevelParts = GameObject.FindGameObjectsWithTag("LevelPart");

        foreach (GameObject levelPart in currentLevelParts)
        {
            Destroy(levelPart);
        }

        setStartPosition();

        initLevelParts();
    }

    private void initLevelParts()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnLevelPart();
        }
    }

    private void setStartPosition()
    {
        lastEndposition = levelPart_Start.Find("End Position").position;
    }
}
