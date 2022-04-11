using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public GameObject AdManager;
    public BannerAd bannerAdScript;

    public GameObject coinManger;
    public CoinManager coinManagerScript;

    public GameObject shopManager;
    private ShopManager shopManagerScript;

    public Button extraHeartButton;
    public Button goldenSkinButton;

    public Text totalCoinText;
    public string coinPrefix;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showBanner()
    {
        //podmínka jestli se mají ukazovat
        if (1 == 0)
        {
            return;
        }

        if (bannerAdScript == null)
        {
            bannerAdScript = AdManager.GetComponent<BannerAd>();
        }

        bannerAdScript.LoadBanner();
        bannerAdScript.ShowBannerAd();
    }

    public void hideBanner()
    {
        bannerAdScript.HideBannerAd();
    }

    public void refresh()
    {
        if (shopManagerScript == null)
        {
            shopManagerScript = shopManager.GetComponent<ShopManager>();
        }

        if (coinManagerScript == null)
        {
            coinManagerScript = coinManger.GetComponent<CoinManager>();
        }

        if (shopManagerScript.extraHeartisBought)
        {
            extraHeartButton.interactable = false;
        }

        if (shopManagerScript.goldenSkinIsBought)
        {
            goldenSkinButton.interactable = false;
        }

        totalCoinText.text = coinPrefix + coinManagerScript.totalCoins;
    }
}
