using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public int Score;
    public int MaxLives;
    public int Lives;
    public delegate void ScoreAction();
    public static event ScoreAction GameOver;
    public Text scoreText;
    public Text livesText;
    public Text bestScoreText;
    private int bestScore = 0;
	void Start ()
    {
        Lives = MaxLives;
        GameManager.GameReset += ResetLives;
    }
	void ResetLives()
    {
        Lives = MaxLives;
        if(bestScore < Score)
        {
            bestScore = Score;
        }
        Score = 0;
        
    }
	// Update is called once per frame
	void Update ()
    {
        if(scoreText != null)
        {
            scoreText.text = Score.ToString();
        }
        if(livesText != null)
        {
            livesText.text = Lives.ToString();
        }
        if(bestScoreText != null)
        {
            bestScoreText.text = bestScore.ToString();
        }
        
		if (GameOver != null && Lives <= 0)
        {
            GameOver();
        }
	}
}
