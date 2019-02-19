using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameOver : MonoBehaviour {

    public GameObject gameOverScreen;
    public GameObject gameScreen;
    public Text Score;
    public Text HighScoreLine;
    public Button startMenu;
    public Button restart;
    public Button exit;
    bool gameOver = false;
    //public int highScore;

    private void Awake()
    {
        startMenu.onClick.AddListener(ReturnToStart);
        restart.onClick.AddListener(RestartGame);
        exit.onClick.AddListener(ExitGame);
    }

    // Use this for initialization
    void Start () {
        //The System Action called from the bomb controller

        
	}
	
	// Update is called once per frame
	void Update () {
        //This should probably be removed as it has been replaced by buttons
        if (gameOver)
            if (Input.GetKey(KeyCode.Space))
            {

                    gameOver = false;
                    SceneManager.LoadScene(0);
                
            }

    }

    void ReturnToStart()
    {
        SceneManager.LoadScene(0);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    void ExitGame()
    {
        Application.Quit();
    }

    public void OnGameOver()
    {

        gameOverScreen.SetActive(true);
        gameScreen.SetActive(false);
        //Stops the current music and plays the game over music
        //pulls the highscore and compares to the current score
        int highScore = PlayerPrefs.GetInt("Highscore", 0);
        int newScore = Mathf.FloorToInt(BrickManager.playerScore);
        if(newScore >= highScore)
        {
            PlayerPrefs.SetInt("Highscore", newScore);
            HighScoreLine.text = "New High Score!";
        }
        else
        {
            HighScoreLine.text = "High Score: " + highScore.ToString("n0");
        }
        //displays new high score
        Score.text = newScore.ToString("n0");
        gameOver = true;
    }
}
