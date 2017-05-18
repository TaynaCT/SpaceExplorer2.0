using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour {

    public float mouseSpeed;
    public float keyboardSpeed;
    public float camSpeed;
    Vector3 cameraLookAt;
    TileGenerator tg;
    Vector3 position;
    Vector3 playerPosition;
    int x, y;
    public static float tileRadius = 2.5f;

    bool camMoving = false;
    Vector3 camDestiny;

    // Use this for initialization
    void Start () {
        x = 0;
        y = 0;
        tg = GameObject.Find("World").GetComponent<TileGenerator>();
        Cursor.lockState = CursorLockMode.Confined;
        cameraLookAt = tg.GetTerrain()[x, y].transform.position;
        position = new Vector3(3.5f, 1.5f, -1.5f);
        transform.position = position;
        transform.LookAt(cameraLookAt);

        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                tg.GetTerrain()[x, y].SetActive(false);
            }
        }

        tg.GetTerrain()[x, y].SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {

        if (!camMoving)
        {
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            bool changedTile = false;
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

            if (Input.GetMouseButton(1))
            {
                float mouseX = Input.GetAxis("Mouse X");
                float angle = mouseX * Time.deltaTime * mouseSpeed;
                transform.RotateAround(cameraLookAt, Vector3.up, angle);
            }

            Vector3 camNormalizedOrigin = position + 2 * tileRadius * new Vector3(x, 0, y);
            Vector3 delta = transform.position - camNormalizedOrigin;

            if (playerPosition.x - cameraLookAt.x > tileRadius)
            {
                x++;
                if (x > 4)
                {
                    x = 4;
                }
                else
                {
                    tg.GetTerrain()[x, y].SetActive(true);
                    tg.GetTerrain()[x - 1, y].SetActive(false);
                }
                changedTile = true;
            }
            else if (playerPosition.x - cameraLookAt.x < -tileRadius)
            {
                x--;
                if (x < 0)
                {
                    x = 0;
                }
                else
                {
                    tg.GetTerrain()[x, y].SetActive(true);
                    tg.GetTerrain()[x + 1, y].SetActive(false);
                }
                changedTile = true;
            }

            if (playerPosition.z - cameraLookAt.z > tileRadius)
            {
                y++;
                if (y > 4)
                {
                    y = 4;
                }
                else
                {
                    tg.GetTerrain()[x, y].SetActive(true);
                    tg.GetTerrain()[x, y - 1].SetActive(false);
                }
                changedTile = true;
            }
            else if (playerPosition.z - cameraLookAt.z < -tileRadius)
            {
                y--;
                if (y < 0)
                {
                    y = 0;
                }
                else
                {
                    tg.GetTerrain()[x, y].SetActive(true);
                    tg.GetTerrain()[x, y + 1].SetActive(false);
                }
                changedTile = true;
            }

            if (changedTile)
            {
                camMoving = true;
                camDestiny = position + 2 * tileRadius * new Vector3(x, 0, y) + delta;
            }
        }
        else
        {
            Vector3 camOrigin = transform.position;

            if ((camDestiny - camOrigin).magnitude > 0.01f)
            {
                Vector3 camMovement = (camDestiny - camOrigin).normalized * camSpeed;

                transform.position += camMovement;
                cameraLookAt += camMovement;
            }
            else
            {
                cameraLookAt = tg.GetTerrain()[x, y].transform.position;
                camMoving = false;
            }
            transform.LookAt(cameraLookAt);
        }
    }
}
