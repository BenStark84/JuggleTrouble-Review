using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigureBoundry : MonoBehaviour {

    EdgeCollider2D edgeCollider;

    // Use this for initialization
    void Start () {
        edgeCollider = gameObject.GetComponent<EdgeCollider2D>();
        edgeCollider.points = CameraBounds.edgePoints;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
