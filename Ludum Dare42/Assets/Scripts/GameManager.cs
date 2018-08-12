using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject gameOver;
    public CanvasGroup gameOverScreen;
    public delegate void ManagerAction();
    public static event ManagerAction GameReset;
    void Start ()
    {
        gameOver = GameObject.Find("GameOverCanvas");
        gameOverScreen = gameOver.GetComponent<CanvasGroup>();
        gameOverScreen.alpha = 0;
        ScoreManager.GameOver += DisplayGameOverScreen;
	}
    void DisplayGameOverScreen()
    {
        gameOverScreen.alpha = 1;
    }
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("r"))
        {
            if(GameReset!= null)
            {
                GameReset();
                gameOverScreen.alpha = 0;
            }
        }
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
	}
}
