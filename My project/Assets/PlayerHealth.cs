using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerMaxLives = 5;
    public int currentPlayerLives;
    public bool isAlive;
    private PlayerHeartsUI hearts;

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

        hearts = GameObject.FindGameObjectWithTag("hearts").GetComponent<PlayerHeartsUI>();
    }

    // Update is called once per frame
    void Update()
    {

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
            hearts.refreshHearts();

            if (currentPlayerLives <= 0)
            {
                die();
            }
        }
    }

    private void die()
    {
        isAlive = false;
    }
}
