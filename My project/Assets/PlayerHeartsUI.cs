using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeartsUI : MonoBehaviour
{
    public GameObject[] playerHearts;
    private GameObject player;
    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void refreshHearts()
    {
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
