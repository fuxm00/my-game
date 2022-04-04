using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMng : MonoBehaviour
{
    public Joystick joystick;
    public GameObject playerPrefab;
    public GameObject playerSpawn;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newGame()
    {
        joystick.gameObject.SetActive(true);
        player.SetActive(true);
    }

    public void quitApp()
    {
        Application.Quit();
    }
}
