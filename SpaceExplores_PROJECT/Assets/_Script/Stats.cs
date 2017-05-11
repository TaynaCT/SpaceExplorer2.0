using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour {

    private Text statsText;
    public Text screenText;
    
	void Start()
    {
        statsText = screenText.GetComponent<Text>();
    }

    void Update()
    {
        statsText.text = "Recurso: " + this.gameObject.GetComponent<Interação>().recursos;
    }


}
