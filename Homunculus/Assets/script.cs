using UnityEngine;
using System.Collections;

public class script : MonoBehaviour {
	public bool guiTrigger;
	public GUIStyle myGUIStyle;
	public Font f;
	public bool pressed = false;


	void OnTriggerEnter(Collider other){
		guiTrigger = true;
	}

	void OnTriggerExit(Collider other){
		guiTrigger = false;
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.E)) pressed = true;

	}

	void OnGUI(){
		myGUIStyle = new GUIStyle ();
		myGUIStyle.fontSize = 20;
		myGUIStyle.normal.textColor = Color.yellow;
		GUI.skin.font = f;
		if (guiTrigger) {
			if (!pressed) {
				GUI.Box (new Rect (200, 200, 300, 300), "Press E to Interact", myGUIStyle);
			}
			if (pressed) {
				GUI.Box (new Rect (200, 200, 300, 300), "P" , myGUIStyle);


			}

		}
	}
}