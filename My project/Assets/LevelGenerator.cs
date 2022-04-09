using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Transform levelPart_Start;
    public List<Transform> levelParts;

    private Vector3 lastEndposition;
    public float playerDistanceToSpawnPart;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        lastEndposition = levelPart_Start.Find("End Position").position;
        SpawnLevelPart();
        SpawnLevelPart();
        SpawnLevelPart();

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, lastEndposition) < playerDistanceToSpawnPart)
        {
            SpawnLevelPart();
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
}
