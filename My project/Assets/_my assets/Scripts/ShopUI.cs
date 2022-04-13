using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [Header("Ad Manager")]
    [SerializeField] GameObject AdManager;    

    [Header("Coin Manager")]
    [SerializeField] GameObject coinManger;    

    [Header("Shop Manager")]
    [SerializeField] GameObject shopManager;    

    [Header("Buttons")]
    [SerializeField] Button extraHeartButton;
    [SerializeField] Button goldenSkinButton;

    [Header("Coin Text")]
    [SerializeField] Text totalCoinText;

    [Header("Prefix")]
    [SerializeField] string coinPrefix;

    private BannerAd bannerAdScript;
    private CoinManager coinManagerScript;
    private ShopManager shopManagerScript;
    public void showBanner()
    {
        if (bannerAdScript == null)
        {
            bannerAdScript = AdManager.GetComponent<BannerAd>();
        }

        bannerAdScript.LoadBanner();
        bannerAdScript.ShowBannerAd();
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

        if (shopManagerScript.ExtraHeartisBought)
        {
            extraHeartButton.interactable = false;
        }

        if (shopManagerScript.GoldenSkinIsBought)
        {
            goldenSkinButton.interactable = false;
        }

        totalCoinText.text = coinPrefix + coinManagerScript.TotalCoins;
    }
}
