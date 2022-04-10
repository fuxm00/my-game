using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    // Start is called before the first frame update

    private void Awake()
    {
        Advertisement.Initialize("4695771");
    }
    void Start()
    {
        
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
