using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Classe q controla a o texto que aparecem na tela do jogo

public class FloatingText : MonoBehaviour {

    public Animator textAnimator;
    public GameObject textPanel;
    public Button button;
    float timer = 0; //timer para aparição do texto após iniciado a aplicação
    Text screenText; //texto que deverá aparecer na tela   
    bool flag;

    void Start()
    {        
        textAnimator.GetComponent<Animator>();
        screenText = textAnimator.GetComponent<Text>();
        textPanel.SetActive(false);
        flag = true;
        button.onClick.AddListener(SetFlag);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 3 && flag)
        {           
            textAnimator.SetBool("FadeIN", true);
            textPanel.SetActive(true);           
        }

        //condição para desaparecer o texto
        if (!flag)
        {
            textAnimator.SetBool("FadeIN", false);
            textAnimator.SetBool("FadeOUT", true);

            //ao fim da animação, o objeto referente ao texto é destruido
            AnimatorClipInfo[] clipInfo = textAnimator.GetCurrentAnimatorClipInfo(0);

            Destroy(gameObject, clipInfo[0].clip.length);
            textPanel.SetActive(false);
            timer = 0;                  
        }

    }

    /// <summary>
    /// função que recebe e passa o texto a ser mostrado na tela
    /// </summary>
    /// <param name="text"></param>
    public void SetText(string text)
    {
        flag = true;
        screenText = textAnimator.GetComponent<Text>();        
        screenText.text = text;               
    }

    public void SetFlag()
    {
        flag = false;
        Debug.Log("setFlag!!! ");
    }
}
