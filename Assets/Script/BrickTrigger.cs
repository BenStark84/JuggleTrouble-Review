using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickTrigger : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            FindObjectOfType<BombController>().bombTriggered(gameObject, collision);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
