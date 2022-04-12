using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Player")]
    public GameObject playerPrefab;
    public GameObject playerSpawn;
    private GameObject player;
    private PlayerHealth playerHealthScript;

    [Header("Joystick")]
    public Joystick joystick;
    public GameObject joystickHandle;
    public GameObject joystickBackgound;

    [Header("Game Over")]
    public GameObject gameOverUI;
    private GameOverUI gameOverUIScript;

    [Header("Coins")]
    public GameObject coinManager;
    private CoinManager coinManagerScript;

    [Header("CoinUI")]
    public GameObject coinUI;
    private CoinUI coinUIScript;

    [Header("Hearts")]
    public GameObject playerHearts;
    private PlayerHeartsUI playerHeartsUIScript;

    [Header("Start Game")]
    public GameObject startGameUI;

    [Header("Ads")]
    public GameObject AdManager;
    public RewardedAd rewardedAd;

    [Header("Level Generator")]
    public GameObject levelGenerator;
    private LevelGenerator levelGeneratorScript;

    private Color32 whiteColor;
    private Color32 transparentColor;
    private Color32 semiTransparentColor;

    private bool gameIsRunning;

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

        coinManagerScript = coinManager.GetComponent<CoinManager>();

        coinUIScript = coinUI.GetComponent<CoinUI>();

        startGameUI.SetActive(true);

        gameOverUIScript = gameOverUI.GetComponent<GameOverUI>();

        rewardedAd = AdManager.GetComponent<RewardedAd>();

        levelGeneratorScript = levelGenerator.GetComponent<LevelGenerator>();
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
        
        coinManagerScript.resetRecievedCoins();
        coinUIScript.refreshScore();

        if (startGameUI.activeInHierarchy == true)
        {
            startGameUI.SetActive(false);
        }

        if (playerHearts.activeInHierarchy != true)
        {
            playerHearts.SetActive(true);
        }

        //reset score
        coinManagerScript.resetRecievedCoins();
        //refresh score
        coinUIScript.refreshScore();
        //show score
        showScore();

        rewardedAd.LoadAd();

        levelGeneratorScript.resetLevelParts();        
    }

    public void gameOver()
    {
        hideJoystick();
        player.SetActive(false);
        gameIsRunning = false;
        gameOverUI.SetActive(true);
        hideHearts();
        hideScore();
        coinManagerScript.transferToTotalCoins(coinManagerScript.collectedCoins);
        gameOverUIScript.refreshCoins();
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
        coinUI.SetActive(true);
    }

    private void hideScore()
    {
        coinUI.SetActive(false);
    }
}
