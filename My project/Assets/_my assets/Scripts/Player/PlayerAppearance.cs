using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAppearance : MonoBehaviour
{
    [Header("Body")]
    [SerializeField] GameObject _playerBody;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("GoldenSkinIsBought") == 1)
        {
            ChangeToGoldSkin();
        }
    }

    public void ChangeToGoldSkin()
    {
        _playerBody.GetComponent<SpriteRenderer>().color = Colors.Gold;
    }
}
