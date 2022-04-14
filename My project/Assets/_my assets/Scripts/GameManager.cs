using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] GameObject _playerPrefab;
    [SerializeField] GameObject _playerSpawn;    

    [Header("Joystick")]
    [SerializeField] Joystick _joystick;
    [SerializeField] GameObject _joystickHandle;
    [SerializeField] GameObject _joystickBackgound;

    [Header("Jump Button")]
    [SerializeField] Button _jumpButton;

    [Header("Game Over")]
    [SerializeField] GameObject _gameOverUI;    

    [Header("Coins")]
    [SerializeField] GameObject _coinManager;    

    [Header("CoinUI")]
    [SerializeField] GameObject _coinUI;    

    [Header("Hearts")]
    [SerializeField] GameObject _playerHeartsUI;    

    [Header("Start Game")]
    [SerializeField] GameObject _startGameUI;

    [Header("Ads")]
    [SerializeField] GameObject _AdManager;

    [Header("Level Generator")]
    [SerializeField] GameObject _levelGenerator;

    private bool gameIsRunning;
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
        SetColors();
        PreparePlayer();
        HideControls();
        HideScore();
        gameIsRunning = false;

        playerHealthScript = player.GetComponent<PlayerHealth>();

        playerHeartsUIScript = _playerHeartsUI.GetComponent<PlayerHeartsUI>();
        HideHearts();

        coinManagerScript = _coinManager.GetComponent<CoinManager>();

        coinUIScript = _coinUI.GetComponent<CoinUI>();

        _startGameUI.SetActive(true);

        gameOverUIScript = _gameOverUI.GetComponent<GameOverUI>();

        rewardedAd = _AdManager.GetComponent<RewardedAd>();

        levelGeneratorScript = _levelGenerator.GetComponent<LevelGenerator>();

        playerMovementScript = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsRunning)
        {
            GameOverCheck();
        }
    }

    public void NewGame()
    {
        gameIsRunning = true;
        _gameOverUI.SetActive(false);
        ShowControls();
        playerHealthScript.ResetHealth();
        player.SetActive(true);
        playerHeartsUIScript.RefreshHearts();
        ShowHearts();
        
        coinManagerScript.ResetRecievedCoins();
        coinUIScript.RefreshScore();

        if (_startGameUI.activeInHierarchy == true)
        {
            _startGameUI.SetActive(false);
        }

        if (_playerHeartsUI.activeInHierarchy != true)
        {
            _playerHeartsUI.SetActive(true);
        }

        coinManagerScript.ResetRecievedCoins();
        coinUIScript.RefreshScore();
        ShowScore();

        rewardedAd.LoadAd();

        levelGeneratorScript.ResetLevelParts();

        playerMovementScript.ResetPosition();
    }

    public void GameOver()
    {
        HideControls();
        player.SetActive(false);
        gameIsRunning = false;
        _gameOverUI.SetActive(true);
        HideHearts();
        HideScore();
        coinManagerScript.TransferToTotalCoins(coinManagerScript.CollectedCoins);
        gameOverUIScript.RefreshCoins();
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    private void GameOverCheck()
    {
        if (gameIsRunning)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

            if (playerHealth != null && !playerHealth.IsAlive && gameIsRunning)
            {
                GameOver();
            }
        }
    }

    private void ShowControls()
    {
        Image image = _joystick.gameObject.GetComponent<Image>();
        Image image2 = _joystickHandle.gameObject.GetComponent<Image>();
        Image image3 = _joystickBackgound.gameObject.GetComponent<Image>();
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

        _jumpButton.gameObject.SetActive(true);
    }

    private void HideControls()
    {
        Image image = _joystick.gameObject.GetComponent<Image>();
        Image image2 = _joystickHandle.gameObject.GetComponent<Image>();
        Image image3 = _joystickBackgound.gameObject.GetComponent<Image>();
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

        _jumpButton.gameObject.SetActive(false);
    }

    private void ShowHearts()
    {
        _playerHeartsUI.SetActive(true);
    }

    private void HideHearts()
    {
        _playerHeartsUI.SetActive(false);
    }

    private void SetColors()
    {
        whiteColor = new Color32(255, 255, 255, 255);
        transparentColor = new Color32(0, 0, 0, 0);
        semiTransparentColor = new Color32(0, 0, 0, 70);
    }
    private void PreparePlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.SetActive(false);
    }

    private void ShowScore()
    {
        _coinUI.SetActive(true);
    }

    private void HideScore()
    {
        _coinUI.SetActive(false);
    }
}
