//IMPORTANT: Edit - Project Settings - Player - Other Settings 
//-> Configuration - Api Compatibility must be set to .NET 2.0

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class VibSense : MonoBehaviour { 

    SerialPort stream = new SerialPort ("COM3", 9600); //check port name in Arduino and match!

	void Start ()
	{
        try
        {
            stream.Open();
            stream.ReadTimeout = 1;
        }
        catch (System.IO.IOException e)
        {
            Debug.Log("No wand available.");
        }
	}


	void Update ()
	{

		if (stream.IsOpen) {
			try {
				Wand (stream.ReadByte ());
			} catch (System.Exception) {
			}

		}
	}

    int counter = 0;

	void Wand (int vibState)
	{
        Debug.Log(vibState);

		if (vibState == 48) { //if something is happening
            Debug.Log("Fire!");
            GameObject.Find("3rdPersonCamera").GetComponent<Caster>().waveWand();
			//MAKE SPARKLES...
			int value = stream.ReadByte (); //read Arduino byte and store value as integer
			//if arduino sends 0 (triggered), Unity receives 48 (byte representation of character 0), so use 48 to trigger events 
			//print(value); //check in console
		}
	}
}