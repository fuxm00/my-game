using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{
    [Header("Reward")]
    [SerializeField] int coinReward;
    private CoinManager scoreMng;

    // Start is called before the first frame update
    void Start()
    {
        scoreMng = GameObject.FindGameObjectWithTag("ScoreMng").GetComponent<CoinManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            scoreMng.giveCollectedCoins(coinReward);
            Destroy(gameObject);
        }
    }
}
