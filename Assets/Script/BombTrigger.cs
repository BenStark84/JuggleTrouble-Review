using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTrigger : MonoBehaviour
{
    public float activeTime { get; private set; }
    BombController bombController;

    private void Start()
    {
        bombController = GameObject.Find("BombManager").GetComponent<BombController>();
        activeTime = Time.timeSinceLevelLoad;
    }
    private void OnBecameInvisible()
    {
        bombController.SpawnBomb();
        Destroy(gameObject);
    }
}