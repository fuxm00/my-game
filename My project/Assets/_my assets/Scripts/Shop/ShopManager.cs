using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class ShopManager : MonoBehaviour
{
    [Header("Coins")]
    [SerializeField] GameObject _coinManager;    

    [Header("Player")]
    [SerializeField] GameObject _player;  

    [Header("Prices")]
    [SerializeField] int _extraHeartPrice;
    [SerializeField] int _goldenSkinPrice;

    private string _coins999 = "coins_999";
    private bool _goldenSkinIsBought;
    private bool _extraHeartisBought;
    private CoinManager _coinManagerScript;
    private PlayerHealth _playerHealthScript;
    private PlayerAppearance _playerAppearanceScript;

    public bool GoldenSkinIsBought
    {
        get
        {
            return _goldenSkinIsBought;
        }
    }

    public bool ExtraHeartisBought
    {
        get
        {
            return _extraHeartisBought;
        }
    }

    void Awake()
    {
        if (PlayerPrefs.GetInt("ExtraHeartIsBought") == 1)
        {
            _extraHeartisBought = true;
        }

        if (PlayerPrefs.GetInt("GoldenSkinIsBought") == 1)
        {
            _goldenSkinIsBought = true;
        }
    }

    void Start()
    {
        _coinManagerScript = _coinManager.GetComponent<CoinManager>();
        _playerHealthScript = _player.GetComponent<PlayerHealth>();
        _playerAppearanceScript = _player.GetComponent<PlayerAppearance>();
    }

    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == _coins999)
        {
            _coinManagerScript.TransferToTotalCoins(999);
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Purchase of: " + product.definition.id + " failed because of " + reason);
    }

    public void BuyExtraHeart()
    {
        if (!_extraHeartisBought)
        {
            if (_extraHeartPrice <= _coinManagerScript.TotalCoins)
            {
                _playerHealthScript.IncreaseMaxLives(1);
                _extraHeartisBought = true;
                PlayerPrefs.SetInt("ExtraHeartIsBought", 1);
                _coinManagerScript.TransferToTotalCoins(_extraHeartPrice * -1);
            }
        }
    }

    public void BuyGoldenSkin()
    {
        if (!_goldenSkinIsBought)
        {
            if (_goldenSkinPrice <= _coinManagerScript.TotalCoins)
            {
                _playerAppearanceScript.ChangeToGoldSkin();
                _goldenSkinIsBought = true;
                PlayerPrefs.SetInt("GoldenSkinIsBought", 1);
                _coinManagerScript.TransferToTotalCoins(_goldenSkinPrice * -1);
            }
        }
    }
}
