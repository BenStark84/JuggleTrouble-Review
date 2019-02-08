using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour {

    public Transform bomb;
    GameObject BombManager;
    public static bool spawnBombNow = false;
    public float bombSpawnTime = 10f;
    public static bool gameOver = false;
    public static Vector3 blastPoint;
    public static bool bombBlast = false;
    public event System.Action OnBombBlast;
    float bombSpawnTimer;

    // Use this for initialization
    void Start() {
        //set the BombManager gameobject for transforms
        BombManager = GameObject.Find("BombManager");
        //spawn the first bomb
        spawnBombNow = true;
    }

    // Update is called once per frame
    void Update() {
        //Spawn a bomb if there are no bombs OR it has been more than .5seconds since the last bomb
        //Spawn a bomb if a bomb has not spawned in bombSpawnTime seconds (multiple bombs)
        if ((spawnBombNow && (bombSpawnTimer > 0.5f || transform.childCount == 0)) || bombSpawnTimer > bombSpawnTime)
        {
            SpawnBomb();
            spawnBombNow = false;
        }
        //this pulls the bombBlast Boolean to determine if a bomb has gone off the bottom of the screen
        //This should probably be moved to the BombTrigger script. I originanlly intended it to do more.
        if (bombBlast && !gameOver)
        {
            if (OnBombBlast != null)
            {
                OnBombBlast();
            }
        }
        bombSpawnTimer += Time.deltaTime;
    }

    void SpawnBomb()
    {
        //Spawns a new bomb if gameover is false
        if (!gameOver)
        {
            var newbomb = Instantiate(bomb, new Vector3(0, 4.5f, 0), Quaternion.identity);
            newbomb.transform.parent = BombManager.transform;
            bombSpawnTimer = 0;
        }
    }
}
