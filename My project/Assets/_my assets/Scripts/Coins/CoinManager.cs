using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] GameObject coinUI;

    private int collectedCoins;
    public int CollectedCoins
    {
        get
        {
            return collectedCoins;
        }
    }

    private int adBonusCoins;
    public int AdBonusCoins
    {
        get
        {
            return adBonusCoins;
        }
    }

    private int totalCoins;
    public int TotalCoins
    {
        get
        {
            return totalCoins;
        }
        set
        {
            totalCoins = value;
        }
    }

    private CoinUI coinUIScript;

    // Start is called before the first frame update
    void Start()
    {
        coinUIScript = coinUI.GetComponent<CoinUI>();
        collectedCoins = 0;
        adBonusCoins = 0;
        //totalcoins ze souboru
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
