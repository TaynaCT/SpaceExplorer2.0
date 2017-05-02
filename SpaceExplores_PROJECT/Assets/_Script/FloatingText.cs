using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Classe q controla a o texto que aparecem na tela do jogo

public class FloatingText : MonoBehaviour {

    public Animator textAnimator;
    float timer = 20; //timer para aparição do texto após iniciado a aplicação
    Text screenText; //texto que deverá aparecer na tela
   
    void Start()
    {        
        textAnimator.GetComponent<Animator>();
        screenText = textAnimator.GetComponent<Text>();
    }

    void Update()
    {
        timer -= .5f;

        if (timer < 0)
        {
            textAnimator.SetBool("FadeIN", true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            textAnimator.SetBool("FadeIN", false);
            textAnimator.SetBool("FadeOUT", true);

            //ao fim da animação, o objeto referente ao texto é destruido
            AnimatorClipInfo[] clipInfo = textAnimator.GetCurrentAnimatorClipInfo(0);
            Destroy(gameObject, clipInfo[0].clip.length);           
        }

    }

    /// <summary>
    /// função que recebe e passa o texto a ser mostrado na tela
    /// </summary>
    /// <param name="text"></param>
    public void SetText(string text)
    {
        screenText = textAnimator.GetComponent<Text>();
        screenText.text = text;
    }
}
