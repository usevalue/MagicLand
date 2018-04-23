using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicIdol : MonoBehaviour {

    bool activated;
	// Use this for initialization
	void Start () {
        activated = false;
        lightOut();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool isActivated()
    {
        return activated;
    }

    public void deActivate()
    {
        activated = false;
    }

    public void ping()
    {
        activated = true;
    }

    public void lightUp()
    {
        ((Behaviour)GetComponent("Halo")).enabled = true;
    }

    public void lightOut()
    {
        ((Behaviour)GetComponent("Halo")).enabled = false;
    }
}
