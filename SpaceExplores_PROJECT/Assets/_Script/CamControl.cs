using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour {

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            this.transform.Rotate(new Vector3(0, 90, 0));           
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            this.transform.Rotate(new Vector3(0, -90, 0));
        }
    }
}
