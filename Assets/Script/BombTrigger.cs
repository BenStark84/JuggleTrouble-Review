using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BombTrigger : MonoBehaviour {

    // Use this for initialization
    public static int audiotrack = 0;
    public static AudioSource trackNumber;
    public GameObject brickExplosionPrefab;

    void Update () {
                //if bomb is off screen start gameOver
                //I could probably just call onbombblast from here instead of setting the boolean for the controller
                if (transform.position.y < -PlayerController.orthographicSize - 1)
                    {
                    BombController.blastPoint = transform.position;
                    BombController.bombBlast = true;
                    Destroy(gameObject);
                    }
                if (BombController.gameOver)
                    {
                        Destroy(gameObject);
                    }
        }

	

    private void OnTriggerEnter2D(Collider2D brickCollision)
    {
        //Check if the bomb hit the wall bricks
        //I find even with a rigidbody on the bricks it does not like OnCollisionEnter2D
        if (brickCollision.gameObject.tag == "WallBrick")
        {
            //Count bombs if less than 3 bombs on the screen spawn a new bomb
            int bombs = transform.parent.childCount;
            if (bombs < 3)
            {
                BombController.spawnBombNow = true;
            }
            //play the explosion sound effect attached to the bomb controller
            transform.parent.gameObject.GetComponent<AudioSource>().Play();

            //swap between audiotracks based on the first brick broken from each row
            //There seems there has to be a more efficient way
            //Maybe an audiosource with multiple tracks and a mixer to swap between scenes?
            if (audiotrack == 0)
            {
                trackNumber = GameObject.Find("BrickManager").GetComponent<AudioSource>();
            }
            if (brickCollision.transform.parent.name == "BrickRow (1)" && audiotrack < 1)
            {
                trackNumber.Stop();
                trackNumber = brickCollision.transform.parent.GetComponent<AudioSource>();
                trackNumber.Play();
                trackNumber.loop = true;
                audiotrack++;
            }
            if (brickCollision.transform.parent.name == "BrickRow (2)" && audiotrack < 2)
            {
                trackNumber.Stop();
                trackNumber = brickCollision.transform.parent.GetComponent<AudioSource>();
                trackNumber.Play();
                trackNumber.loop = true;
                audiotrack++;
            }
            if (brickCollision.transform.parent.name == "BrickRow (3)" && audiotrack < 3)
            {
                trackNumber.Stop();
                trackNumber = brickCollision.transform.parent.GetComponent<AudioSource>();
                trackNumber.Play();
                trackNumber.loop = true;
                audiotrack++;
            }
            if (brickCollision.transform.parent.name == "BrickRow (4)" && audiotrack < 4)
            {
                trackNumber.Stop();
                trackNumber = brickCollision.transform.parent.GetComponent<AudioSource>();
                trackNumber.Play();
                trackNumber.loop = true;
                audiotrack++;
            }
            //create the brick exploding effect
            Instantiate(brickExplosionPrefab, new Vector3(brickCollision.transform.position.x, brickCollision.transform.position.y, -10), Quaternion.identity);
            //destroy the brick
            Destroy(brickCollision.gameObject);
            //destroy the bomb
            Destroy(gameObject);
            //Possibly add the effect of the bomb exploding and the brick particles moving away from the bomb
            //but how?
        }
    }
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
    }

}
