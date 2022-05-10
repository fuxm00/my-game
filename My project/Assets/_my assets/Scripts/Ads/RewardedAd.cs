using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.Events;

/// <summary>
/// This class manages rewarded ads, loads them and shows them.
/// </summary>
public class RewardedAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] Button _showAdButton;
    [SerializeField] string _androidAdUnitId = "Rewarded_Android";
    [SerializeField] string _iOSAdUnitId = "Rewarded_iOS";
    string _adUnitId = null;

    [SerializeField] GameObject _coinMnanager;

    private CoinManager _coinManagerScript;

    [SerializeField] UnityEvent OnUnityAdsShowCompleteEvent;

    void Awake()
    {

#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif

        _showAdButton.interactable = false;
        _coinManagerScript = _coinMnanager.GetComponent<CoinManager>();
    }

    /// <summary>
    /// Loads an ad.
    /// </summary>
    public void LoadAd()
    {
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }

    /// <summary>
    /// Prepares ad after loading.
    /// </summary>
    /// <param name="adUnitId">
    /// id of an ad unit
    /// </param>
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);

        if (adUnitId.Equals(_adUnitId))
        {
            _showAdButton.onClick.AddListener(ShowAd);
            _showAdButton.interactable = true;
        }
    }

    /// <summary>
    /// Shows loaded ad.
    /// </summary>
    public void ShowAd()
    {
        _showAdButton.interactable = false;
        Advertisement.Show(_adUnitId, this);
    }

    /// <summary>
    /// Rewards player after complete view.
    /// </summary>
    /// <param name="adUnitId">
    /// id of an ad unit
    /// </param>
    /// <param name="showCompletionState">
    /// state of shown ad
    /// </param>
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && 
            showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            _showAdButton.interactable = false;
            _showAdButton.onClick.RemoveListener(ShowAd);
            _coinManagerScript.GiveAdBonusCoins();
            _coinManagerScript.TransferToTotalCoins(_coinManagerScript.AdBonusCoins);
            OnUnityAdsShowCompleteEvent?.Invoke();
        }
    }

    /// <summary>
    /// Debugs a message about ad loading failure.
    /// </summary>
    /// <param name="adUnitId">
    /// id of an ad unit
    /// </param>
    /// <param name="error">
    /// error details
    /// </param>
    /// <param name="message">
    /// additional failure's message
    /// </param>
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    /// <summary>
    /// Debugs a message about failure during showing an Ad.
    /// </summary>
    /// <param name="adUnitId">
    /// id of an ad unit.
    /// </param>
    ///  <param name="error">
    /// error details
    /// </param>
    /// <param name="message">
    /// additional failure's message
    /// </param>
    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    /// <summary>
    /// Debugs a message about ad unit, which has been shown.
    /// </summary>
    /// <param name="adUnitId">
    /// id of an ad unit
    /// </param>
    public void OnUnityAdsShowStart(string adUnitId) 
    {
        Debug.Log($"Ad Unit {adUnitId} started showing");
    }

    /// <summary>
    /// Debugs a message about ad unit, which was clicked on.
    /// </summary>
    /// <param name="adUnitId">
    /// id of an ad unit
    /// </param>
    public void OnUnityAdsShowClick(string adUnitId) 
    {
        Debug.Log($"Ad Unit {adUnitId} was clicked");
    }

    /// <summary>
    /// Remove listeners after destroying an object.
    /// </summary>
    void OnDestroy()
    {
        _showAdButton.onClick.RemoveAllListeners();
    }
}