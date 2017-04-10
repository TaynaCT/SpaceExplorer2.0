using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    Transform tileTransform;
    Vector3 position;

	// Use this for initialization
	void Start () {
        tileTransform = GameObject.FindGameObjectWithTag("tile").transform;
        position = new Vector3(tileTransform.position.x +
            tileTransform.localScale.x / 2, 26, 
            tileTransform.position.z + tileTransform.localScale.z / 2);
        transform.position = position;
        transform.LookAt(tileTransform.position);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
