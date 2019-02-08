using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 7;
    float movement;
    float screenHalfWidthInWorldUnits;
    public static float screenHalfWidth;
    public static float aspectRatio;
    public static float orthographicSize;
    Vector2 touchLocation = Vector2.zero;
    int controlSchema;
    int direction;
    Camera mainCamera;
    // Use this for initialization

    void Start()
    {
        mainCamera = Camera.main;
        orthographicSize = mainCamera.orthographicSize;
        aspectRatio = mainCamera.aspect;
        float halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidth = aspectRatio * orthographicSize;
        screenHalfWidthInWorldUnits = screenHalfWidth + halfPlayerWidth;
        touchLocation.y = transform.position.y;
        controlSchema = PlayerPrefs.GetInt("control", 2);
    }

    // Update is called once per frame
    void Update()
    {
        movement = speed * Time.deltaTime;
#if UNITY_EDITOR || UNITY_STANDALONE 
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            float inputX = Input.GetAxisRaw("Horizontal");
            transform.Translate(Vector2.right * movement * inputX);
            if (Mathf.Abs(transform.position.x) > screenHalfWidthInWorldUnits)
            {
                transform.position = new Vector2(screenHalfWidthInWorldUnits * inputX, transform.position.y);
            }

            if (transform.position.x > screenHalfWidthInWorldUnits)
            {
                transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
            }

        }
#endif
#if UNITY_IOS || UNITY_ANDROID
        if (controlSchema == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                touchLocation = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                touchLocation.y = transform.position.y;
            }
            transform.position = Vector2.MoveTowards(transform.position, touchLocation, movement);
        }

        if (controlSchema == 1)
        {
            if (Input.GetMouseButton(0))
            {
                if ((Screen.width / 2) > (Input.mousePosition).x)
                {
                    touchLocation.x = -1;
                }
                if ((Screen.width / 2) < (Input.mousePosition).x)
                {
                    touchLocation.x = 1;
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                touchLocation.x = 0;
            }

            transform.Translate(Vector2.right * movement * touchLocation.x);
            if (Mathf.Abs(transform.position.x) > screenHalfWidthInWorldUnits)
            {
                transform.position = new Vector2(screenHalfWidthInWorldUnits * touchLocation.x, transform.position.y);
            }

            if (transform.position.x > screenHalfWidthInWorldUnits)
            {
                transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
            }
        }

        if (controlSchema == 2)
        {

            if (Input.GetMouseButton(0))
            {
                touchLocation = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                touchLocation.y = transform.position.y;
                transform.position = Vector2.MoveTowards(transform.position, touchLocation, movement);
            }
        }
#endif    
    }
}