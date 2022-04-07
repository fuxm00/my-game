using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeartsUI : MonoBehaviour
{
    public GameObject[] playerHearts;
    public GameObject player;
    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void refreshHearts()
    {
        playerHealth = player.GetComponent<PlayerHealth>();

        foreach (GameObject heart in playerHearts)
        {
            heart.SetActive(false);
        }

        for (int i = 0; i < playerHealth.currentPlayerLives; i++)
        {
            playerHearts[i].SetActive(true);
        }
    }
}
