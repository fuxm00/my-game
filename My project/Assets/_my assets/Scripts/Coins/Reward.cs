using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class represents coins in game. Each coin has some reward
/// and sounds according to it's reward.
/// </summary>
public class Reward : MonoBehaviour
{
    [Header("Reward")]
    [SerializeField] int _coinReward;

    private CoinManager _scoreManager;

    void Start()
    {
        _scoreManager = GameObject.FindGameObjectWithTag("ScoreMng").GetComponent<CoinManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioManager audioManager = FindObjectOfType<AudioManager>();

            if (_coinReward == 1)
            {
                audioManager.Play("Coin1");
            } else if ( _coinReward <=5) 
            {
                audioManager.Play("Coin2");
            } else if (_coinReward <=10)
            {
                audioManager.Play("Coin3");
            } else {
                audioManager.Play("Coin3");
            }

            _scoreManager.GiveCollectedCoins(_coinReward);
            Destroy(gameObject);
        }
    }
}
