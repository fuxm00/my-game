using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class displays current player's health in form of hearts.
/// </summary>

public class PlayerHeartsUI : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] GameObject _player;

    [Header("Hearts")]
    [SerializeField] GameObject[] _playerHearts;

    private PlayerHealth _playerHealth;

    /// <summary>
    /// Refreshes player's lives.
    /// </summary>
    public void RefreshHearts()
    {
        _playerHealth = _player.GetComponent<PlayerHealth>();

        foreach (GameObject heart in _playerHearts)
        {
            heart.SetActive(false);
        }

        for (int i = 0; i < _playerHealth.CurrentPlayerLives; i++)
        {
            _playerHearts[i].SetActive(true);
        }
    }
}
