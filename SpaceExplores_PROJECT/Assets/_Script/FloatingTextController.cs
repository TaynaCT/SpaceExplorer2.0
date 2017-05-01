using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextController : MonoBehaviour {

    public FloatingText screenText = null;       

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CreatingText("Hello");
        }
    }

    public void CreatingText(string text)
    {        
        FloatingText instance = Instantiate(screenText);        
        instance.transform.SetParent(this.transform, false);
        //por aqui não é possivel introduzir um novo texto
        instance.GetComponent<FloatingText>().SetText(text);
     }

}
