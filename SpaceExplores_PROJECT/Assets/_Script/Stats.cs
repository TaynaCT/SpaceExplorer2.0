using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Classe que atualiza a infomação dos recursos na tela

public class Stats : MonoBehaviour {
       
    public Text goldAmount;
    public Text ironAmount;
    public Text woodAmount;


    void Start()
    {     
        goldAmount.text = "00";
        ironAmount.text = "00";
        ironAmount.text = "00";
    }

    void Update()
    {
       // statsText.text = "Recurso: " + this.gameObject.GetComponent<Interação>().recursos;
               
    }


}
