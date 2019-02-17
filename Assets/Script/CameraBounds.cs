using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour {

    
    Camera cam;
    public static Vector2[] edgePoints = new Vector2[4];

	// Use this for initialization
	void Start () {

        cam = Camera.main;
        edgePoints[0] = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        edgePoints[1] = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane));
        edgePoints[2] = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));
        edgePoints[3] = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane));


    }

    // Update is called once per frame
    void Update () {
		
	}
}