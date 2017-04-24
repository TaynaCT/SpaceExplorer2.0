using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

    public Text instrucion;
    bool flag = false;

	// Use this for initialization
	void Start () {
        instrucion = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.A))
        {
            flag = true;   
        }

        if (Input.GetKey(KeyCode.D))
        {
            flag = true;
        }

        if(flag)
            instrucion.text = " ";
    }
}
