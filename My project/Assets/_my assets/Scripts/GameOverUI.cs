using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [Header("Prefixes")]
    [SerializeField] string collectedPrefix;
    [SerializeField] string adBonusPrefix;
    [SerializeField] string totalPrefix;

    [Header("Text")]
    [SerializeField] Text coinText;

    [Header("Coin Manager")]
    [SerializeField] GameObject coinManager;

    private CoinManager coinManagerScript;

    public void refreshCoins()
    {
        coinManagerScript = coinManager.GetComponent<CoinManager>();
        coinText.text = 
            collectedPrefix + 
            coinManagerScript.CollectedCoins + 
            "\r\n" +
            adBonusPrefix +
            coinManagerScript.AdBonusCoins +
            "\r\n" +
            totalPrefix + 
            coinManagerScript.TotalCoins;
    }
}
