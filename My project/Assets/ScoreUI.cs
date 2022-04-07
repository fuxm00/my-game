using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public GameObject ScoreBoard;
    public string prefix;

    public GameObject scoreManager;
    public ScoreManager scoreManagerScript;

    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void refreshScore()
    {
        scoreText = ScoreBoard.GetComponent<Text>();
        scoreManagerScript = scoreManager.GetComponent<ScoreManager>();
        scoreText.text = prefix + scoreManagerScript.currentScore;
    }
}
