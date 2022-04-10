using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public string collectedPrefix;
    public string adBonusPrefix;
    public string totalPrefix;

    public GameObject coinManager;
    private CoinManager coinManagerScript;
    

    public Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void refreshCoins()
    {
        coinManagerScript = coinManager.GetComponent<CoinManager>();
        coinText.text = 
            collectedPrefix + 
            coinManagerScript.collectedCoins + 
            "\r\n" +
            adBonusPrefix +
            coinManagerScript.adBonusCoins +
            "\r\n" +
            totalPrefix + 
            coinManagerScript.totalCoins;
    }
}
