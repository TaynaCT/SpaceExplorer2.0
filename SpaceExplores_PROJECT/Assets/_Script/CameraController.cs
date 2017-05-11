using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float mouseSpeed;
    public float keyboardSpeed;

    Vector3 cameraLookAt;
    Transform tileTransform;
    Transform firstSoloTransform;
    Transform lastSoloTransform;
    Vector3 position;
    float angle;


    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        angle = 0f;
        tileTransform = GameObject.Find("MainTile").transform;
        firstSoloTransform = tileTransform.Find("DesertSideTile");
        lastSoloTransform = tileTransform.Find("DesertSideTile (241)");
        cameraLookAt = (firstSoloTransform.position + lastSoloTransform.position) / 2;
        position = new Vector3(firstSoloTransform.position.x +
            firstSoloTransform.localScale.x / 2, 10f,
            firstSoloTransform.position.z + firstSoloTransform.localScale.z / 2);
        transform.position = position;
        transform.LookAt(cameraLookAt);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float angle = mouseX * Time.deltaTime * mouseSpeed;
            transform.RotateAround(cameraLookAt, Vector3.up, angle);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            float angle = Time.deltaTime * keyboardSpeed;
            transform.RotateAround(cameraLookAt, Vector3.up, angle);
        }

        if (Input.GetKey(KeyCode.C))
        {
            float angle = -Time.deltaTime * keyboardSpeed;
            transform.RotateAround(cameraLookAt, Vector3.up, angle);
        }
    }

    public float GetTileSize()
    {
        float tileSize = lastSoloTransform.position.x - firstSoloTransform.position.x;
        return tileSize;
    }
}