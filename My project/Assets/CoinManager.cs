using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int currentCoins;

    public GameObject coinUI;
    private CoinUI coinUIScript;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManager = GameObject.FindGameObjectWithTag("GameMng");
        coinUIScript = coinUI.GetComponent<CoinUI>();
        currentCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeScore(int amount)
    {
        currentCoins += amount;
        coinUIScript.refreshScore();
    }

    public void resetScore()
    {
        currentCoins = 0;
    }
}
