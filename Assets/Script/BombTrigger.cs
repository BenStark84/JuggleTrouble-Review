using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTrigger : MonoBehaviour
{
    public float activeTime { get; private set; }

    private void OnBecameInvisible()
    {
        FindObjectOfType<BombController>().SpawnBomb();
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        activeTime += Time.fixedDeltaTime;
    }

}