using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int currentCoins;
    public int totalCoins;

    public GameObject coinUI;
    private CoinUI coinUIScript;

    // Start is called before the first frame update
    void Start()
    {
        coinUIScript = coinUI.GetComponent<CoinUI>();
        currentCoins = 0;
        //totalcoins ze souboru
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void giveCurrentCoins(int amount)
    {
        currentCoins += amount;
        coinUIScript.refreshScore();
    }

    public void transferToTotalCoins()
    {
        totalCoins += currentCoins;
    }

    public void resetCurrentCoins()
    {
        currentCoins = 0;
    }
}
