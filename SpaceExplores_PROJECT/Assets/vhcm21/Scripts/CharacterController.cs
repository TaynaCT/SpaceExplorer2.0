using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    Animator animator;
    private Rigidbody rb;
    public float Speed, RunningSpeed;
    Vector3 velocity;
  //  CamController cam;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    //    cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CamController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //    if (!cam.camMoving)
        //  {
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
        //    }
    }

    private void LateUpdate()
    {
        Vector3 charPosition = transform.position;
        if (transform.position.x > 2 * CamController.tileRadius * 5)
            charPosition.x = 2 * CamController.tileRadius * 5;
        else if (transform.position.x < 0f)
            charPosition.x = 0f;

        if (transform.position.z > 2 * CamController.tileRadius * 5)
            charPosition.z = 2 * CamController.tileRadius * 5;
        else if (transform.position.z < 0f)
            charPosition.z = 0f;

        transform.position = charPosition;
    }
}
