using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickManager : MonoBehaviour {

    public Transform Brick;
    Vector3 brickBlastHeading;
    public Vector2 blastForce = new Vector2(-10,100);
    bool explosionOver = false;
    public static float PlayerScore = 0f;
    public Text playerScoreText;
    int countbricks;

	// Use this for initialization
	void Start () {
        PlayerScore = 0f;
        int y = 0;
        //This is intended to spawn a set of bricks in each row for four rows.
        //Each row has it's own parent object to hold the Audiotrack for the game music
        //Game music changes each time the first brick is broken from a row
        foreach (Transform child in transform)
        { 
           for(float x=0; x<6+y%2; x++)
            {
                float xcord = (x - 3) + (((y+1) % 2) * 0.5f);
                float ycord = -3.8f - y*0.3f;
                var newBrick = Instantiate(Brick, new Vector3(xcord, ycord, 0), Quaternion.identity);
                newBrick.transform.parent = child.transform;
            }
            y++;
        }
       
	}
	
	// Update is called once per frame
	void Update () {

        //Calls a brick explosion
        if (BombController.gameOver == true && explosionOver == false)
        {
            BrickExplosion();
        }
		
	}

    public void BrickExplosion()
    {
        //Updates the rigidbody and applies a force to all remaining bricks when the game is over
        foreach (Transform brickrow in transform)
        {
            foreach (Transform child in brickrow.transform)
            {
                brickBlastHeading = child.position - BombController.blastPoint;
                brickBlastHeading = new Vector3(brickBlastHeading.x, brickBlastHeading.y, 0);
                child.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                child.GetComponent<Rigidbody2D>().velocity = (Vector2.Scale(brickBlastHeading, blastForce));
            }
        }
        explosionOver = true;
    }

    private void FixedUpdate()
    {
        //manages the player score as the players score is based on the number of bricks remaining.
        //Is there a more efficient way to get the count of bricks than loading all bricks into an array
        if (!BombController.gameOver)
        {

            PlayerScore = (PlayerScore + (gameObject.GetComponentsInChildren<Transform>().Length * Time.fixedUnscaledDeltaTime)*5f);
            playerScoreText.text = "Score: " + PlayerScore.ToString("n0");
        }
    }
}
