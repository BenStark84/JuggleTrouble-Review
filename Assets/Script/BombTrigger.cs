using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BombTrigger : MonoBehaviour {

    // Use this for initialization
    public static int audiotrack = 0;
    public static AudioSource trackNumber;
    Vector3 blastPoint;

    private void Awake()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D brickCollision)
    {
    //Check if the bomb hit the wall bricks
        if (brickCollision.gameObject.tag == "WallBrick")
        {
            FindObjectOfType<BombController>().bombTriggered(gameObject, brickCollision);
        }
        if (brickCollision.gameObject.tag == "GameLost")
        {
            //call the gameover scripts
            blastPoint = gameObject.transform.position;
            FindObjectOfType<BrickManager>().BrickExplosion(blastPoint);
            FindObjectOfType<BombController>().BombControllerGameOver();
            FindObjectOfType<GameOver>().OnGameOver();
            FindObjectOfType<SoundManager>().ChangeTrack(gameObject.transform.position.y);
        }

    }

    //plays soundfx for obstacles
    private void OnCollisionEnter2D(Collision2D obstacle)
    {
        //play a sound if the bomb hits a flying obstacle
        if (obstacle.gameObject.tag == "FlyingObject")
        {     
            AudioSource collisionSound = obstacle.gameObject.GetComponent<AudioSource>();
            if (!collisionSound.isPlaying)
            {
                obstacle.gameObject.GetComponent<AudioSource>().Play();
            }
            
        }
        if (obstacle.gameObject.tag == "Player")
        {
            int bombs = gameObject.transform.parent.childCount;
            FindObjectOfType<BrickManager>().ScoreCalculator(bombs);
        }
    }

}
