using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    public GameObject coinBoard;
    public string prefix;

    public GameObject coinManager;
    public CoinManager coinManagerScript;

    public Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void refreshScore()
    {
        coinText = coinBoard.GetComponent<Text>();
        coinManagerScript = coinManager.GetComponent<CoinManager>();
        coinText.text = prefix + coinManagerScript.collectedCoins;
    }
}
