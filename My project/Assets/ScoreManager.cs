using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int currentScore;
    private GameManager gameMng;

    public GameObject ScoreUI;
    private ScoreUI scoreUIScript;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManager = GameObject.FindGameObjectWithTag("GameMng");
        gameMng = gameManager.GetComponent<GameManager>();
        scoreUIScript = ScoreUI.GetComponent<ScoreUI>();
        currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeScore(int amount)
    {
        if (gameMng.gameIsRunning)
        currentScore += amount;
        scoreUIScript.refreshScore();

    }

    public void resetScore()
    {
        currentScore = 0;
    }
}
