using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour {

    public Dropdown controllSchema;
    public Dropdown difficultySet;
    public Toggle soundFX;
    public Toggle soundOn;
    public Button backButton;
    public GameObject MainMenu;
    public AudioMixer AudioController;

	// Use this for initialization
	void Start () {

        //These are the game options. How controls work, what's the difficulty, and SoundFX and Sound
        controllSchema.value = PlayerPrefs.GetInt("control", 2);
        difficultySet.value = PlayerPrefs.GetInt("difficulty", 1);
        int soundFXKey = PlayerPrefs.GetInt("soundFX", 1);
        soundFX.isOn = Convert.ToBoolean(soundFXKey);
        int soundOnKey = PlayerPrefs.GetInt("sound", 1);
        soundOn.isOn = Convert.ToBoolean(soundOnKey);
        backButton.onClick.AddListener(OpenMainMenu);
    }

    public void setDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt("difficulty", difficulty);
    }

    public void setControlSchema(int control)
    {
        PlayerPrefs.SetInt("control", control);
    }

    public void setSoundFX(bool soundFXSet)
    {
        int soundFXKey = Convert.ToInt16(soundFXSet);
        PlayerPrefs.SetInt("motionBlur", soundFXKey);
        if (soundFXSet)
        {
            AudioController.SetFloat("SoundFX Volume", 0f);
        }
        else if (!soundFXSet)
        {
            AudioController.SetFloat("SoundFX Volume", -80f);
        }
    }

    public void setSoundOn(bool SoundOn)
    {
        int soundOnKey = Convert.ToInt16(SoundOn);
        PlayerPrefs.SetInt("sound", soundOnKey);
        if (SoundOn)
        {
            AudioController.SetFloat("Music Volume", 0f);
        }
        else if (!SoundOn)
        {
            AudioController.SetFloat("Music Volume", -80f);
        }
    }

    public void OpenMainMenu()
    {
        MainMenu.SetActive(true);
        gameObject.SetActive(false);
    }

}
