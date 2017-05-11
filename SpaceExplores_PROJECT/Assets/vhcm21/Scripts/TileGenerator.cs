using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour {

    public GameObject tile;

    GameObject[,] terrain;
    //CameraController cc;
    //float tileSize;
    int xTerrain;
    int yTerrain;
    Vector3 tilePosition;

	// Use this for initialization
	void Awake () {
        tilePosition = new Vector3(2.5f, 0.0f, 2.5f);
        xTerrain = 5;
        yTerrain = 5;
        terrain = new GameObject[xTerrain, yTerrain];
        //cc = new CameraController();
        //tileSize = cc.GetTileSize();

        for (int y = 0; y < yTerrain; y++)
        {
            tilePosition.x = 2.5f;

            for (int x = 0; x < xTerrain; x++)
            {
                terrain[x, y] = Instantiate(tile, tilePosition, Quaternion.identity) as GameObject;
                tilePosition.x += tile.transform.localScale.x;
            }

            tilePosition.z += tile.transform.localScale.z;
        }
    }

    public GameObject[,] GetTerrain() {
        return terrain;
    }
}
