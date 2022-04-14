using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAppearance : MonoBehaviour
{
    [Header("Body")]
    [SerializeField] GameObject _playerBody;

    [Header("Color")]
    [SerializeField] Color32 _goldColor;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("GoldenSkinIsBought") == 1)
        {
            ChangeToGoldSkin();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToGoldSkin()
    {
        _playerBody.GetComponent<SpriteRenderer>().color = _goldColor;
    }
}
