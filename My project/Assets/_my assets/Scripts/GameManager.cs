using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

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

    void Start()
    {
        PreparePlayer();
        HideControls();
        HideScore();
        _gameIsRunning = false;
        _playerHealthScript = _player.GetComponent<PlayerHealth>();
        HideHearts();
        _coinManagerScript = _coinManager.GetComponent<CoinManager>();
        _startGameUI.SetActive(true);
        _rewardedAd = _adManager.GetComponent<RewardedAd>();
        _levelGeneratorScript = _levelGenerator.GetComponent<LevelGenerator>();
        _playerMovementScript = _player.GetComponent<PlayerMovement>();
        _jumpButtonScript = _jumpButton.GetComponent<JumpButton>();
    }

    void Update()
    {
        if (_gameIsRunning)
        {
            GameOverCheck();
        }
    }

    public void NewGame()
    {
        _gameIsRunning = true;
        _gameOverUI.SetActive(false);
        ShowControls();
        _player.SetActive(true);
        _playerHealthScript.ResetHealth();
        ShowHearts();
        
        _coinManagerScript.ResetRecievedCoins();

        if (_startGameUI.activeInHierarchy == true)
        {
            _startGameUI.SetActive(false);
        }

        if (_playerHeartsUI.activeInHierarchy != true)
        {
            _playerHeartsUI.SetActive(true);
        }

        ShowScore();
        _rewardedAd.LoadAd();
        _levelGeneratorScript.ResetLevelParts();
        _playerMovementScript.ResetPosition();
    }

    public void GameOver()
    {
        HideControls();
        _player.SetActive(false);
        _gameIsRunning = false;
        _gameOverUI.SetActive(true);
        HideHearts();
        HideScore();
        _coinManagerScript.TransferToTotalCoins(_coinManagerScript.CollectedCoins);
        OnGameOver?.Invoke();
    }

    public void QuitApp()
    {
        Application.Quit();
    }

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

    private void ShowControls()
    {
        Image image = _joystick.gameObject.GetComponent<Image>();
        Image image2 = _joystickHandle.gameObject.GetComponent<Image>();
        Image image3 = _joystickBackgound.gameObject.GetComponent<Image>();
        if (image != null)
        {
            image.color = Colors.White;
        }
        if (image2 != null)
        {
            image2.color = Colors.White;
        }
        if (image3 != null)
        {
            image3.color = Colors.SemiTransparent;
        }

        _jumpButton.gameObject.SetActive(true);
        _jumpButtonScript.IsPressed = false;
    }

    private void HideControls()
    {
        Image image = _joystick.gameObject.GetComponent<Image>();
        Image image2 = _joystickHandle.gameObject.GetComponent<Image>();
        Image image3 = _joystickBackgound.gameObject.GetComponent<Image>();
        if (image != null)
        {
            image.color = Colors.Transparent;
        }
        if (image2 != null)
        {
            image2.color = Colors.Transparent;
        }
        if (image3 != null)
        {
            image3.color = Colors.Transparent;
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
    private void PreparePlayer()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _player.SetActive(false);
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
