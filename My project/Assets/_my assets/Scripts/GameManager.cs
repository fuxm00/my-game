using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/// <summary>
/// This class manages game. The class can start or end the game
/// and shows and hides certain UI elemets.
/// </summary>
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
    [SerializeField] GameObject _adManager;

    [Header("Level Generator")]
    [SerializeField] GameObject _levelGenerator;

    private bool _gameIsRunning;
    private GameObject _player;
    private PlayerHealth _playerHealthScript;
    private PlayerMovement _playerMovementScript;
    private CoinManager _coinManagerScript;
    private LevelGenerator _levelGeneratorScript;
    private RewardedAd _rewardedAd;
    private JumpButton _jumpButtonScript;

    [SerializeField] UnityEvent OnGameOver;

    public bool GameIsRunning
    {
        get
        {
            return _gameIsRunning;
        }
    }

    /// <summary>
    /// Prepares player, fields, prepares wanted UI elements 
    /// and gets acces to certain components on start.
    /// </summary>
    void Start()
    {
        PreparePlayer();
        ShowControls(false);
        ShowScore(false);
        _gameIsRunning = false;
        _playerHealthScript = _player.GetComponent<PlayerHealth>();
        ShowHearts(false);
        _coinManagerScript = _coinManager.GetComponent<CoinManager>();
        _startGameUI.SetActive(true);
        _rewardedAd = _adManager.GetComponent<RewardedAd>();
        _levelGeneratorScript = _levelGenerator.GetComponent<LevelGenerator>();
        _playerMovementScript = _player.GetComponent<PlayerMovement>();
        _jumpButtonScript = _jumpButton.GetComponent<JumpButton>();
    }

    /// <summary>
    /// Checks whether the game has ended on update.
    /// </summary>
    void Update()
    {
        if (_gameIsRunning)
        {
            GameOverCheck();
        }
    }

    /// <summary>
    /// Starts new game.
    /// </summary>
    public void NewGame()
    {
        _gameIsRunning = true;
        _gameOverUI.SetActive(false);
        ShowControls(true);
        _player.SetActive(true);
        _playerHealthScript.ResetHealth();
        ShowHearts(true);
        
        _coinManagerScript.ResetRecievedCoins();

        if (_startGameUI.activeInHierarchy == true)
        {
            _startGameUI.SetActive(false);
        }

        if (_playerHeartsUI.activeInHierarchy != true)
        {
            _playerHeartsUI.SetActive(true);
        }

        ShowScore(true);
        _rewardedAd.LoadAd();
        _levelGeneratorScript.ResetLevelParts();
        _playerMovementScript.ResetPosition();
    }

    /// <summary>
    /// Ends a game.
    /// </summary>
    public void GameOver()
    {
        ShowControls(false);
        _player.SetActive(false);
        _gameIsRunning = false;
        _gameOverUI.SetActive(true);
        ShowHearts(false);
        ShowScore(false);
        _coinManagerScript.TransferToTotalCoins(_coinManagerScript.CollectedCoins);
        OnGameOver?.Invoke();
    }

    /// <summary>
    /// Exits a game completely.
    /// </summary>
    public void QuitApp()
    {
        Application.Quit();
    }

    /// <summary>
    /// Checks whether the game has ended and ends it if so.
    /// </summary>
    private void GameOverCheck()
    {
        if (_gameIsRunning)
        {
            PlayerHealth playerHealth = _player.GetComponent<PlayerHealth>();

            if (playerHealth != null && !playerHealth.IsAlive && _gameIsRunning)
            {
                GameOver();
            }
        }
    }

    /// <summary>
    /// Shows or hides controls
    /// </summary>
    /// <param name="show">
    /// whether the controls shouhld be displayed or not
    /// </param>
    private void ShowControls(bool toShow)
    {
        Image image = _joystick.gameObject.GetComponent<Image>();
        Image image2 = _joystickHandle.gameObject.GetComponent<Image>();
        Image image3 = _joystickBackgound.gameObject.GetComponent<Image>();

        Color32 borderColor;
        Color32 handleColor;
        Color32 backGroundColor;

        if (toShow)
        {
            borderColor = Colors.White;
            handleColor = Colors.White;
            backGroundColor = Colors.SemiTransparent;

            _jumpButtonScript.IsPressed = false;
        } else
        {
            borderColor = Colors.Transparent;
            handleColor = Colors.Transparent;
            backGroundColor = Colors.Transparent;
        }        

        if (image != null)
        {
            image.color = borderColor;
        }
        if (image2 != null)
        {
            image2.color = handleColor;
        }
        if (image3 != null)
        {
            image3.color = backGroundColor;
        }

        _jumpButton.gameObject.SetActive(toShow);
    }

    /// <summary>
    /// Shows or hides player's hearts.
    /// </summary>
    /// <param name="toShow">
    /// whether the hearts should be displayed or not
    /// </param>
    private void ShowHearts(bool toShow)
    {
        _playerHeartsUI.SetActive(toShow);
    }

    /// <summary>
    /// Prepares player for game.
    /// </summary>
    private void PreparePlayer()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _player.SetActive(false);
    }

    /// <summary>
    /// Shows or hides score.
    /// </summary>
    /// <param name="toShow">
    /// whether the score should be displayed or not
    /// </param>
    private void ShowScore(bool toShow)
    {
        _coinUI.SetActive(toShow);
    }
}
