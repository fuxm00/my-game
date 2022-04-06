using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMng : MonoBehaviour
{
    public Joystick joystick;
    public GameObject joystickHandle;
    public GameObject playerPrefab;
    public GameObject playerSpawn;
    private GameObject player;
    private PlayerHealth playerHealth;
    public GameObject gameOverUI;
    private bool gameIsRunning;

    public Color32 whiteColor;
    public Color32 transparentColor;

    // Start is called before the first frame update
    void Start()
    {
        whiteColor = new Color32(255, 255, 255, 255);
        transparentColor =  new Color32(0, 0, 0, 0);
        player = GameObject.FindGameObjectWithTag("Player");
        player.SetActive(false);
        gameIsRunning = false;
        hideJoystick();
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
        showJoystick();
        playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth.resetHealth();
        player.SetActive(true);
        
    }

    public void gameOver()
    {
        hideJoystick();
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

    private void hideJoystick()
    {
        Image image = joystick.gameObject.GetComponent<Image>();
        Image image2 = joystickHandle.gameObject.GetComponent<Image>();
        if (image != null) {
            image.color = transparentColor;
        }
        if (image != null)
        {
            image2.color = transparentColor;
        }
    }

    private void showJoystick()
    {
        Image image = joystick.gameObject.GetComponent<Image>();
        Image image2 = joystickHandle.gameObject.GetComponent<Image>();
        if (image != null)
        {
            image.color = whiteColor;
        }
        if (image != null)
        {
            image2.color = whiteColor;
        }
    }
}
