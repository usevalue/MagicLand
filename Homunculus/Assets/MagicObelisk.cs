using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicObelisk : MagicSensitive {

    public bool activated;
    public string[] connections;
    bool updated = true;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (updated) {
            foreach(string n in connections)
            {
                GameObject.Find(n).GetComponent<MagicSensitive>().ping();
            }
            updated = false;
        }

        ((Behaviour)GetComponent("Halo")).enabled = activated;

    }

    public void toggle() {
        activated = !activated;
        if (activated) GetComponent<AudioSource>().PlayOneShot(SoundLibrary.lib.obeliskOn);
        else GetComponent<AudioSource>().PlayOneShot(SoundLibrary.lib.obeliskOff);
        updated = true;
    }

    public override void ping()
    {
        toggle();
    }
}
