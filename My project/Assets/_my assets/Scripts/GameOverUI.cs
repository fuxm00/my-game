using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class displays stats of collected coins, bonus coins from ads and total coins.
/// </summary>
public class GameOverUI : MonoBehaviour
{
    [Header("Prefixes")]
    [SerializeField] string _collectedPrefix;
    [SerializeField] string _adBonusPrefix;
    [SerializeField] string _totalPrefix;

    [Header("Text")]
    [SerializeField] Text _coinText;

    [Header("Coin Manager")]
    [SerializeField] GameObject _coinManager;

    private CoinManager _coinManagerScript;

    public void RefreshCoins()
    {
        _coinManagerScript = _coinManager.GetComponent<CoinManager>();
        _coinText.text = 
            _collectedPrefix + 
            _coinManagerScript.CollectedCoins + 
            "\r\n" +
            _adBonusPrefix +
            _coinManagerScript.AdBonusCoins +
            "\r\n" +
            _totalPrefix + 
            _coinManagerScript.TotalCoins;
    }
}
