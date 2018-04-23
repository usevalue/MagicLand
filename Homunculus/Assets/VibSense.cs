//IMPORTANT: Edit - Project Settings - Player - Other Settings 
//-> Configuration - Api Compatibility must be set to .NET 2.0

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class VibSense : MonoBehaviour
{

	SerialPort stream = new SerialPort ("/dev/cu.usbmodem1411", 9600); //check port name in Arduino and match!

	void Start ()
	{
		stream.Open ();
		stream.ReadTimeout = 1;
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
	
		if (vibState == 0) { 
			//MAKE SPARKLES...
			int value = stream.ReadByte (); //read Arduino byte and store value as integer
			//if arduino sends 0 (triggered), Unity receives 48 (byte representation of character 0), so use 48 to trigger events 
			print(value); //check in console
		}
}
}