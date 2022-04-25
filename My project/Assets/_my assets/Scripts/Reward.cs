using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{
    [Header("Reward")]
    [SerializeField] int _coinReward;
    private CoinManager _scoreMng;

    // Start is called before the first frame update
    void Start()
    {
        _scoreMng = GameObject.FindGameObjectWithTag("ScoreMng").GetComponent<CoinManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioManager audioManager = FindObjectOfType<AudioManager>();

            if (_coinReward <= 1)
            {
                audioManager.play("Coin1");
            } else if ( _coinReward <=5) 
            {
                audioManager.play("Coin2");
            } else if (_coinReward <=10)
            {
                audioManager.play("Coin3");
            } else {
                audioManager.play("Coin3");
            }

            _scoreMng.GiveCollectedCoins(_coinReward);
            Destroy(gameObject);
        }
    }
}
