using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class ShopManager : MonoBehaviour
{
    [Header("Coins")]
    [SerializeField] GameObject coinManager;    

    [Header("Player")]
    [SerializeField] GameObject player;
    
    [SerializeField] GameObject playerBody;

    [Header("Shop UI")]
    [SerializeField] GameObject shopUI;    

    [Header("Prices")]
    [SerializeField] int extraHeartPrice;
    [SerializeField] int goldenSkinPrice;

    private string coins_100 = "100Coins";

    private bool goldenSkinIsBought;
    public bool GoldenSkinIsBought
    {
        get
        {
            return goldenSkinIsBought;
        }
    }

    private bool extraHeartisBought;
    public bool ExtraHeartisBought
    {
        get
        {
            return extraHeartisBought;
        }
    }

    private ShopUI shopUIScript;
    private CoinManager coinManagerScript;
    private PlayerHealth playerHealthScript;
    private void Start()
    {
        coinManagerScript = coinManager.GetComponent<CoinManager>();
        playerHealthScript = player.GetComponent<PlayerHealth>();
        shopUIScript = shopUI.GetComponent<ShopUI>();
    }

    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == coins_100)
        {
            coinManagerScript.transferToTotalCoins(999);
            shopUIScript.refresh();
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Purchase of: " + product.definition.id + " failed because of " + reason);
    }

    public void buyExtraHeart()
    {
        if (!extraHeartisBought)
        {
            if (extraHeartPrice <= coinManagerScript.TotalCoins)
            {
                coinManagerScript.transferToTotalCoins(-extraHeartPrice);
                playerHealthScript.increaseMaxLives(1);
                extraHeartisBought = true;
                shopUIScript.refresh();
            }
        }
    }

    public void buyGoldenSkin()
    {
        if (!goldenSkinIsBought)
        {
            if (goldenSkinPrice <= coinManagerScript.TotalCoins)
            {
                coinManagerScript.transferToTotalCoins(-goldenSkinPrice);
                playerBody.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 0, 255);
                goldenSkinIsBought = true;
                shopUIScript.refresh();
            }
        }
    }
}
