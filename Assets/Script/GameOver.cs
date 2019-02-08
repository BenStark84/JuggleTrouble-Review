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
    //public int highScore;

    private void Awake()
    {
        startMenu.onClick.AddListener(ReturnToStart);
        restart.onClick.AddListener(RestartGame);
        exit.onClick.AddListener(ExitGame);
    }

    // Use this for initialization
    void Start () {
        FindObjectOfType<BombController> ().OnBombBlast += OnGameOver;
        
	}
	
	// Update is called once per frame
	void Update () {

        if (BombController.gameOver)
            if (Input.GetKey(KeyCode.Space))
            {
                {
                    BombController.bombBlast = false;
                    BombController.gameOver = false;
                    SceneManager.LoadScene(0);
                }
            }

    }

    void ReturnToStart()
    {
        BombController.bombBlast = false;
        BombController.gameOver = false;
        SceneManager.LoadScene(0);
    }

    void RestartGame()
    {
        BombController.bombBlast = false;
        BombController.gameOver = false;
        SceneManager.LoadScene(1);
    }

    void ExitGame()
    {
        Application.Quit();
    }

    void OnGameOver()
    {
        gameOverScreen.SetActive(true);
        gameScreen.SetActive(false);
        BombTrigger.trackNumber.Stop();
        BombTrigger.audiotrack = 0;
        int highScore = PlayerPrefs.GetInt("Highscore", 0);
        Debug.Log("High Score: " + highScore);
        int newScore = Mathf.FloorToInt(BrickManager.PlayerScore);
        if(newScore >= highScore)
        {
            Debug.Log("newScore: " + newScore);
            PlayerPrefs.SetInt("Highscore", newScore);
            HighScoreLine.text = "New High Score!";
        }
        else
        {
            Debug.Log("newScore: " + newScore);
            HighScoreLine.text = "High Score: " + highScore.ToString("n0");
        }
        Score.text = newScore.ToString("n0");
        BombController.gameOver = true;
    }
}
