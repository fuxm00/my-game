using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [Header("Lives")]
    [SerializeField] int _playerMaxLives;
    public int PlayerMaxLives
    {
        get
        {
            return _playerMaxLives;
        }
    }

    private int _currentPlayerLives;
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

    [Header("Is Alive")]
    private bool _isAlive;
    public bool IsAlive
    {
        get
        {
            return _isAlive;
        }
    }

    [SerializeField] UnityEvent OnHealthChange;

    // Start is called before the first frame update
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

    public void ResetHealth()
    {
        CurrentPlayerLives = _playerMaxLives;
        _isAlive = true;
    }

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

    public void Die()
    {
        FindObjectOfType<AudioManager>().Play("Hurt");
        _isAlive = false;
    }

    public void IncreaseMaxLives (int amount)
    {
        _playerMaxLives += amount;
        OnHealthChange?.Invoke();
    }
}
