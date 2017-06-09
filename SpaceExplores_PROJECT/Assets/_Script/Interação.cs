using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interação : MonoBehaviour
{
    //objectos que interagem
    public GameObject player;

    private GameObject ponte;
    private GameObject pontefim;
    private GameObject pontemedio;
    private GameObject nave;
    
    private List<GameObject> iron;
    private List<GameObject> gold;
    private List<GameObject> wood;
    private List<GameObject> water;
    
    // sons das interações
    private AudioSource sound;

    //Lista de sons para usar
    public AudioClip[] sounds;

    //contador para recursos
    public float recursos { get; set; }

    //contador para madeira
    public float woods { get; set; }

    //activação da nave
    public bool motor;

    //construção da ponte
    public bool construção;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        //ponte = GameObject.FindWithTag("ponte");
        nave = GameObject.FindWithTag("nave");

        ponte = GameObject.FindWithTag("ponte");
        pontemedio = GameObject.FindWithTag("ponte1");
        pontefim = GameObject.FindWithTag("ponte2");

        pontemedio.SetActive(false);
        pontefim.SetActive(false);
        
        wood = new List<GameObject>(GameObject.FindGameObjectsWithTag("wood"));
        iron = new List<GameObject>(GameObject.FindGameObjectsWithTag("iron"));
        gold = new List<GameObject>(GameObject.FindGameObjectsWithTag("gold"));
        water = new List<GameObject>(GameObject.FindGameObjectsWithTag("water"));
        sound = GetComponent<AudioSource>();
        motor = true;
        construção = true;
        
        recursos = 00;
        woods = 00;        
    }

    // Update is called once per frame
    void Update()
    {
        sound.transform.position = player.transform.position;

        Debug.DrawRay(player.transform.position, player.transform.forward * 10, Color.red);
        if (Input.GetKeyDown(KeyCode.E))
        {
            for (int i = 0; i < iron.Count; i++)
            {
                //RaycastHit rHit = new RaycastHit();
                if (Vector3.Distance(iron[i].transform.position, player.transform.position) < 0.5 &&
                    Physics.Raycast(player.transform.position, player.transform.forward, 3))
                {
                    recursos++;
                    int chooseSound = Random.Range(0, 2);
                    sound.clip = sounds[chooseSound];
                    sound.Play();
                    Destroy(iron[i]);
                    iron.RemoveAt(i);
                }
            }

            for (int i = 0; i < gold.Count; i++)
            {
                //RaycastHit rHit = new RaycastHit();
                if (Vector3.Distance(gold[i].transform.position, player.transform.position) < 0.5 &&
                    Physics.Raycast(player.transform.position, player.transform.forward, 3))
                {
                    recursos = recursos + 2;
                    int chooseSound = Random.Range(0, 2);
                    sound.clip = sounds[chooseSound];
                    sound.Play();
                    Destroy(gold[i]);
                    gold.RemoveAt(i);
                }
            }

            for (int i = 0; i < wood.Count; i++)
            {
                //RaycastHit rHit = new RaycastHit();
                if (Vector3.Distance(wood[i].transform.position, player.transform.position) < 0.5 &&
                    Physics.Raycast(player.transform.position, player.transform.forward, 1))
                {
                    woods++;
                    int chooseSound = Random.Range(0, 2);
                    sound.clip = sounds[chooseSound];
                    sound.Play();
                    Destroy(wood[i]);
                    wood.RemoveAt(i);
                }
            }

            if (motor)
            {
                if (Vector3.Distance(nave.transform.position, player.transform.position) < 0.5 &&
                   Physics.Raycast(player.transform.position, player.transform.forward, 3))
                {
                    if (recursos >= 3)
                    {
                        motor = false;
                        recursos = recursos - 3;

                        //meter o texto que vai aparecer quando a nave ligar


                        int chooseSound = Random.Range(0, 2);
                        sound.clip = sounds[chooseSound];
                        sound.Play();
                    }
                    else
                    {
                        //meter o texto que vai aparecer quando o jogador tentar e nao tiver recursos


                    }
                }
            }

            if (construção)
            {
                if (Vector3.Distance(ponte.transform.position, player.transform.position) < 1
                &&
                   Physics.Raycast(player.transform.position, player.transform.forward, 3))
                {
                    if (woods >= 3)
                    {
                        pontefim.SetActive(true);
                        pontemedio.SetActive(true);
                                                
                        //meter o texto que vai aparecer quando a ponte for construida
                        woods = woods - 3;
                        construção = false;

                        int chooseSound = Random.Range(0, 2);
                        sound.clip = sounds[chooseSound];
                        sound.Play();
                    }
                    else
                    {
                        //meter o texto que vai aparecer quando o jogador tentar e nao tiver recursos


                    }
                }
            }


            for (int i = 0; i < water.Count; i++)
            {
                //RaycastHit rHit = new RaycastHit();
                if (Vector3.Distance(water[i].transform.position, player.transform.position) < 1
                    && Physics.Raycast(player.transform.position, player.transform.forward, 3))
                {
                    gameObject.GetComponent<CharacterHealth>().waterLevel = gameObject.GetComponent<CharacterHealth>().waterMax;
                    int chooseSound = Random.Range(0, 2);
                    sound.clip = sounds[chooseSound];
                    sound.Play();
                    Destroy(water[i]);
                    water.RemoveAt(i);
                }
            }


        }
    }
}