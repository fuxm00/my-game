using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class keeps stats about collected coins and total coins collected by a player
/// and manages these coins.
/// </summary>
public class CoinManager : MonoBehaviour
{
    private int _collectedCoins;
    private int _adBonusCoins;
    private int _totalCoins;

    public int CollectedCoins
    {
        get
        {
            return _collectedCoins;
        }
    }
    public int AdBonusCoins
    {
        get
        {
            return _adBonusCoins;
        }
    }
    public int TotalCoins
    {
        get
        {
            return _totalCoins;
        }
        set
        {
            _totalCoins = value;
        }
    }

    [SerializeField] UnityEvent OnTotalCoinsChange;
    [SerializeField] UnityEvent OnRecievedCoinsChange;

    void Awake()
    {
        _totalCoins = PlayerPrefs.GetInt("totalCoins");
    }

    void Start()
    {
        _collectedCoins = 0;
        _adBonusCoins = 0;
    }

    public void GiveCollectedCoins(int amount)
    {
        _collectedCoins += amount;
        OnRecievedCoinsChange?.Invoke();
    }

    public void GiveAdBonusCoins()
    {
        _adBonusCoins = (int)((float)_collectedCoins * .2f);
        OnRecievedCoinsChange?.Invoke();
    }

    public void TransferToTotalCoins(int amount)
    {
        _totalCoins += amount;
        PlayerPrefs.SetInt("totalCoins", _totalCoins);
        OnTotalCoinsChange?.Invoke();
    }

    public void ResetRecievedCoins()
    {
        _collectedCoins = 0;
        _adBonusCoins = 0;
        OnRecievedCoinsChange?.Invoke();
    }
}
