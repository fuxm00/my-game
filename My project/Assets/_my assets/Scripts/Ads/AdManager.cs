using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
/// <summary>
/// This class manages ads. 
/// </summary>
public class AdManager : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    [SerializeField] bool _testMode;

    private string _gameId;

    void Awake()
    {
        InitializeAds();
    }

    /// <summary>
    /// Initializes Ads according to a platform.
    /// </summary>
    public void InitializeAds()
    {
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSGameId
            : _androidGameId;
        Advertisement.Initialize(_gameId, _testMode, this);
    }

    /// <summary>
    /// Debugs message about succesful initialization.
    /// </summary>
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }

    /// <summary>
    /// Debugs a message about initialization failure.
    /// </summary>
    /// <param name="error">
    /// initialization error
    /// </param>
    /// <param name="message">
    /// failure'S message
    /// </param>
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}
