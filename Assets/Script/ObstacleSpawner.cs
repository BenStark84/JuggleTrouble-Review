using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    public Transform[] obstacleArray = new Transform[3];
    Transform obstacle;
    GameObject ObstacleManager;
    float obstacleSpawnTime = 0.75f;
    float spawnHeight;
    bool spawnSide;
    float spawnPoint;
    public Vector2 spawnRange;
    float obstacleSpawnTimer;
    int difficulty;

    // Use this for initialization
    void Start () {
        ObstacleManager = GameObject.Find("ObstacleManager");
        spawnRange = new Vector2(0.2f, 0.9f);
        difficulty = PlayerPrefs.GetInt("difficulty", 0);
        if(difficulty == 2)
        {
            obstacleSpawnTime = 0.5f;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (difficulty > 0)
        {
            if (obstacleSpawnTimer > obstacleSpawnTime)
            {
                SpawnObstacle();
            }
            obstacleSpawnTimer += Time.deltaTime;
        }
	}

    void SpawnObstacle()
    {
        obstacle = obstacleArray[Random.Range(0, obstacleArray.Length)];
        spawnHeight = Random.Range(PlayerController.orthographicSize*spawnRange.x, PlayerController.orthographicSize*spawnRange.y);
        spawnPoint = -(PlayerController.screenHalfWidth + 2);
        var newObstacle = Instantiate(obstacle, new Vector3(spawnPoint, spawnHeight, 0), Quaternion.identity);
        newObstacle.transform.parent = ObstacleManager.transform;
        obstacleSpawnTimer = 0f;
    }

}
