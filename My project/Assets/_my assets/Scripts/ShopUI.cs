using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public GameObject AdManager;
    public BannerAd bannerAdScript;

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
}
