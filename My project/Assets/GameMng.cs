using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMng : MonoBehaviour
{
    public Joystick joystick;
    public GameObject playerPrefab;
    public GameObject playerSpawn;
    private GameObject player;
    private PlayerHealth playerHealth;
    public GameObject gameOverUI;
    private bool gameIsRunning;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.SetActive(false);
        gameIsRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (gameIsRunning)
        {
            gameOverCheck();
        }
    }

    public void newGame()
    {
        gameIsRunning = true;
        gameOverUI.SetActive(false);
        joystick.gameObject.SetActive(true);
        playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth.resetHealth();
        player.SetActive(true);
        player.GetComponent<PlayerHealth>().resetHealth();
    }

    public void gameOver()
    {
        joystick.gameObject.SetActive(false);
        player.SetActive(false);
        gameIsRunning = false;

        gameOverUI.SetActive(true);
    }

    public void quitApp()
    {
        Application.Quit();
    }

    private void gameOverCheck()
    {
        if (gameIsRunning)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

            if (playerHealth != null && !playerHealth.isAlive && gameIsRunning)
            {
                gameOver();
            }
        }
    }
}
