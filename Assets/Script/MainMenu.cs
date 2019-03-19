using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour {

    public Button StartGameButton;
    public Button OptionsMenuButton;
    public Button ExitButton;
    public GameObject openOptionsMenu;
    public GameObject tutorialViewer;
    public AudioMixer AudioController;
    public Text HighScoreLine;

    // Use this for initialization
    void Start () {
        //This will be a tutorial in the future
        //if(PlayerPrefs.GetInt("LastTutorialViewed",0) < 1)
        //{
        //    tutorialViewer.SetActive(false);
        //    gameObject.SetActive(true);
        //}
        StartGameButton.onClick.AddListener(StartGame);
        OptionsMenuButton.onClick.AddListener(OpenOptions);
        ExitButton.onClick.AddListener(ExitGame);
        //Sets the Music and SoundFX on/off when the game opens)
        int Music = PlayerPrefs.GetInt("sound", 1);
            if (Music == 1)
            {
                AudioController.SetFloat("Music Volume", 0f);
            }
            else
            {
                AudioController.SetFloat("Music Volume", -80f);
            }
        int SoundFX = PlayerPrefs.GetInt("sound", 1);
            if (SoundFX == 1)
            {
                AudioController.SetFloat("SoundFX Volume", 0f);
            }
            else
            {
                AudioController.SetFloat("SoundFX Volume", -80f);
            }
        //Displays the Highscore
        HighScoreLine.text = "Highscore: " + PlayerPrefs.GetInt("Highscore", 0).ToString("n0");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        //SceneManager.UnloadSceneAsync(0);
    }

    public void OpenOptions()
    {
        openOptionsMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        PlayerPrefs.Save();
        Application.Quit();
    }

}
