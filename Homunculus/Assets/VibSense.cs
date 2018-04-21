using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class VibSense : MonoBehaviour {

	SerialPort stream = new SerialPort("/dev/cu.usbmodem1411", 9600);
	int vibState = 0;


	void Start () {
		stream.Open ();
		stream.ReadTimeout = 50;
	}


	void Update () {
		string value = stream.ReadLine ();
		vibState = int.Parse (value);
		Debug.Log (value);
	}



	/* void OnGUI()
	{
		string newString = "Connected: " + vibState;
		//Debug.Log (vibState);
		//OnGUI.Label (new Rect (10, 10, 300, 100), newString);
	}
	*/

	//void Wand() {

}

