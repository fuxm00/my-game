using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class ShopManager : MonoBehaviour
{
    private string coins_100 = "100Coins";
    private string NoBanners = "NoBanner";

    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == coins_100)
        {
            Debug.Log("100 coins reward!");
        }

        if (product.definition.id == NoBanners)
        {
            Debug.Log("Shop without Banner reward!");
        } 

        else
        {
            Debug.Log(product.definition.id + " not found in Catalog");
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Purchase of: " + product.definition.id + " failed because of " + reason);
    }
}
