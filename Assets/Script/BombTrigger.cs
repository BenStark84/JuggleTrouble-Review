using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTrigger : MonoBehaviour
{
    public float activeTime { get; private set; }
    BombController bombController;

    private void Awake()
    {
        bombController = GameObject.Find("bombController").GetComponent<BombController>();
    }
    private void OnBecameInvisible()
    {
        bombController.SpawnBomb();
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        activeTime += Time.fixedDeltaTime;
    }

}