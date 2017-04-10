using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float speed;

    Vector3 cameraLookAt;
    Transform tileTransform;
    Vector3 position;
    float angle;

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Confined;
        angle = 0f;
        tileTransform = GameObject.FindGameObjectWithTag("tile").transform;
        cameraLookAt = tileTransform.position + Vector3.up * tileTransform.localScale.y / 2;
        position = new Vector3(tileTransform.position.x +
            tileTransform.localScale.x / 2, 26, 
            tileTransform.position.z + tileTransform.localScale.z / 2);
        transform.position = position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float angle = mouseX * Time.deltaTime * speed;
            transform.RotateAround(cameraLookAt, Vector3.up, angle);
        }
    }
}
