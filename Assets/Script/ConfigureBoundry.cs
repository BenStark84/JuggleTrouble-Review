using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigureBoundry : MonoBehaviour {

    EdgeCollider2D edgeCollider;
    Vector2[] edgePoints = CameraBounds.edgePoints;

    // Use this for initialization
    void Start () {
        edgeCollider = gameObject.GetComponent<EdgeCollider2D>();
        edgeCollider.points = edgePoints;
    }

}
