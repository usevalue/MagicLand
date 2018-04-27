//IMPORTANT: Edit - Project Settings - Player - Other Settings 
//-> Configuration - Api Compatibility must be set to .NET 2.0

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class VibSense : MonoBehaviour
{
    public static string portName = "/dev/cu.usbmodem1411";

    SerialPort stream = new SerialPort (portName, 9600); //check port name in Arduino and match!

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


	void Wand (int vibState)
	{

		if (vibState == 0) { //if something is happening
            GameObject.Find("3rdPersonCamera").GetComponent<Caster>().castSpell();
			//MAKE SPARKLES...
			int value = stream.ReadByte (); //read Arduino byte and store value as integer
			//if arduino sends 0 (triggered), Unity receives 48 (byte representation of character 0), so use 48 to trigger events 
			print(value); //check in console
		}
	}
}