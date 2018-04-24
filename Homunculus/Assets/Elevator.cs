using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

    public string NameOfElevator = "Crossing";
    GameObject elevator;

	// Use this for initialization
	void Start () {
        elevator = GameObject.Find(NameOfElevator);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
