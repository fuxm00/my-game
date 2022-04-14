using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [Header("Ad Manager")]
    [SerializeField] GameObject _adManager;    

    [Header("Coin Manager")]
    [SerializeField] GameObject _coinManger;    

    [Header("Shop Manager")]
    [SerializeField] GameObject _shopManager;    

    [Header("Buttons")]
    [SerializeField] Button _extraHeartButton;
    [SerializeField] Button _goldenSkinButton;

    [Header("Coin Text")]
    [SerializeField] Text _totalCoinText;

    [Header("Prefix")]
    [SerializeField] string _coinPrefix;

    private BannerAd _bannerAdScript;
    private CoinManager _coinManagerScript;
    private ShopManager _shopManagerScript;
    public void ShowBanner()
    {
        if (_bannerAdScript == null)
        {
            _bannerAdScript = _adManager.GetComponent<BannerAd>();
        }

        _bannerAdScript.LoadBanner();
        _bannerAdScript.ShowBannerAd();
    }

    public void HideBanner()
    {
        _bannerAdScript.HideBannerAd();
    }

    public void Refresh()
    {
        if (_shopManagerScript == null)
        {
            _shopManagerScript = _shopManager.GetComponent<ShopManager>();
        }

        if (_coinManagerScript == null)
        {
            _coinManagerScript = _coinManger.GetComponent<CoinManager>();
        }

        if (_shopManagerScript.ExtraHeartisBought)
        {
            _extraHeartButton.interactable = false;
        }

        if (_shopManagerScript.GoldenSkinIsBought)
        {
            _goldenSkinButton.interactable = false;
        }

        _totalCoinText.text = _coinPrefix + _coinManagerScript.TotalCoins;
    }
}
