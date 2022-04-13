using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject playerSpawn;    

    [Header("Joystick")]
    [SerializeField] Joystick joystick;
    [SerializeField] GameObject joystickHandle;
    [SerializeField] GameObject joystickBackgound;

    [Header("Game Over")]
    [SerializeField] GameObject gameOverUI;    

    [Header("Coins")]
    [SerializeField] GameObject coinManager;    

    [Header("CoinUI")]
    [SerializeField] GameObject coinUI;    

    [Header("Hearts")]
    [SerializeField] GameObject playerHearts;    

    [Header("Start Game")]
    [SerializeField] GameObject startGameUI;

    [Header("Ads")]
    [SerializeField] GameObject AdManager;

    [Header("Level Generator")]
    [SerializeField] GameObject levelGenerator;

    [SerializeField] bool gameIsRunning;
    public bool GameIsRunning
    {
        get
        {
            return gameIsRunning;
        }
    }

    private GameObject player;
    private PlayerHealth playerHealthScript;
    private PlayerMovement playerMovementScript;
    private GameOverUI gameOverUIScript;
    private CoinManager coinManagerScript;
    private PlayerHeartsUI playerHeartsUIScript;
    private CoinUI coinUIScript;
    private Color32 whiteColor;
    private Color32 transparentColor;
    private Color32 semiTransparentColor;
    private LevelGenerator levelGeneratorScript;
    private RewardedAd rewardedAd;




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

        playerMovementScript = player.GetComponent<PlayerMovement>();
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

        coinManagerScript.resetRecievedCoins();
        coinUIScript.refreshScore();
        showScore();

        rewardedAd.LoadAd();

        levelGeneratorScript.resetLevelParts();

        playerMovementScript.resetPosition();
    }

    public void gameOver()
    {
        hideJoystick();
        player.SetActive(false);
        gameIsRunning = false;
        gameOverUI.SetActive(true);
        hideHearts();
        hideScore();
        coinManagerScript.transferToTotalCoins(coinManagerScript.CollectedCoins);
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

            if (playerHealth != null && !playerHealth.IsAlive && gameIsRunning)
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
