using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Lives")]
    [SerializeField] int playerMaxLives;
    public int PlayerMaxLives
    {
        get
        {
            return playerMaxLives;
        }
    }

    [SerializeField] int currentPlayerLives;
    public int CurrentPlayerLives
    {
        get
        {
            return currentPlayerLives;
        }
    }

    [Header("Is Alive")]
    [SerializeField] bool isAlive;
    public bool IsAlive
    {
        get
        {
            return isAlive;
        }
    }

    private PlayerHeartsUI playerHeartsUIScript;

    // Start is called before the first frame update
    void Start()
    {
        currentPlayerLives = playerMaxLives;
        if (currentPlayerLives > 0)
        {
            isAlive = true;
        } else
        {
            isAlive = false;
        }

        playerHeartsUIScript = GameObject.FindGameObjectWithTag("hearts").GetComponent<PlayerHeartsUI>();
    }

    public void resetHealth()
    {
        currentPlayerLives = playerMaxLives;
        isAlive = true;
    }

    public void damagePlayer(int damagePoints)
    {
        if (isAlive)
        {
            currentPlayerLives -= damagePoints;
            playerHeartsUIScript.refreshHearts();

            if (currentPlayerLives <= 0)
            {
                die();
            }
        }
    }

    public void die()
    {
        isAlive = false;
    }

    public void increaseMaxLives (int amount)
    {
        playerMaxLives += amount;
    }
}
