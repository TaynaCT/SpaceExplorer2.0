using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextController : MonoBehaviour {

    private static FloatingText screenText;
    private static GameObject canvas;

    string[] textArray = { "Ola", "como vai vc?", "vlw" };

    public static void Initialize()
    {
        canvas = GameObject.Find("Canvas");
        screenText = Resources.Load<FloatingText>("_Prefabs/TextParent.prefab");       
    }

    public void Update()
    {
        if (Input.anyKeyDown)
        {
            CreatingText(textArray[0]);
        }
    }

    public static void CreatingText(string text)
    {
        FloatingText instane = Instantiate(screenText);
        instane.transform.SetParent(canvas.transform, false);

        instane.SetText(text);
    }

}
