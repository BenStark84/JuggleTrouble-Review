using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickTrigger : MonoBehaviour {

    BombController bombController;

    private void Start()
    {
        bombController = GameObject.Find("BombController").GetComponent<BombController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            bombController.bombTriggered(gameObject, collision);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
