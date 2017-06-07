using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interação : MonoBehaviour
{
    //objectos que interagem
    public GameObject player;
    private List<GameObject> metais;
    private GameObject recurso;

    // sons das interações
    private AudioSource sound;

    //Lista de sons para usar
    public AudioClip[] sounds;

    //contador para recursos
    public float recursos { get; set; }

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        metais = new List<GameObject>(GameObject.FindGameObjectsWithTag("metal"));
        sound = GetComponent<AudioSource>();
        recursos = 0;
    }

    // Update is called once per frame
    void Update()
    {        
        sound.transform.position = player.transform.position;

        Debug.DrawRay(player.transform.position, player.transform.forward * 10, Color.red);
        if (Input.GetKeyDown(KeyCode.E))
        {
            for (int i = 0; i < metais.Count; i++)
            {
                //RaycastHit rHit = new RaycastHit();
                if (Vector3.Distance(metais[i].transform.position, player.transform.position) < 0.5 &&
                    Physics.Raycast(player.transform.position, player.transform.forward, 3))
                {
                    recursos++;
                    int chooseSound = Random.Range(0, 2);
                    sound.clip = sounds[chooseSound];
                    sound.Play();
                    Destroy(metais[i]);
                    metais.RemoveAt(i);
                }
            }
        }

    }

}