using System.Collections;
using System.Collections.Generic;
using System;
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
    public Button back;
    public Toggle mute;
    BombController bombbManager;
    public GameObject progressBar;
    bool gameOver = false;
    bool unmuteudio;
    public AudioMixer AudioController;
    //public int highScore;

    private void Awake()
    {
        startMenu.onClick.AddListener(ReturnToStart);
        restart.onClick.AddListener(RestartGame);
        exit.onClick.AddListener(ExitGame);
        back.onClick.AddListener(ReturnToStart);
        int muteAudioKey = PlayerPrefs.GetInt("muteAudio", 1);
        mute.isOn = Convert.ToBoolean(muteAudioKey);
    }

    // Use this for initialization
    void Start () {
        //The System Action called from the bomb controller
        bombbManager = GameObject.Find("BombManager").GetComponent<BombController>();
        
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
        if (!gameOver)
        {
            progressBar.GetComponent<Image>().fillAmount = bombbManager.spawnTimePercent;
        }
    }

    void ReturnToStart()
    {
        SceneManager.LoadScene(0);
    }
    
    public void MuteAudio(bool muteAudio)
    {
        int muteAudioKey = Convert.ToInt16(muteAudio);
        PlayerPrefs.SetInt("muteAudio", muteAudioKey);
        if (muteAudio)
        {
            AudioController.SetFloat("Master Volume", 0f);
        }
        else if (!muteAudio)
        {
            AudioController.SetFloat("Master Volume", -80f);
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    void ExitGame()
    {
        PlayerPrefs.Save();
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
