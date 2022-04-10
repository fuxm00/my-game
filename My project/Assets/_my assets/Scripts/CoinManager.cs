using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int collectedCoins;
    public int adBonusCoins;
    public int totalCoins;

    public GameObject coinUI;
    private CoinUI coinUIScript;

    // Start is called before the first frame update
    void Start()
    {
        coinUIScript = coinUI.GetComponent<CoinUI>();
        collectedCoins = 0;
        adBonusCoins = 0;
        //totalcoins ze souboru
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void giveCollectedCoins(int amount)
    {
        collectedCoins += amount;
        coinUIScript.refreshScore();
    }

    public void giveAdBonusCoins()
    {
        adBonusCoins = (int)((float)collectedCoins * .2f);
        coinUIScript.refreshScore();
    }

    public void transferToTotalCoins(int amount)
    {
        totalCoins += amount;
    }

    public void resetRecievedCoins()
    {
        collectedCoins = 0;
        adBonusCoins = 0;
    }
}
