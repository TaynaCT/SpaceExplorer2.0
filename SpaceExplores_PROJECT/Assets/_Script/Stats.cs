using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Classe que atualiza a infomação dos recursos na tela

public class Stats : MonoBehaviour {
       
    public Text metalAmount;
    public Text woodAmount;


    void Start()
    {     
        metalAmount.text = "00";       
        woodAmount.text = "00";
    }

    void Update()
    {
        // statsText.text = "Recurso: " + this.gameObject.GetComponent<Interação>().recursos;

        metalAmount.text = this.gameObject.GetComponent<Interação>().recursos.ToString();
        woodAmount.text = this.gameObject.GetComponent<Interação>().woods.ToString();
    }


}
