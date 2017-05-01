using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextController : MonoBehaviour {

    public FloatingText screenText = null;

    string[] textArray = { "Ola", "como vai vc?", "vlw" };

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CreatingText(textArray[0]);
        }
    }

    public void CreatingText(string text)
    {        
        FloatingText instance = Instantiate(screenText);        
        instance.transform.SetParent(this.transform, false);
        instance.SetText(text);

    }

}
