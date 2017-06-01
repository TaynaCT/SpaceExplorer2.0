using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Soundtrack : MonoBehaviour
{

    private AudioSource sound;
    public AudioClip[] backgroundMusic;
    int selectedMusic;

    // Use this for initialization
    void Start()
    {
        sound = GetComponent<AudioSource>();
        selectedMusic = 9;
    }

    // Update is called once per frame
    void Update()
    {
        sound.transform.position = transform.position;

        if (selectedMusic > backgroundMusic.Length - 1)
        {
            AudioClip last = backgroundMusic[backgroundMusic.Length - 1];
            Shuffle(backgroundMusic);
            if (last == backgroundMusic[0])
            {
                AudioClip aux = backgroundMusic[0];
                backgroundMusic[0] = backgroundMusic[backgroundMusic.Length - 1];
                backgroundMusic[backgroundMusic.Length - 1] = aux;
            }

            selectedMusic = -1;
        }
        else
        {
            if (!sound.isPlaying)
            {
                selectedMusic++;
                if (selectedMusic <= backgroundMusic.Length - 1)
                {
                    sound.clip = backgroundMusic[selectedMusic];
                    sound.Play();
                }
            }
        }
    }

    void Shuffle(AudioClip[] audioList)
    {
        for (int i = 0; i < audioList.Length; i++)
        {
            AudioClip temp = audioList[i];
            int randomIndex = Random.Range(i, audioList.Length);
            audioList[i] = audioList[randomIndex];
            audioList[randomIndex] = temp;
        }
    }
}
