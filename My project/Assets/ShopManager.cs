using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class ShopManager : MonoBehaviour
{
    private string coins_100 = "100Coins";
    private string NoBanners = "NoBanner";

    public bool goldenSkinIsBought;
    public bool extraHeartisBought;

    [Header("Coins")]
    public GameObject coinManager;
    private CoinManager coinManagerScript;

    [Header("Player")]
    public GameObject player;
    private PlayerHealth playerHealthScript;

    [Header("Shop UI")]
    public GameObject shopUI;
    private ShopUI shopUIScript;

    [Header("Price")]
    public int extraHeartPrice;
    public int goldenSkinPrice;

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
            Debug.Log("100 coins reward!");
            coinManagerScript.transferToTotalCoins(100);
            shopUIScript.refresh();
        }

        /*else if (product.definition.id == NoBanners)
        {
            Debug.Log("Shop without Banner reward!");
        }*/ 

        else
        {
            Debug.Log(product.definition.id + " not found in Catalog");
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
            if (extraHeartPrice <= coinManagerScript.totalCoins)
            {
                coinManagerScript.totalCoins -= extraHeartPrice;
                playerHealthScript.playerMaxLives = 4;
                extraHeartisBought = true;
                shopUIScript.refresh();
            }
        }
    }

    public void buyGoldenSkin()
    {
        if (!goldenSkinIsBought)
        {
            if (goldenSkinPrice <= coinManagerScript.totalCoins)
            {
                coinManagerScript.totalCoins -= goldenSkinPrice;
                //skin change
                goldenSkinIsBought = true;
                shopUIScript.refresh();
            }
        }
    }
}
