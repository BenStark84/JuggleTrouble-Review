using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    AudioSource gameMusic;
    public AudioClip[] audioTracks = new AudioClip[6];
    int currentTrack = 0;
    float[] trackLevels = CameraBounds.brickHeights;

	// Use this for initialization
	void Start () {
        gameMusic = GetComponent<AudioSource>();
        gameMusic.clip = audioTracks[currentTrack];
        gameMusic.Play();
        gameMusic.loop = true;

	}

    public void ChangeTrack(float objectHeight)
    {
        if (objectHeight < trackLevels[currentTrack])
        {
            currentTrack++;
            if (currentTrack == audioTracks.Length)
            {
                gameMusic.Stop();
                currentTrack = 0;
            }
            else
            {
                gameMusic.Stop();
                gameMusic.clip = audioTracks[currentTrack];
                gameMusic.Play();
                gameMusic.loop = true;
            }
        }
    }
    public void ForceTrack(int track)
    {
        currentTrack = track;
        gameMusic.Stop();
        gameMusic.clip = audioTracks[currentTrack];
        gameMusic.Play();
        gameMusic.loop = true;

    }
}
