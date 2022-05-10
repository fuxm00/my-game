using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class tracks player's health. Keeps record
/// whether he is alive and manages his current and max health.
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    [Header("Lives")]
    [SerializeField] int _playerMaxLives;

    private int _currentPlayerLives;
    private bool _isAlive;

    [SerializeField] UnityEvent OnHealthChange;

    public int PlayerMaxLives
    {
        get
        {
            return _playerMaxLives;
        }
    }
    public int CurrentPlayerLives
    {
        get
        {
            return _currentPlayerLives;
        }
        private set
        {
            _currentPlayerLives = value;
            OnHealthChange?.Invoke();
        }
    }
    public bool IsAlive
    {
        get
        {
            return _isAlive;
        }
    }

    /// <summary>
    /// Checks whether the extra heart has been bought,
    /// sets current lives and checks whether he is alive.
    /// </summary>
    void Start()
    {
        if (PlayerPrefs.GetInt("ExtraHeartIsBought") == 1)
        {
            IncreaseMaxLives(1);
        }

        CurrentPlayerLives = _playerMaxLives;

        if (_currentPlayerLives > 0)
        {
            _isAlive = true;
        }
        else
        {
            _isAlive = false;
        }
    }

    /// <summary>
    /// Reset current lives to default value.
    /// </summary>
    public void ResetHealth()
    {
        CurrentPlayerLives = _playerMaxLives;
        _isAlive = true;
    }

    /// <summary>
    /// Damages player lives.
    /// </summary>
    /// <param name="damagePoints">
    /// damaged value
    /// </param>
    public void DamagePlayer(int damagePoints)
    {
        if (_isAlive)
        {
            CurrentPlayerLives -= damagePoints;
            FindObjectOfType<AudioManager>().Play("Hurt");

            if (_currentPlayerLives <= 0)
            {
                Die();
            }
        }
    }

    /// <summary>
    /// Makes player die.
    /// </summary>
    public void Die()
    {
        FindObjectOfType<AudioManager>().Play("Hurt");
        _isAlive = false;
    }

    /// <summary>
    /// Increases player's default amount of lives.
    /// </summary>
    /// <param name="amount">
    /// amount of lives to be added
    /// </param>
    public void IncreaseMaxLives (int amount)
    {
        _playerMaxLives += amount;
        OnHealthChange?.Invoke();
    }
}
