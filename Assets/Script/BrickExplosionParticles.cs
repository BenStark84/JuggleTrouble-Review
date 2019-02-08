using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickExplosionParticles : MonoBehaviour
{
    

    // Use this for initialization
    void Start()
    {
        ParticleSystem exp = GetComponent<ParticleSystem>();
        exp.Play();
        Destroy(transform.parent.gameObject, exp.main.duration);
    }
}