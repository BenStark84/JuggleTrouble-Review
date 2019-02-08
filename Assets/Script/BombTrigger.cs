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
        if (brickCollision.gameObject.tag == "WallBrick")
        {
            int bombs = GameObject.FindGameObjectsWithTag("Bomb").Length;
            if (bombs < 3)
            {
                BombController.spawnBombNow = true;
            }

            transform.parent.gameObject.GetComponent<AudioSource>().Play();

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

            Instantiate(brickExplosionPrefab, new Vector3(brickCollision.transform.position.x, brickCollision.transform.position.y, -10), Quaternion.identity);
            Destroy(brickCollision.gameObject);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D obstacle)
    {
        
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
