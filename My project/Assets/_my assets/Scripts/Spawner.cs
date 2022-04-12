using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Object to Spawn")]
    public GameObject objectToSpawn;

    [Header("Game Manager")]
    public GameObject gameManager;
    private GameManager gameManagerScript;

    [Header("Characteristics")]
    public float respawnTime = 3f;
    public float playerDistanceToSpawnObject;

    [Header("Player")]
    public GameObject player;
    private Rigidbody2D rb;

    private float nextSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManager>();
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManagerScript.gameIsRunning)
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

    private void FixedUpdate()
    {
        
    }
}
