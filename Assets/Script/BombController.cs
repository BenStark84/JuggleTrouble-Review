using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour {

    public Transform bomb;
    GameObject BombManager;
    public static bool spawnBombNow = false;
    public float bombSpawnTime = 10f;
    float bombSpawnTimer;
    public GameObject brickExplosionPrefab;

    // Use this for initialization
    void Start() {
        //set the BombManager gameobject for parenting bombs
        BombManager = GameObject.Find("BombManager");
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
        bombSpawnTimer += Time.deltaTime;
    }

    void SpawnBomb()
    {
        //Spawns a new bomb if gameover is false
            var newbomb = Instantiate(bomb, new Vector3(0, 4.5f, 0), Quaternion.identity);
            newbomb.transform.parent = BombManager.transform;
            bombSpawnTimer = 0;
    }

    public void bombTriggered(GameObject bombChild, Collider2D brickChild)
    {
        //determine if a new bomb needs to be spawned
        int bombs = gameObject.transform.childCount;
        if (bombs < 3)
        {
            spawnBombNow = true;
        }
        //Play the Explosion and Manage AudioTracks
        GetComponent<AudioSource>().Play();
        FindObjectOfType<SoundManager>().ChangeTrack(brickChild.transform.position.y);
        //create the brick exploding effect, destroy the brick and bomb
        Instantiate(brickExplosionPrefab, new Vector3(brickChild.transform.position.x, brickChild.transform.position.y, -10), Quaternion.identity);
        Destroy(brickChild.gameObject);
        Destroy(bombChild);
    }
    public void BombControllerGameOver()
    {
            Destroy(gameObject);
    }
}
