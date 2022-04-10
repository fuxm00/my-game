using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public string firstPrefix;
    public string firstSuffix;
    public string secondPrefix;

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
        coinText.text = firstPrefix + coinManagerScript.currentCoins + firstSuffix + "\r\n" + secondPrefix + coinManagerScript.totalCoins;
    }
}
