using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeartsUI : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] playerHearts;

    private PlayerHealth playerHealth;

    public void refreshHearts()
    {
        playerHealth = player.GetComponent<PlayerHealth>();

        foreach (GameObject heart in playerHearts)
        {
            heart.SetActive(false);
        }

        for (int i = 0; i < playerHealth.CurrentPlayerLives; i++)
        {
            playerHearts[i].SetActive(true);
        }
    }
}
