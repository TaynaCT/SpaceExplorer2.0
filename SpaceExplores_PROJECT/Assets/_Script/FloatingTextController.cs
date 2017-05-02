using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    

public class FloatingTextController : MonoBehaviour {

    public GameObject screenText;      

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CreatingText("Hello");
        }
    }

    public void CreatingText(string text)
    {      
        GameObject instance = Instantiate(screenText);
            
        instance.transform.SetParent(this.transform, false);
        instance.GetComponent<FloatingText>().SetText(text);
        //por aqui não é possivel introduzir um novo texto
        //instance.SetText(text);
    }

}
