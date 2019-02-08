using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour {

    public GameObject WallToSpawn;
    public GameObject RoofToSpawn;
    float aspectRatio;
    float orthographicSize;
    GameObject WallManager;

    private void Awake()
        {
                    //Set screen size for Standalone
        #if UNITY_STANDALONE
                    Screen.SetResolution(360,640, false);
                    Screen.fullScreen = false;
        #endif
        WallManager = GameObject.Find("WallManager");
    }

    // Use this for initialization
    void Start () {
        //Spawns Walls at the start of the game to keep the bombs on screen
        //Possibly something more efficient?
        aspectRatio = Camera.main.aspect;
        orthographicSize = Camera.main.orthographicSize;
        float screenHalfWidth = aspectRatio * orthographicSize;
        var newWall = Instantiate(WallToSpawn, new Vector3(-screenHalfWidth-0.1f, 0, 0), Quaternion.identity);
        newWall.transform.localScale = new Vector3(0.1f, orthographicSize*2, 1);
        newWall.transform.parent = WallManager.transform;
        newWall = Instantiate(WallToSpawn, new Vector3(screenHalfWidth + 0.1f, 0, 0), Quaternion.identity);
        newWall.transform.localScale = new Vector3(0.1f, orthographicSize*2, 1);
        newWall.transform.parent = WallManager.transform;
        var newRoof = Instantiate(RoofToSpawn, new Vector3(0, orthographicSize + 0.1f, 0), Quaternion.identity);
        newRoof.transform.localScale = new Vector3(screenHalfWidth * 2, 0.1f, 0);
        newRoof.transform.parent = WallManager.transform;
            }
}
