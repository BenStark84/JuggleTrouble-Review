using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickExplosionParticles : MonoBehaviour
{
    
    //Attached to a gameObject that is spawned when a brick is destroyed. 
    //The particles appear fall and then the game object is destroyed.
    //I would like to add and explosion
    // Use this for initialization
    void Start()
    {
        ParticleSystem exp = GetComponent<ParticleSystem>();
        exp.Play();
        Destroy(transform.parent.gameObject, exp.main.duration);
    }
}