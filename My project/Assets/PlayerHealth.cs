using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerLifes = 5;
    public bool isAlive;
    public int currentPlayerLifes;

    // Start is called before the first frame update
    void Start()
    {
        currentPlayerLifes = playerLifes;
        if (currentPlayerLifes > 0)
        {
            isAlive = true;
        } else
        {
            isAlive = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlayerLifes <= 0 && isAlive)
        {
            die();
        }
    }

    private void die ()
    {
        isAlive = false;
    }

    public void resetHealth()
    {
        currentPlayerLifes = playerLifes;
        isAlive = true;
    }
}
