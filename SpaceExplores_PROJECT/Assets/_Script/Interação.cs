using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interação : MonoBehaviour
{
    //objectos que interagem
    public GameObject player;
    public GameObject[] metais;

    // sons das interações
    private AudioSource audio;

    //contador para recursos
    public float recursos { get; set; }

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        metais = GameObject.FindGameObjectsWithTag("metal");
        audio = GetComponent<AudioSource>();
        recursos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            for (int i = 0; i <= 5; i++)
            {
                if ((Vector3.Distance(metais[i].transform.position, player.transform.position) < 0.5) && ((Physics.Raycast(player.transform.position, player.transform.forward, .5f) == true)))
                {
                    recursos++;
                    audio.Play();
                    Destroy(metais[i]);
                }
            }
        }

    }

}