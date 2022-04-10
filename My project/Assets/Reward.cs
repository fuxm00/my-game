using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{
    public int coinReward;
    private CoinManager scoreMng;

    // Start is called before the first frame update
    void Start()
    {
        scoreMng = GameObject.FindGameObjectWithTag("ScoreMng").GetComponent<CoinManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            scoreMng.changeScore(coinReward);
            Destroy(gameObject);
        }
    }
}
