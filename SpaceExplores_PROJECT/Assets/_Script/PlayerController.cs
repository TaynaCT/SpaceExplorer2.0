﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Animator animator;
    private Rigidbody rb;
    public float Speed, RunningSpeed;
    Transform toPush;
    Vector3 velocity;
    public AudioClip[] walkSounds;
    private AudioSource sound;
    private bool playSound;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        sound.transform.position = transform.position;
        playSound = false; 
          
        //andar
        if (Input.GetAxis("Vertical") > 0)//andar para frente 
        {
            //velocity = transform.forward * Speed;

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
            {
                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.4f
                    && animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.6f)
                {
                    rb.AddForce(new Vector3(0, 0.21f, 0) + transform.forward * 0.03f, ForceMode.Impulse);
                    /*velocity.y = rb.velocity.y;
                    rb.velocity = velocity;*/
                }
            }
            else
            {
                animator.SetBool("isWalking", true);
                velocity = transform.forward * Speed;

                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime == 0.4f && !playSound)
                {

                }

                //correr
                if (Input.GetButton("Running"))
                {
                    velocity = velocity * RunningSpeed;
                    animator.SetBool("isRunning", true);
                }
                else
                {
                    animator.SetBool("isRunning", false);
                }

                velocity.y = rb.velocity.y;
                rb.velocity = velocity;
            }
            velocity = transform.forward * Speed;
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        //saltar
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("jump", true);
        }
        else
        {
            animator.SetBool("jump", false);
        }

        if (Input.GetAxis("Horizontal") > 0)//virar para a direita 
        {
            transform.transform.Rotate(new Vector3(0, 2f, 0));

        }
        else if (Input.GetAxis("Horizontal") < 0)//virar para a esquerda
        {
            transform.transform.Rotate(new Vector3(0, -2f, 0));
        }

    }

    //void OnCollisionEnter(Collision c)
    //{
    //    if (c.gameObject.CompareTag("Movel"))
    //    {
    //        animator.SetBool("push", true);
    //        velocity = velocity / 10;
    //       Debug.Log("IS HITTING");
    //    }        
        
    //}

    private void OnCollisionExit(Collision collision)
    {
        animator.SetBool("push", false);
    }

    void PlayFoot(int i)
    {
        sound.clip = walkSounds[i];
        sound.Play();
    }

}
