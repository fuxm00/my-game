using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    [Header("Coin Board")] 
    [SerializeField] GameObject coinBoard;

    [Header("Prefix")] 
    [SerializeField] string prefix;

    [Header("Coin Manager")]
    [SerializeField] GameObject coinManager;

    private CoinManager coinManagerScript;
    private Text coinText;

    public void refreshScore()
    {
        coinText = coinBoard.GetComponent<Text>();
        coinManagerScript = coinManager.GetComponent<CoinManager>();
        coinText.text = prefix + coinManagerScript.CollectedCoins;
    }
}
