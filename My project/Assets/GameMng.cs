using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMng : MonoBehaviour
{
    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newGame()
    {
        joystick.gameObject.SetActive(true);
        //TODO Time.timeScale = 1f;
    }

    public void quitApp()
    {
        Application.Quit();
    }
}
