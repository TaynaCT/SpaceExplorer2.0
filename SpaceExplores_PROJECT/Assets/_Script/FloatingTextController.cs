using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextController : MonoBehaviour {

    public FloatingText screenText = null;
    public TextAsset textFile;
    bool showText; // Quando true é ativado a criação do texto
    bool flag;
    int indice = 0;    
    float timer = 0;  

    string[] arrayText;

    void Start()
    {        
        if (textFile != null)
            arrayText = (textFile.text.Split('\n'));
        showText = true;
        flag = false;
    }

    public void Update()
    {
        timer += Time.deltaTime;

        //ativação e criação funciona
        if (showText && indice < arrayText.Length)
        {
            CreatingText(arrayText[indice]);
            indice++;

            showText = false;
            flag = false;
            Debug.Log("INDICE: " + indice);
        }

        if (flag == true)
        {
            Debug.Log("FLAG: " + flag);
            if (timer > 5 && indice == 1)
            {
                showText = true;
                timer = 0;
            }

            if ((Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.C)) && (indice == 2))
            {
                showText = true;
            }

            if (Input.GetKeyDown(KeyCode.E) && (indice == 3))
            {
                showText = true;
            }

            if (timer > 5 && indice == 4)
            {
                showText = true;
                timer = 0;
            }
            if (timer > 5 && indice == 5)
            {
                showText = true;
                timer = 0;
            }
        }

    }

    public void CreatingText(string text)
    {
        FloatingText instance = Instantiate(screenText);
        instance.transform.SetParent(this.transform, false);
        instance.GetComponent<FloatingText>().SetText(text);
        instance.GetComponent<FloatingText>().button.onClick.AddListener(Flag);        
    }

    public void Flag()
    {
        flag = true;
    }
}
