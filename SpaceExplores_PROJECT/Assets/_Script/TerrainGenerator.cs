using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour {

    Dictionary<int, int> terrain =
        new Dictionary<int, int>();
    CameraController cc;
    float tileSize;
    Vector3 playerPosition;

	// Use this for initialization
	void Start () {
        cc = new CameraController();
        tileSize = cc.GetTileSize();
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        foreach (int i in terrain.Keys)
        {
            terrain[i] = 1;
        }


	}
	
	// Update is called once per frame
	void Update() {

    }
}
