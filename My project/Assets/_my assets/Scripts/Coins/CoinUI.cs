using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    [Header("Coin Board")] 
    [SerializeField] GameObject _coinBoard;

    [Header("Prefix")] 
    [SerializeField] string _prefix;

    [Header("Coin Manager")]
    [SerializeField] GameObject _coinManager;

    private CoinManager _coinManagerScript;
    private Text _coinText;

    public void RefreshScore()
    {
        _coinText = _coinBoard.GetComponent<Text>();
        _coinManagerScript = _coinManager.GetComponent<CoinManager>();
        _coinText.text = _prefix + _coinManagerScript.CollectedCoins;
    }
}
