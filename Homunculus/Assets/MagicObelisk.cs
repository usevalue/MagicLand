using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicObelisk : MonoBehaviour {

    public bool activated;
    public string[] connections;
    bool updated = true;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (updated) {
            ((Behaviour)GetComponent("Halo")).enabled = activated;
            foreach(string n in connections)
            {
                GameObject.Find(n).GetComponent<MagicGate>().ping();
            }
            updated = false;
        }
	}

    public void toggle() {
        activated = !activated;
        updated = true;
    }
}
