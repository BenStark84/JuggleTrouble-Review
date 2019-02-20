using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTrigger : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        FindObjectOfType<BombController>().SpawnBomb();
        Destroy(gameObject);
    }
}