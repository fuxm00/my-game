using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;
    private GameManager gameMng;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManager = GameObject.FindGameObjectWithTag("GameMng");
        gameMng = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeScore(int amount)
    {
        if (gameMng.gameIsRunning)
        score += amount;
    }

    public void resetScore()
    {
        score = 0;
    }
}
