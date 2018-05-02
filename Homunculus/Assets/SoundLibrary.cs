using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLibrary : MonoBehaviour {

    public static SoundLibrary lib;

    public AudioClip death;
    public AudioClip obeliskOn;
    public AudioClip obeliskOff;
    public AudioClip castSpell;
    public AudioClip doorOpen;
    public AudioClip doorClose;

	// Use this for initialization
	void Start () {
        lib = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
