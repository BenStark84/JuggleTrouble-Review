using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickManager : MonoBehaviour {

    public Transform Brick;
    Vector3 brickBlastHeading;
    public Vector2 blastForce = new Vector2(-10,100);
    //bool explosionOver = false;
    public static float playerScore = 0f;
    public Text playerScoreText;
    int countbricks;
    Vector3[] brickPoints = CameraBounds.bricklocations;
    Vector2[] bottomPoints = CameraBounds.bottomPoints;
    EdgeCollider2D edgeCollider;
    int startBricks;

    // Use this for initialization
    void Start () {
        startBricks = brickPoints.Length;
        playerScore = 0f;
       for(int i = 0; i < brickPoints.Length; i++)
        {
            var newBrick = Instantiate(Brick, brickPoints[i], Quaternion.identity);
            newBrick.transform.parent = transform;
        }
        edgeCollider = gameObject.GetComponent<EdgeCollider2D>();
        edgeCollider.points = bottomPoints;
    }
	
    public void BrickExplosion(Vector3 blastPoint)
    {
        //Updates the rigidbody and applies a force to all remaining bricks when the game is over
        foreach (Transform child in transform)
            {
                brickBlastHeading = child.position - blastPoint;
                brickBlastHeading = new Vector3(brickBlastHeading.x, brickBlastHeading.y, 0);
                child.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                child.GetComponent<Rigidbody2D>().AddForce(Vector2.Scale(brickBlastHeading, blastForce), ForceMode2D.Impulse);
            }
       // explosionOver = true;
    }

    public void ScoreCalculator(int bombsCount, float aliveTime)
    {
        int bricksRemaining = transform.childCount;
        Debug.Log("BrickScore: "+(Mathf.Abs(startBricks / 2 - bricksRemaining) + 1));
        Debug.Log("BombScore: "+(bombsCount * Mathf.RoundToInt(aliveTime)));
        playerScore += ((Mathf.Abs(startBricks / 2 - bricksRemaining)+1) * (bombsCount * Mathf.RoundToInt(aliveTime)));
        playerScoreText.text = "Score: " + playerScore.ToString("n0");
    }

    private void OnTriggerEnter2D(Collider2D bombCollision)
    {

        if (bombCollision.gameObject.tag == "Bomb")
        {
            //call the gameover scripts
            Vector3 blastPoint = bombCollision.transform.position;
            BrickExplosion(blastPoint);
            FindObjectOfType<BombController>().BombControllerGameOver();
            FindObjectOfType<GameOver>().OnGameOver();
            FindObjectOfType<SoundManager>().ChangeTrack(bombCollision.transform.position.y);
        }

    }
}
