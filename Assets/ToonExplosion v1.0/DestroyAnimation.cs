﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAnimation : MonoBehaviour {
    public float delay = 0f;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject.transform.parent.gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }
}
