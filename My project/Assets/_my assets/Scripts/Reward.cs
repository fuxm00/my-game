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
            FindObjectOfType<AudioManager>().play("Coin");
            _scoreMng.GiveCollectedCoins(_coinReward);
            Destroy(gameObject);
        }

    }
}
