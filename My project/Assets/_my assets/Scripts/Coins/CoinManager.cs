using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinManager : MonoBehaviour
{
    [SerializeField] UnityEvent OnTotalCoinsChange;
    [SerializeField] UnityEvent OnRecievedCoinsChange;

    private int _collectedCoins;
    public int CollectedCoins
    {
        get
        {
            return _collectedCoins;
        }
    }

    private int _adBonusCoins;
    public int AdBonusCoins
    {
        get
        {
            return _adBonusCoins;
        }
    }

    private int _totalCoins;
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

    private void Awake()
    {
        _totalCoins = PlayerPrefs.GetInt("totalCoins");
    }

    // Start is called before the first frame update
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
