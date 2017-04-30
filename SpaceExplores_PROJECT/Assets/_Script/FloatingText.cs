using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe q controla a o texto que aparecem na tela do jogo

public class FloatingText : MonoBehaviour {

    public Animator textAnimator;
    float timer = 10;
   
    void Start()
    {
        textAnimator.GetComponent<Animator>();
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

            AnimatorClipInfo[] clipInfo = textAnimator.GetCurrentAnimatorClipInfo(0);
            Destroy(gameObject, clipInfo[0].clip.length);
        }

        

        
    }
	 
}
