using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Player")]
    public GameObject playerPrefab;
    public GameObject playerSpawn;

    [Header("Joystick")]
    public Joystick joystick;
    public GameObject joystickHandle;
    public GameObject joystickBackgound;

    private GameObject player;
    private PlayerHealth playerHealthScript;

    [Header("Game Over")]
    public GameObject gameOverUI;


    [Header("Score")]
    public GameObject scoreManager;
    private ScoreManager scoreManagerScript;

    [Header("scoreUI")]
    public GameObject scoreUI;
    private ScoreUI scoreUIScript;

    [Header("Hearts")]
    public GameObject playerHearts;
    private PlayerHeartsUI playerHeartsUIScript;

    [Header("Start Game")]
    public GameObject startGameUI;

    private Color32 whiteColor;
    private Color32 transparentColor;
    private Color32 semiTransparentColor;

    [Header("Else")]
    public bool gameIsRunning;

    // Start is called before the first frame update
    void Start()
    {
        setColors();
        preparePlayer();
        hideJoystick();
        hideScore();
        gameIsRunning = false;

        playerHealthScript = player.GetComponent<PlayerHealth>();

        playerHeartsUIScript = playerHearts.GetComponent<PlayerHeartsUI>();
        hideHearts();

        scoreManagerScript = scoreManager.GetComponent<ScoreManager>();

        scoreUIScript = scoreUI.GetComponent<ScoreUI>();

        startGameUI.SetActive(true);

    }

    // Update is called once per frame
    void Update()
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
        playerHealthScript.resetHealth();
        player.SetActive(true);
        playerHeartsUIScript.refreshHearts();
        showHearts();
        
        scoreManagerScript.resetScore();
        scoreUIScript.refreshScore();

        if (startGameUI.activeInHierarchy == true)
        {
            startGameUI.SetActive(false);
        }

        if (playerHearts.activeInHierarchy != true)
        {
            playerHearts.SetActive(true);
        }

        //reset score
        scoreManagerScript.resetScore();
        //refresh score
        scoreUIScript.refreshScore();
        //show score
        showScore();
        
    }

    public void gameOver()
    {
        hideJoystick();
        player.SetActive(false);
        gameIsRunning = false;
        gameOverUI.SetActive(true);
        hideHearts();
        //hide score
        hideScore();
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

    private void showJoystick()
    {
        Image image = joystick.gameObject.GetComponent<Image>();
        Image image2 = joystickHandle.gameObject.GetComponent<Image>();
        Image image3 = joystickBackgound.gameObject.GetComponent<Image>();
        if (image != null)
        {
            image.color = whiteColor;
        }
        if (image2 != null)
        {
            image2.color = whiteColor;
        }
        if (image3 != null)
        {
            image3.color = semiTransparentColor;
        }

    }

    private void hideJoystick()
    {
        Image image = joystick.gameObject.GetComponent<Image>();
        Image image2 = joystickHandle.gameObject.GetComponent<Image>();
        Image image3 = joystickBackgound.gameObject.GetComponent<Image>();
        if (image != null)
        {
            image.color = transparentColor;
        }
        if (image2 != null)
        {
            image2.color = transparentColor;
        }
        if (image3 != null)
        {
            image3.color = transparentColor;
        }
    }

    private void showHearts()
    {
        playerHearts.SetActive(true);
    }

    private void hideHearts()
    {
        playerHearts.SetActive(false);
    }

    private void setColors()
    {
        whiteColor = new Color32(255, 255, 255, 255);
        transparentColor = new Color32(0, 0, 0, 0);
        semiTransparentColor = new Color32(0, 0, 0, 70);
    }
    private void preparePlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.SetActive(false);
    }

    private void showScore()
    {
        scoreUI.SetActive(true);
    }

    private void hideScore()
    {
        scoreUI.SetActive(false);
    }
}
