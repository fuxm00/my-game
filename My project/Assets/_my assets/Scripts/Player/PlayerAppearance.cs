using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class changes player's appearance.
/// </summary>
public class PlayerAppearance : MonoBehaviour
{
    [Header("Body")]
    [SerializeField] GameObject _playerBody;

    /// <summary>
    /// Checks whether the golden skin has been bought or not.
    /// </summary>
    void Start()
    {
        if (PlayerPrefs.GetInt("GoldenSkinIsBought") == 1)
        {
            ChangeToGoldSkin();
        }
    }

    /// <summary>
    /// Changes player's color to gold.
    /// </summary>
    public void ChangeToGoldSkin()
    {
        _playerBody.GetComponent<SpriteRenderer>().color = Colors.Gold;
    }
}
