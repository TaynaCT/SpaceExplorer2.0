using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundtrack : MonoBehaviour {

    private AudioSource sound;
    public AudioClip[] backgroundMusic;
    int sortedCount;

	// Use this for initialization
	void Start () {
        sound = GetComponent<AudioSource>();
        sortedCount = 9;
	}
	
	// Update is called once per frame
	void Update () {
        for(int i = 0; i < sortedCount; i++)
        {
            int selection = Random.Range(0, sortedCount);
            sortedCount--;
        }

	}
}
