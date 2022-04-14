using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private PlayerHeartsUI playerHeartsUIScript;

    // Start is called before the first frame update
    void Start()
    {
        _currentPlayerLives = _playerMaxLives;
        if (_currentPlayerLives > 0)
        {
            _isAlive = true;
        } else
        {
            _isAlive = false;
        }

        playerHeartsUIScript = GameObject.FindGameObjectWithTag("hearts").GetComponent<PlayerHeartsUI>();
    }

    public void ResetHealth()
    {
        _currentPlayerLives = _playerMaxLives;
        _isAlive = true;
    }

    public void DamagePlayer(int damagePoints)
    {
        if (_isAlive)
        {
            _currentPlayerLives -= damagePoints;
            playerHeartsUIScript.RefreshHearts();

            if (_currentPlayerLives <= 0)
            {
                Die();
            }
        }
    }

    public void Die()
    {
        _isAlive = false;
    }

    public void IncreaseMaxLives (int amount)
    {
        _playerMaxLives += amount;
    }
}
