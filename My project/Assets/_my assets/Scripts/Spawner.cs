using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Object to Spawn")]
    [SerializeField] GameObject objectToSpawn;

    [Header("Characteristics")]
    [SerializeField] float respawnTime = 3f;
    [SerializeField] float playerDistanceToSpawnObject;

    private GameObject player;
    private GameObject gameManager;
    private GameManager gameManagerScript;
    private float nextSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameMng");
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (!gameManagerScript.GameIsRunning)
        {
            return;
        }

        if (Time.time < nextSpawnTime)
        {
            return;
        }

        if (Vector3.Distance(player.transform.position, transform.position) > playerDistanceToSpawnObject)
        {
            return;
        }

        nextSpawnTime = Time.time + respawnTime;
        Instantiate(objectToSpawn, transform);
    }
}
