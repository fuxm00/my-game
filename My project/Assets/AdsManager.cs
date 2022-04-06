using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize("4695771");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playRewardedAd()
    {
        Advertisement.Show("Rewarded_Android");
    }
}
