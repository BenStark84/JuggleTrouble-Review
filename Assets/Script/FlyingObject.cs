using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObject : MonoBehaviour {

    public float velocity;
    public Vector2 velocityRange = new Vector2(5,10);
    public float screenEdge;
    int direction;

	// Use this for initialization
	void Start () {
        //Sets initial location and rotation of flying objects
        direction = Random.Range(0, 2) * 2 - 1;
        velocity = Random.Range(velocityRange.x, velocityRange.y)*direction;
        screenEdge = PlayerController.screenHalfWidth;
        if (gameObject.name == "FlyingCapsule(Clone)")
        {
            transform.Rotate(0, 0, 90);
        }
        if (gameObject.name == "FlyingCube(Clone)")
        {
            transform.Rotate(0, 0, 45);
        }
        transform.position = new Vector3(transform.position.x * direction, transform.position.y, 0);


    }

    // Update is called once per frame
    void Update() {
        //Moves the object across the screen
        transform.Translate(Vector2.right * velocity * Time.deltaTime, Space.World);

        if ((transform.position.x > screenEdge + 2 && velocity > 0) || (transform.position.x < -screenEdge - 2 && velocity < 0))
        {
            Destroy(gameObject);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            AudioSource collisionSound = gameObject.GetComponent<AudioSource>();
            if (!collisionSound.isPlaying)
            {
                gameObject.gameObject.GetComponent<AudioSource>().Play();
            }
        }

    }
}
