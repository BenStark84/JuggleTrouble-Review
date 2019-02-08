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
        BombManager = GameObject.Find("BombManager");
        spawnBombNow = true;
    }

    // Update is called once per frame
    void Update() {
        if ((spawnBombNow && (bombSpawnTimer > 0.5f || transform.childCount == 0)) || bombSpawnTimer > bombSpawnTime)
        {
            SpawnBomb();
            spawnBombNow = false;
        }
        if (bombBlast)
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
        if (!gameOver)
        {
            var newbomb = Instantiate(bomb, new Vector3(0, 4.5f, 0), Quaternion.identity);
            newbomb.transform.parent = BombManager.transform;
            bombSpawnTimer = 0;
        }
    }
}
