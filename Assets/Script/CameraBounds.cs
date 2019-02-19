using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour {

    
    Camera cam;
    public static Vector2[] edgePoints = new Vector2[4];
    public static Vector3[] bricklocations = new Vector3[26];
    public static float[] brickHeights = new float[6];
    public static Vector2[] bottomPoints = new Vector2[2];

    // Use this for initialization
    void Start() {
        brickHeights[0] = 0;
        cam = Camera.main;
        edgePoints[0] = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        edgePoints[1] = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane));
        edgePoints[2] = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));
        edgePoints[3] = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane));
        bottomPoints[0] = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        bottomPoints[1] = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane));
        int i = 0;
        for(int y = 0; y<4; y++)
        {
            float ycord = -3.8f - y * 0.3f;
            for (int x = 0; x < 6 + y % 2; x++)
            {
                float xcord = (x - 3) + (((y + 1) % 2) * 0.5f);

                bricklocations[i] = new Vector3(xcord, ycord, 0);
                i++;
            }
            brickHeights[y+1] = ycord;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}