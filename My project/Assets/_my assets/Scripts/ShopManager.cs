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
    
    [SerializeField] GameObject _playerBody;

    [Header("Shop UI")]
    [SerializeField] GameObject _shopUI;    

    [Header("Prices")]
    [SerializeField] int _extraHeartPrice;
    [SerializeField] int _goldenSkinPrice;

    private string _coins999 = "coins_999";

    private bool _goldenSkinIsBought;
    public bool GoldenSkinIsBought
    {
        get
        {
            return _goldenSkinIsBought;
        }
    }

    private bool _extraHeartisBought;
    public bool ExtraHeartisBought
    {
        get
        {
            return _extraHeartisBought;
        }
    }

    private ShopUI _shopUIScript;
    private CoinManager _coinManagerScript;
    private PlayerHealth _playerHealthScript;
    private void Start()
    {
        _coinManagerScript = _coinManager.GetComponent<CoinManager>();
        _playerHealthScript = _player.GetComponent<PlayerHealth>();
        _shopUIScript = _shopUI.GetComponent<ShopUI>();
    }

    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == _coins999)
        {
            _coinManagerScript.TransferToTotalCoins(999);
            _shopUIScript.Refresh();
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
                _coinManagerScript.TransferToTotalCoins(-_extraHeartPrice);
                _playerHealthScript.IncreaseMaxLives(1);
                _extraHeartisBought = true;
                _shopUIScript.Refresh();
            }
        }
    }

    public void BuyGoldenSkin()
    {
        if (!_goldenSkinIsBought)
        {
            if (_goldenSkinPrice <= _coinManagerScript.TotalCoins)
            {
                _coinManagerScript.TransferToTotalCoins(-_goldenSkinPrice);
                _playerBody.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 0, 255);
                _goldenSkinIsBought = true;
                _shopUIScript.Refresh();
            }
        }
    }
}
